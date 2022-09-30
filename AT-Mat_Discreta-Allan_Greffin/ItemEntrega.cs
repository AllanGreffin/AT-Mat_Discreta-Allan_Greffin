using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_Mat_Discreta_Allan_Greffin
{
    public class ItemEntrega : IPrintable
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ItemEntrega(string nome, int id)
        {
            Id = id;
            Nome = nome;
        }

        public void Print()
        {
            Console.WriteLine("Nome item entrega: " + Nome + " | Id: " + Id);
        }
    }
}
