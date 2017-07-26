﻿using CoffeeShop.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model.Models
{
    [Table("Shops")]
    public class Shop : Auditable
    {
        [Required]
        public int WardID { get; set; }
        [MaxLength(256)]
        public string DetailAddress { get; set; }

        [ForeignKey("WardID")]
        public virtual Ward Ward { get; set; }
    }
}