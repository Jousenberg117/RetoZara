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
         public decimal  OperacionValorVenta()
        {
            for (DateTime date = Venta.dateValue; date < Venta.dateEnd;)
            {
                OperacionFecha();
                OperacionConsulta();
                OperacionCompra();
                Venta.dateValue = Venta.dateValue.AddMonths(1);
                date = date.AddMonths(1);
            }
            OperacionVenta();
            return Venta.capitalFinal;
         }

        public void OperacionFecha()

        {           
            Venta.dateValue = firstSubsystem.Viernes(Venta.dateValue);
            viernesConsulta = firstSubsystem.Viernes(Venta.dateValue).ToString("dd-MMM-yyyy").Replace(".", "");
        }
        public void OperacionConsulta()

        {
            secondSubsystem.consultaFechaCompra(viernesConsulta);
            consultaValorCompra = Convert.ToDecimal(secondSubsystem.consultaValorCompra.Replace(".", ","));
            consultaValorCompra = Math.Round(consultaValorCompra, 3);
        }
        public void OperacionCompra()

        {
            accionesTotalFinal = firstSubsystem.Acciones(consultaValorCompra);
        }
        public void OperacionVenta()

        {
            secondSubsystem.consultaFechaVenta(Venta.dateVenta.ToString("dd-MMM-yyyy").Replace(".", ""));
            consultaValorVenta = Convert.ToDecimal(secondSubsystem.consultaValorVenta.Replace(".", ","));
            consultaValorVenta = Math.Round(consultaValorVenta, 3);
            firstSubsystem.CalcularVenta(consultaValorVenta, accionesTotalFinal);
        }
    }
}


