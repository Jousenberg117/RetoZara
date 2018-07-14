using System;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RetoZara.Infrastructure.Repository.Manager
{
    public class FileManager
    {
        static string path = ConfigurationManager.AppSettings.Get("path");
        public string consultaValorCompra{ get; set; }
        public string consultaValorVenta { get; set; }
        public string consultaViernes { get; set; }


        public void consultaFechaCompra(string date)
        {
            var reader = new StreamReader(path);
           
            List<string> listA = new List<string>();

            List<string> listB = new List<string>();

            List<string> listC = new List<string>();


            do
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                listA.Add(values[0]);
                listB.Add(values[1]);
                listC.Add(values[2]);
                consultaViernes = values[0];
                consultaValorCompra = values[2];
            }
            while (consultaViernes.ToString() != date && !reader.EndOfStream);
        }
        public void consultaFechaVenta(string date)
        {
            string consultaFechaVenta;

            var reader = new StreamReader(path);

            List<string> listA = new List<string>();

            List<string> listB = new List<string>();

            List<string> listC = new List<string>();
            do
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                listA.Add(values[0]);
                listB.Add(values[1]);
                listC.Add(values[2]);
                consultaFechaVenta = values[0];
                consultaValorVenta = values[1];
            }
            while (consultaFechaVenta.ToString() != date && !reader.EndOfStream || consultaValorCompra == "");
        }
    }
}

