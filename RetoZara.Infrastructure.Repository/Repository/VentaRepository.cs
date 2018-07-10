﻿using System;
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
        decimal AccionesTotal;
        DateTime viernesdate;
        public DateTime Viernes(DateTime dateValue)
        {
            DateTime fecha = Data.GetLastFridayOfTheMonth(dateValue);
            viernesdate = fecha;
            return viernesdate;
        }

        public decimal Acciones(Decimal consultaValorCompra)
        {
            decimal Acciones = CalcularCompra.CalcularAcciones(consultaValorCompra);
            AccionesTotal = AccionesTotal + Acciones;
            return Math.Round(AccionesTotal, 3);
        }
        public void CalcularVenta(decimal ValorVenta, decimal totalAcciones)
        {
           Venta.capitalFinal = Math.Round((ValorVenta * totalAcciones), 3);
        }

    }
}
