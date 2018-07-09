using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetoZara.Common.Model;
using RetoZara.Infrastructure.Repository.Interfaces;

namespace RetoZara.Infrastructure.Repository.Repository
{
    public class VentaRepository : IVentaRepository
    {
        public decimal AccionesTotal { get; set; }
        public string viernesfecha { get; set; }
        public DateTime viernesdate { get; set; }
        public void Viernes(DateTime dateValue)
        {
            DateTime fecha = Data.GetLastFridayOfTheMonth(dateValue);
            viernesdate = fecha;
            viernesfecha = fecha.ToString("dd-MMM-yyyy").Replace(".", "");
        }

        public void Acciones(Decimal consultaValorCompra)
        {
            decimal Acciones = CalcularCompra.CalcularAcciones(consultaValorCompra);
            AccionesTotal = AccionesTotal + Acciones;
        }

        public decimal CalcularVenta(decimal ValorVenta, decimal totalAcciones)
        {
            decimal capitalFinal = ValorVenta * totalAcciones;
            return Math.Round(capitalFinal, 3);
        }


        public Venta Calcular(Venta venta)
        {
            throw new NotImplementedException();
        }

    }
}
