using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RetoZara.Infrastructure.Repository.Facade;


namespace RetoZara.Presentation.WinSite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void ButtonCalcular(object sender, EventArgs e)
        {
            Facade facade = new Facade();
            decimal capitalFinal;
            capitalFinal = facade.OperacionValorVenta();
            MessageBox.Show("El capital final a vender con fecha 28/12/2017 fue:" + "  " + capitalFinal.ToString());
        }
    }
}
