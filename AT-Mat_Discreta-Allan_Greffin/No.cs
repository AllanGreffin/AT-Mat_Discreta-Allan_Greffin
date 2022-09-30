using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AT_Mat_Discreta_Allan_Greffin
{
    public class No<T>
    {
        public T Item { get; set; }
        public No<T> Proximo { get; set; }

        public No(T item)
        {
            Item = item;
        }
    }
}
