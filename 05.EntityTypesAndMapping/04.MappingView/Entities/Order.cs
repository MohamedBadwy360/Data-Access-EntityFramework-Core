﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    //[Table("Orders", Schema = "Sales")]
    public class Order
    {
        //[Key]
        public int Id { get; set; }
        public string CustomerEmail { get; set; } = null!;
        public DateTime OrderDate { get; set; }

        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
