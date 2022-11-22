using DesarrolloMTZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Web;


namespace DesarrolloMTZ.Logica
{
    public class LogicaMTZ
    {
        private const double gravedad = 9.807;
        private double torque = 0;
        private double velocidadC = 0;


        public LogicaMTZ()
        {
        }
        private double redondear(double valor, int n)
        {
            var x = valor * Math.Pow(10, n);
            x = Math.Round(x);
            return (x/ Math.Pow(10,n));
        }

        public Desarrollo_MTZ_MV Calcular(Desarrollo_MTZ_MV desarrollo_MTZ)
        {
            desarrollo_MTZ.datosO = new DatosOutput();
            desarrollo_MTZ.datosO.peso_neto_vehiculo = redondear(desarrollo_MTZ.datosI.masa_vehiculo * gravedad,2);
            desarrollo_MTZ.datosO.peso_carga = redondear(desarrollo_MTZ.datosI.masa_carga * gravedad,2);
            desarrollo_MTZ.datosO.peso_total_vehiculo = redondear(desarrollo_MTZ.datosO.peso_neto_vehiculo + desarrollo_MTZ.datosO.peso_carga, 2);
            desarrollo_MTZ.datosO.max_velocidad = redondear(desarrollo_MTZ.datosI.distancia / desarrollo_MTZ.datosI.tiempo, 2);
            desarrollo_MTZ.datosO.max_aceleracion = redondear(desarrollo_MTZ.datosO.max_velocidad / desarrollo_MTZ.datosI.tiempo, 2);
            desarrollo_MTZ.datosO.fuerza_atraccion = Math.Abs(redondear(desarrollo_MTZ.datosO.peso_total_vehiculo * Math.Sin(desarrollo_MTZ.datosI.angulo_calle),2));
            desarrollo_MTZ.datosO.fuerza_neta = Math.Abs(redondear(desarrollo_MTZ.datosO.max_aceleracion * Math.Sin(desarrollo_MTZ.datosI.angulo_calle)* (desarrollo_MTZ.datosI.masa_carga + desarrollo_MTZ.datosI.masa_vehiculo),2));
            desarrollo_MTZ.datosO.fuerza_impulso_req = Math.Abs(redondear((desarrollo_MTZ.datosO.fuerza_atraccion + desarrollo_MTZ.datosO.fuerza_neta),2));
            torque = redondear((desarrollo_MTZ.datosO.fuerza_neta * (desarrollo_MTZ.datosI.distancia/1000)), 2);
            desarrollo_MTZ.datosO.potencia_req = Math.Abs(redondear(((torque)/(60 * (2 * Math.PI))),2));
            desarrollo_MTZ.datosO.combustible_req = Math.Abs(redondear((desarrollo_MTZ.datosI.distancia/1000) * (desarrollo_MTZ.datosI.consumo_combustible/1000),2));
            velocidadC = redondear((Math.PI * desarrollo_MTZ.datosI.distancia * desarrollo_MTZ.datosO.fuerza_neta)/1000,2);
            desarrollo_MTZ.datosO.revoluciones_req = Math.Abs(redondear((1000*velocidadC)/(Math.PI * desarrollo_MTZ.datosI.distancia),2));

            if (desarrollo_MTZ.datosO.potencia_req > desarrollo_MTZ.datosI.max_potencia)
            {
                desarrollo_MTZ.mensaje = "No es posible realizar el desplazamiento, la potencia actual no es suficiente";
               // desarrollo_MTZ.datosO = null;
                return desarrollo_MTZ;
            }
            if (desarrollo_MTZ.datosO.combustible_req > desarrollo_MTZ.datosI.nivel_combustible)
            {
                desarrollo_MTZ.mensaje = "No es posible realizar el desplazamiento, el nivel de combustible no es suficiente";
                //desarrollo_MTZ.datosO = null
                return desarrollo_MTZ; 
            }

            return desarrollo_MTZ;
        }

    }
}