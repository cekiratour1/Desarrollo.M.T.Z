using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DesarrolloMTZ.Models
{
    public class DatosInput
    {
        [Required]
        public double nivel_combustible { get; set; }
        [Required]
        public double masa_vehiculo { get; set; }
        [Required]
        public double masa_carga { get; set; }
        [Required]
        public int angulo_calle { get; set; }
        [Required]
        public double distancia { get; set; }
        [Required]
        public double tiempo { get; set; }
        [Required]
        public double max_rpm { get; set; }
        [Required]
        public double max_potencia { get; set; }
        [Required]
        public double consumo_combustible { get; set; }
    }
}