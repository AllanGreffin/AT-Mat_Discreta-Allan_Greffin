using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_Mat_Discreta_Allan_Greffin
{
    public class Local : IPrintable
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public AT_Mat_Discreta_Allan_Greffin.Stack<ItemEntrega> ItensEntrega { get; set; }

        public Local(string nome, int id)
        {
            Id = id;
            Nome = nome;
            ItensEntrega = new Stack<ItemEntrega>();
        }

        public void Print()
        {
            ItemEntrega itemAtual = ItensEntrega.Pop();
            if(itemAtual != null)
            {
                Console.WriteLine($"Visitado ponto de entrega {itemAtual.Nome}. Foram Entregues:");
            }
            while (itemAtual != null)
            {
                itemAtual.Print();
                itemAtual = ItensEntrega.Pop();
            }
        }
    }
}
