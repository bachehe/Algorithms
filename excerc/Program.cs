using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace exerc
{
    class Program
    {
        public static void Main(string[] args)
        {
            var invoke = new Invoke();
            invoke.Invoker();
            invoke.Recaper();
        }   
    }
}