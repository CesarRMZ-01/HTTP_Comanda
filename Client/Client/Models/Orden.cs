using System;
using System.Collections.Generic;
using System.Text;

namespace Cliente.Models
{
    public class Orden
    {

        public int Mesa { get; set; }

        public DateTime Fecha { get; set; }

        public List<Productos> Productos { get; set; }

    }
}
