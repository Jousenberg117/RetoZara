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
        DiaDeCompra firstSubsystem = new DiaDeCompra();
        FileManager secondSubsystem = new FileManager();
        VentaRepository thirdSubsystem = new VentaRepository();
        
        decimal accionesTotalFinal = 0.000M;
        string viernesConsulta;
        decimal consultaValorCompra = 0.000M;
        decimal consultaValorVenta = 0.000M;
         public decimal  OperacionValorVenta()
        {
            for (DateTime date = Venta.dateValue; date < Venta.dateEnd;)
            {
                OperacionFecha();
                OperacionConsulta();
                OperacionCompra();
                Venta.dateValue = Venta.dateValue.AddDays(15);
                date = Venta.dateValue;
            }
            OperacionVenta();
            return Venta.capitalFinal;
         }

        public void OperacionFecha()

        {           
            Venta.dateValue = firstSubsystem.diaCompra(Venta.dateValue);
        }
        public void OperacionConsulta()

        {
            do
            {
                DateTime otroDia = Venta.dateValue;
                viernesConsulta = otroDia.ToString("dd-MMM-yyyy").Replace(".", "");
                secondSubsystem.consultaFechaCompra(viernesConsulta);
                if (viernesConsulta != secondSubsystem.consultaViernes)
                    Venta.dateValue = Venta.dateValue.AddDays(1);
            }
            while (viernesConsulta != secondSubsystem.consultaViernes);
            consultaValorCompra = Convert.ToDecimal(secondSubsystem.consultaValorCompra.Replace(".", ","));
            consultaValorCompra = Math.Round(consultaValorCompra, 3);
        }
        public void OperacionCompra()

        {
            accionesTotalFinal = thirdSubsystem.Acciones(consultaValorCompra);
        }
        public void OperacionVenta()

        {
            secondSubsystem.consultaFechaVenta(Venta.dateVenta.ToString("dd-MMM-yyyy").Replace(".", ""));
            consultaValorVenta = Convert.ToDecimal(secondSubsystem.consultaValorVenta.Replace(".", ","));
            consultaValorVenta = Math.Round(consultaValorVenta, 3);
            thirdSubsystem.CalcularVenta(consultaValorVenta, accionesTotalFinal);
        }
    }
}


