﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInsurance.Application.Dtos
{
    public class UpdateVehicleDto
    {
        [StringLength(50)]
        public string LicensePlate { get; set; }

        [StringLength(100)]
        public string Model { get; set; }

        [Range(1900, 2100)]
        public int? Year { get; set; }

        [StringLength(50)]
        public string Make { get; set; }
    }
}
