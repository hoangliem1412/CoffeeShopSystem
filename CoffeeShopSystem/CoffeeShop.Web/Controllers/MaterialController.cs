using AutoMapper;
using CoffeeShop.Model.ModelEntity;
using CoffeeShop.Service;
using CoffeeShop.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CoffeeShop.Web.Controllers
{
    public class MaterialController : Controller
    {
        private IMaterialService materialService;
        private IMaterialCategoryService materialCategoryService;

        public MaterialController(IMaterialService mateService, IMaterialCategoryService mateCateService)
        {
            this.materialService = mateService;
            this.materialCategoryService = mateCateService;
        }

        // GET: Material
        public ActionResult Index()
        {
            //Lay danh sach material category cho combobox trong popup add va edit
            ViewBag.MateCateList = materialCategoryService.GetAll();
            return View();
        }

        //Hàm duoc ajax gọi khi load trang
        public ActionResult LoadData(string keyword, int status, int page, int pageSize = 5)
        {
            int totalRow = 0;
            var listMaterial = materialService.GetSearchStatusPaging(keyword, status, page, pageSize, out totalRow);
            //var listMaterialVm = Mapper.Map<List<MaterialViewModel>>(listMaterial);
            //var json = JsonConvert.SerializeObject(listMaterial, Formatting.Indented, new JsonSerializerSettings {
            //    PreserveReferencesHandling = PreserveReferencesHandling.Objects
            //});
            //var rs = JsonConvert.DeserializeObject(json);
            //data.Data = listMaterial;
            //return data;
            return Json(new
            {
                data = listMaterial, //danh sach Material
                total = totalRow, //Tỗng số record được truy vấn
                status = true //trạng thái
            }, JsonRequestBehavior.AllowGet);
        }
        //Action được ajax gọi khi click submid trên popup
        public JsonResult SubmitForm(string strMaterial)
        {
            //Lấy material được truyền qua
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Material material = serializer.Deserialize<Material>(strMaterial);

            bool status = false;
            string message = string.Empty;
            bool action;
            //action là thêm khi có id = 0
            if (material.ID == 0)
            {
                //material.CreatedDate = DateTime.Now;
                material.IsDelete = false;
                materialService.Add(material);
                action = true;
            }
            else //action là sửa khi có id cụ thể
            {
                material.IsDelete = false;
                materialService.Update(material);
                action = false;
            }

            //update xuống database
            try
            {
                materialService.Save();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                message = ex.Message;
            }

            return Json(new
            {
                status = status,
                message = message,
                action = action
            });
        }
   
        public JsonResult GetDetailEdit(int id)
        {
            Material material = materialService.GetSingleByID(id);
            return Json(new
            {
                material = material,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            string message = string.Empty;
            bool status;
            materialService.Delete(id);
            try
            {
                materialService.Save();
                status = true;
            }
            catch (SqlException sEx)
            {
                message = sEx.Message;
                status = false;
            }

            return Json(new
            {
                status = status,
                message = message
            }, JsonRequestBehavior.AllowGet);
        }
    }
}