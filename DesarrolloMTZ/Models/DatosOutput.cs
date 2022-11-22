using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DesarrolloMTZ.Models
{
    public class DatosOutput
    {
        
        public double peso_neto_vehiculo { get; set; }
        
        public double peso_carga { get; set; }
        
        public double peso_total_vehiculo { get; set; }
        
        public double max_velocidad { get; set; }
        
        public double max_aceleracion { get; set; }
        
        public double fuerza_atraccion { get; set; }
        
        public double fuerza_neta { get; set; }
        
        public double fuerza_impulso_req { get; set; }
        
        public double revoluciones_req { get; set; }
        
        public double potencia_req { get; set; }
        
        public double combustible_req { get; set; }

    }
}