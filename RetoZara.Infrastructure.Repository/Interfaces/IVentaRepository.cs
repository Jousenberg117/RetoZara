using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetoZara.Common.Model;

namespace RetoZara.Infrastructure.Repository.Interfaces
{
    public interface IVentaRepository
    {
        DateTime Viernes(DateTime dateValue);
        decimal Acciones(Decimal consultaValorCompra);
        void CalcularVenta(decimal ValorVenta, decimal totalAcciones);
    }
}
