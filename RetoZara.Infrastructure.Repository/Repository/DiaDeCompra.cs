using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetoZara.Infrastructure.Repository.Interfaces;

namespace RetoZara.Infrastructure.Repository.Repository
{
    public class DiaDeCompra : IDiaDeCompra
    {
        DateTime compraDate;
        public DateTime diaCompra(DateTime dateValue)
        {
            DateTime fecha = Date.GetLastThursdayOfTheMonth(dateValue);
            compraDate = fecha.AddDays(1);
            return compraDate;
        }
    }
}
