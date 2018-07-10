using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetoZara.Common.Model
{
    public class Venta
    {
        public static decimal capitalFinal { get; set; }
        public static DateTime dateVenta { get; set; } = new DateTime(2017, 12, 28);
        public static DateTime dateValue { get; set; } = new DateTime(2001, 05, 23);
        public static DateTime dateEnd { get; set; } = new DateTime(2017, 12, 01);

        public Venta()
        {
        }
    }


}
