﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public Cart Cart { get; set; }
        [ForeignKey("UserHistoryFK")]
        public List<Cart> HistoryOfOrders { get; set; }
    }
}
