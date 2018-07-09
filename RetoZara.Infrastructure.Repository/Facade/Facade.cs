using RetoZara.Common.Model;
using RetoZara.Infrastructure.Repository.Manager;
using RetoZara.Infrastructure.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetoZara.Infrastructure.Repository.Facade
{
    public class Facade
    {
        VentaRepository firstSubsystem = new VentaRepository();
        FileManager secondSubsystem = new FileManager();
       
        decimal accionesTotalFinal;
        string viernesConsulta;
        decimal consultaValorCompra;
        decimal consultaValorVenta;
        decimal capitalFinal;
         DateTime dateValue = new DateTime(2001, 05, 23);
         DateTime dateEnd= new DateTime(2017, 12, 01);
         DateTime dateVenta = new DateTime(2017, 12, 28);
         public decimal  OperacionValorVenta()
        {
            for (DateTime date = dateValue; date < dateEnd;)
            {
                OperacionFecha();
                OperacionConsulta();
                OperacionCompra();
                dateValue = dateValue.AddMonths(1);
                date = date.AddMonths(1);
            }
            OperacionVenta();
            return capitalFinal;
         }

        public void OperacionFecha()

        {
            firstSubsystem.Viernes(dateValue);
            dateValue = firstSubsystem.viernesdate;
            viernesConsulta = firstSubsystem.viernesfecha;
        }
        public void OperacionConsulta()

        {
            secondSubsystem.consultaFechaCompra(viernesConsulta);
            consultaValorCompra = Convert.ToDecimal(secondSubsystem.consultaValorCompra.Replace(".", ","));
            consultaValorCompra = Math.Round(consultaValorCompra, 3);
        }
        public void OperacionCompra()

        {
            firstSubsystem.Acciones(consultaValorCompra);
            accionesTotalFinal = firstSubsystem.AccionesTotal;
        }
        public decimal OperacionVenta()

        {
            secondSubsystem.consultaFechaVenta(dateVenta.ToString("dd-MMM-yyyy").Replace(".", ""));
            consultaValorVenta = Convert.ToDecimal(secondSubsystem.consultaValorVenta.Replace(".", ","));
            consultaValorVenta = Math.Round(consultaValorVenta, 3);
            capitalFinal = firstSubsystem.CalcularVenta(consultaValorVenta, accionesTotalFinal);
            return capitalFinal;
        }
    }
}


