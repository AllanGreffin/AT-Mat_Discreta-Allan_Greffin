using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_Questao4
{
    public class AssinaturaDeTipoDePacote
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Tipo { get; set; }

        public AssinaturaDeTipoDePacote(string nome, int tipo)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Tipo = tipo;
        }
    }
}
