using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLL;
using DAL;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Pais p = new Pais();

            Console.Write("Digite um nome de pais: ");
            p.NomePais = Console.ReadLine();

            PaisDAL pd = new PaisDAL();

            pd.Cadastrar(p);

            Console.ReadKey();
        }
    }
}
