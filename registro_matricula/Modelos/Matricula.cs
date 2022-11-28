using System;
using System.Collections.Generic;
using System.Text;

namespace registro_matricula.Modelos
{
    [Serializable]
    public class Matricula
    {
        public string nombre { get; set; }
        public string TipoMatricula { get; set; }
        public string estado_alumno { get; set; }
        public string Fecha_matricula { get; set; }

        public double descuento { get; set; }

        public double recargo { get; set; }

        public double monto_total { get; set; }

        public void calculo_descuento()
        { 
          if (TipoMatricula== "nuevo ingreso")
            {
                descuento = 0.30;
                recargo = 0.0;
            } else if (TipoMatricula== "reingreso" )
            {
                descuento = 0.00;
                recargo = 0.0;
            } else if (TipoMatricula== "ordinaria")
            {
                descuento = 0.20;
                recargo = 0.0;
            }
            else if (TipoMatricula == "extraordinaria")
            {
                recargo = 0.20;
                descuento = 0.0;
            }
        }
        public void calculo_montototal()
        {
            calculo_descuento();
            if (TipoMatricula== "nuevo ingreso"|| TipoMatricula == "ordinaria"|| TipoMatricula=="reingreso")
            {
                monto_total = 5000 - (5000 * descuento);
            }
            else
            {
                monto_total = 5000 + (5000 * recargo);
            }

        }
        public void calculo_estado()
        {
            if (TipoMatricula == "nuevo ingreso")
            {
                estado_alumno = "inactivo";
            }
            else if (TipoMatricula == "reingreso")
            {
                estado_alumno = "inactivo";
            }
            else if (TipoMatricula == "ordinaria")
            {
                estado_alumno = "activo";
            }
            else if (TipoMatricula == "extraordniaria")
            {
                estado_alumno = "activo"; ;
            }

        }
        public string toString()
        {

            return 

                    "La matricula de: " + nombre+ " con cuenta "+ estado_alumno + System.Environment.NewLine
                      + " con un descuento de : " + descuento+ " y un monto total de: "+ monto_total+ System.Environment.NewLine+
                    "se ha realizado con exito la fecha: " + Fecha_matricula +  "con un recargo de: "+ recargo;
        }
    }
}
