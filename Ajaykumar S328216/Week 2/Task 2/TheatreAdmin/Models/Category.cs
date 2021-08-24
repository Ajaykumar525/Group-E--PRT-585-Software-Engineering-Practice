﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TheatreAdmin.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}