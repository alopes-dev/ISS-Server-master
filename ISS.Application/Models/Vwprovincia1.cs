﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class Vwprovincia1
    {
        public int? QtdSinistro { get; set; }
        [StringLength(100)]
        public string Provincia { get; set; }
        public bool? IsPago { get; set; }
    }
}