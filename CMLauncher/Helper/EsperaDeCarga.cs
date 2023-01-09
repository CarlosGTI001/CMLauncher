using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMLauncher.Helper
{
    public class EsperaDeCarga
    {
        private readonly string message;

        public EsperaDeCarga(string msg)
        {
            this.message = msg;
        }

        public string Message { get { return message; } }
    }
}
