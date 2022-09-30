namespace AT_Mat_Discreta_Allan_Greffin
{
    public class Caminhao : IPrintable
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public Lista<Local> Locais { get; set; }
        public AT_Mat_Discreta_Allan_Greffin.Stack<ItemEntrega> ItensEntrega { get; set; }

        public Caminhao(int id, string placa)
        {
            Id = id;
            Placa = placa;
            ItensEntrega = new Stack<ItemEntrega>();
            Locais = new Lista<Local>();
        }

        public void Print()
        {
            Console.WriteLine("Nome caminhão: " + Placa);
            Console.WriteLine("Id caminhão: " + Id);

            No<Local> localAtual = Locais.Primeiro;
            for (int i = 0; i < Locais.Tamanho; i++)
            {
                localAtual.Item.Print();
                localAtual = localAtual.Proximo;
            }
        }
    }
}
