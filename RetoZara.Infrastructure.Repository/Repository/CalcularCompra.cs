using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetoZara.Infrastructure.Repository.Repository
{
    class CalcularCompra
    {
        public static decimal CalcularAcciones(Decimal consultaValorCompra)
        {
            decimal capital = 50.000M;
            decimal comision = 2.000M;
            decimal inversion = capital - (capital * (comision / 100));
            decimal totalAccionesCompradas = (Math.Round(inversion, 3) / Math.Round(consultaValorCompra));
            return Math.Round(totalAccionesCompradas, 3);
        }
    }
}
