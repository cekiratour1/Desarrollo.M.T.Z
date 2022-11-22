using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DesarrolloMTZ.Models
{
    public class Desarrollo_MTZ_MV
    {
        public string mensaje { get; set; }
        public DatosInput datosI { get; set; }
        public DatosOutput datosO { get; set; }

    }
}