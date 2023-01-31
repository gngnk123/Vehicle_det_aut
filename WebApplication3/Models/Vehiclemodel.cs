using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleDet.Models
{
    public class Vehiclemodel
    {
        public int Id { get; set; }
        [Display(Name = "Car Id")]
        [Required(ErrorMessage = "Enter Id")]
        public int CarId { get; set; }

        [Display(Name = "Make")]
        [Required(ErrorMessage = "Enter car maker")]
        public string Make { get; set; }

        [Display(Name = "Model")]
        [Required(ErrorMessage = "Enter car model")]
        public string C_Model { get; set; }

        [Display(Name = "Year")]
        [Range(1800, 2023, ErrorMessage = " Enter valid year")]
        public int Year { get; set; }

        [Display(Name = "Odo")]
        [Range(0, 2000000, ErrorMessage = " Enter valid odo")]
        public int Odo { get; set; }

        [Display(Name = "Color")]
        public string Color { get; set; }

        [Display(Name = "Engine")]
        public int Engine { get; set; }

        public int Count { get; set; }
    }
}