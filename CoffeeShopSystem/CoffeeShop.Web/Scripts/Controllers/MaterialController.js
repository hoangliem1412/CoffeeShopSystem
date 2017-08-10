var pageIndex = 1;
function convertDateJson(date) {
    var value = new Date
            (
                 parseInt(date.replace(/(^.*\()|([+-].*$)/g, ''))
            );
    var dat = value.getFullYear() + "-" + ("0" + value.getMonth()).slice(-2) + "-" + ("0" + value.getDay()).slice(-2);
    return dat;
}
function pagination_LoadTable(data, tableHolder) {
    var row = "";
    data.forEach(function (item) {
        row += "<tr><td></td>";
        row += "<td>" + (item.CreatedDate != null ? convertDateJson(item.CreatedDate) : null) + "</td>";
        row += "<td>" + item.CategoryID + "</td>";
        row += "<td>" + item.Inventory + "</td>";
        row += "<td>" + item.UnitPrice + "</td>";
        row += "<td>" + item.Name + "</td>";
        row += "<td>" + item.IsDelete + "</td>";
        row += "<td>" + item.Description + "</td>";
        row += "<td>";
        row += "<a class='btn btn-info btn-xs btnEditMaterial' data-id='" + item.ID + "' title='Chỉnh sửa'><i class='fa fa-pencil'></i></a>";
        row += "<a class='btn btn-danger btn-xs' data-id='" + item.ID + "' title='Xóa'><i class='fa fa-trash-o'></i></a>";
        row += "</td>";
    });

    tableHolder.empty();
    tableHolder.append(row);
}
var material = {
    init: function () {
        material.loadData();
        material.registerEvent();
    },
    registerEvent: function () {
        $("#btnAddNew").click(function () {
            $('#SubmitFrmMaterial').text("Thêm");
            $("#frmMaterialLogInfo")[0].reset();
            $("#MyModal").modal();
        });

        //event click delete
        $('.btn-danger').click(function () {
            var id = $(this).data('id');
            $('#btn-deleteMaterial').data('id', id)
            $("#DeleteConfirmation").modal("show");
        });
        $("#text-search").off('keypress').on('keypress', function (e) {
            if (e.which == 13) {
                material.loadData(true);
            }
        });

        $("#comboPageSize").off('change').on('change', function (e) {
            $('#text-search').val("");
            material.loadData(true);
        });

        $('input[name=optradio]').off('click').on('click', function () {
            $('#text-search').val("");
            material.loadData(true);
        });

        $('.btnEditMaterial').off('click').on('click', function () {
            $("#frmMaterialLogInfo")[0].reset();
            var id = parseInt($(this).data('id'));
            $.ajax({
                type: 'GET',
                url: '/Material/GetDetailEdit',
                dataType: 'JSON',
                data: { id: id },
                success: function (response) {
                    if (response.status) {
                        var material = response.material;
                        $('#txtName').val(material.Name);
                        $('#slCategory').val(material.CategoryID);
                        $('#txtUnitPrice').val(material.UnitPrice);
                        $('#dtCreatedDate').val(material.CreatedDate != null ? convertDateJson(material.CreatedDate) : "");
                        $('#txtInventory').val(material.Inventory);
                        $('#txtDescription').val(material.Description);
                        $('#hiddenID').val(material.ID);
                    }
                }
            })
            $('#SubmitFrmMaterial').text("Sửa");
            $('#infoModal').modal('show');
        });

        $("#SubmitFrmMaterial").off('click').on('click', function () {
            //if ($('#frmMaterialLogInfo').valid()) {
                material.submitFromSaveData();
            //}
        });

        $("#btn-deleteMaterial").off('click').on('click', function () {
            var id = $(this).data('id');
            material.deleteMaterial(id);
        });
        
    },
    submitFromSaveData: function(){
        var name = $('#txtName').val();
        var categoryID = $('#slCategory').val();
        var unitPrice = $('#txtUnitPrice').val();
        var createdDate = $('#dtCreatedDate').val();
        var inventory = $('#txtInventory').val();
        var description = $('#txtDescription').val();
        var id = parseInt($('#hiddenID').val());
        var material = {
            Name: name,
            CategoryID: categoryID,
            UnitPrice: unitPrice,
            CreatedDate: createdDate,
            Inventory: inventory,
            Description: description,
            ID: id
        }

        $.ajax({
            url: '/Material/SubmitForm',
            data: {
                strMaterial: JSON.stringify(material)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    if (response.action) {
                        var dialog = bootbox.dialog({
                            message: 'Thêm thành công',
                            closeButton: false
                        });

                    }
                    else {
                        var dialog = bootbox.dialog({
                            message: 'Sua thanh cong',
                            closeButton: false
                        });
                    }
                    $('#infoModal').modal('hide');
                    dialog.modal('hide');
                    material.loadData(true);

                }
                else {
                    bootbox.alert(response.message);
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    },

    deleteMaterial: function(id){
        $.ajax({
            type: 'GET',
            url: '/Material/Delete',
            dataType: 'JSON',
            data: { id: id },
            success: function (response) {
                if (response.status) {
                    var dialog = bootbox.dialog({
                        message: 'Xóa thành công',
                        closeButton: false
                    });
                }
                else {
                    alert(response.message);
                }
                $('#DeleteConfirmation').modal('hide');
                dialog.modal('hide');
                material.loadData(true);
            }
        })
    },
    resetForm: function(){
        $('#txtName').val("");
        $('#slCategory').reset();
        $('#txtUnitPrice').val("");
        $('#dtCreatedDate').val();
        $('#txtInventory').val();
        $('#txtDescription').val();
        $('#hiddenID').val();
    },
    loadData: function (changePageSize) {
        var keyword = $('#text-search').val();
        var status = $('input[name=optradio]:checked').val();
        var pageSize = $('#comboPageSize').val();   
        $.ajax({
            url: '/Material/LoadData',
            type: 'GET',
            data: {
                keyword: keyword,
                status: status,
                page: pageIndex,
                pageSize: pageSize
            },
            dataType: 'json',
            success: function (response) {
                
                if (response.status) {
                    var data = response.data;
                    var html = '';
                    var bodyTable = $('#bodyTable');

                    pagination_LoadTable(data, bodyTable);

                    material.paging(response.total, function () {
                        material.loadData();
                    }, changePageSize);
                    material.registerEvent();
                }
            },
            error: function () {
                alert("error");
            }
        });
    },
    paging: function (totalRow, callback, changePageSize) {
        var pageSize = $('#comboPageSize').val();
        var totalPage = Math.ceil(totalRow / pageSize);

        //Unbind pagination if it existed or click change pagesize
        if ($('#pagination a').length === 0 || changePageSize === true) {
            $('#pagination').empty();
            $('#pagination').removeData("twbs-pagination");
            $('#pagination').unbind("page");
        }

        $('#pagination').twbsPagination({
            totalPages: totalPage,
            first: "Đầu",
            next: "Tiếp",
            last: "Cuối",
            prev: "Trước",
            visiblePages: 3,
            hideOnlyOnePage: true,
            onPageClick: function (event, page) {
                pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
}
material.init();