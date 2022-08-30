using Pea.Dominio;
using Pea2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pea2.Logic
{
    public static class CategoriaBL
    {
        public static List<Categoria> Listar()
        {
            var CategoriaData1 = new CategoriaData();
            return CategoriaData1.Listar();
        }


    }


}
