using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetoZara.Common.Model
{
    public class Venta
    {
        public int valorVenta { get; set; }
        public DateTime dateValue { get; set; } = new DateTime(2001, 05, 23);
        public DateTime dateEnd { get; set; } = new DateTime(2017, 12, 01);
        public DateTime viernesdate { get; set; }
        public decimal AccionesTotal { get; set; }
        public string viernesfecha { get; set; }

        public Venta()
        {
        }
        public Venta(int valorVenta)
        {
            this.valorVenta = valorVenta;
            this.dateValue = dateValue;
            this.dateEnd = dateEnd;
            this.viernesdate = viernesdate;
            this.AccionesTotal = AccionesTotal;
            this.viernesfecha = viernesfecha;
        }
    }


}
