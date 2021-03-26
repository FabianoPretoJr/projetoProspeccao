using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class ErrosView
    {
        public ErrosView()
        {
            this.Erros = new List<string>();
        }

        public List<string> Erros { get; set; }
    }
}
