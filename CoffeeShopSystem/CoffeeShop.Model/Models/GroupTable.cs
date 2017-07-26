﻿using CoffeeShop.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model.Models
{
    [Table("GroupTables")]
    public class GroupTable : Auditable
    {
        public string Surcharge { get; set; }

        public virtual IEnumerable<Table> Tables { get; set; }
    }
}