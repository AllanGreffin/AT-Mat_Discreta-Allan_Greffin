// See https://aka.ms/new-console-template for more information

using AT_Mat_Discreta_Allan_Greffin;

class Program
{
    static void Main(string[] args)
    {
        Lista<Caminhao> caminhoes = new Lista<Caminhao>();
        Lista<Local> locais = new Lista<Local>();
        Lista<Local> locaisDisponiveis = new Lista<Local>();
        Lista<ItemEntrega> itensEntregaDisponiveis = new Lista<ItemEntrega>();

        var ultimoIdLocal = 1;
        var ultimoIdItem = 1;
        var ultimoIdCaminhao = 1;

        var loop = true;
        while (loop)
        {
            {
                Console.WriteLine("1. Inserir ponto de entrega");
                Console.WriteLine("2. Inserir item de entrega");
                Console.WriteLine("3. Inserir caminhão");
                Console.WriteLine("4. Associar item a ponto de entrega");
                Console.WriteLine("5. Associar ponto de entrega a caminhão");
                Console.WriteLine("6. Realizar entregas");
                Console.WriteLine("0. Sair");
                Console.WriteLine("Escolha uma opção");
                var opcao = Convert.ToInt32(Console.ReadLine());

                Local pontoDeEntrega = null;
                ItemEntrega itemEntrega = null;
                Caminhao caminhao = null;

                int localId;
                int caminhaoId;

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite o nome do local");
                        var nomeLocal = Console.ReadLine();
                        var local = new Local(nomeLocal, ultimoIdLocal++);
                        locais.Inserir(local);
                        locaisDisponiveis.Inserir(local);
                        Console.WriteLine("Inserido com sucesso!");
                        break;
                    case 2:
                        Console.WriteLine("Digite o nome do item");
                        var nomeItem = Console.ReadLine();
                        var item = new ItemEntrega(nomeItem, ultimoIdItem++);
                        itensEntregaDisponiveis.Inserir(item);
                        Console.WriteLine("Inserido com sucesso!");
                        break;
                    case 3:
                        Console.WriteLine("Digite a placa do caminhão");
                        var placa = Console.ReadLine();
                        caminhao = new Caminhao(ultimoIdCaminhao++, placa);
                        caminhoes.Inserir(caminhao);
                        Console.WriteLine("Inserido com sucesso!");
                        break;
                    case 4:
                        Console.WriteLine("Associando item à ponto de entrega:");
                        Console.WriteLine("Digite o id do item:");
                        var itemId = Convert.ToInt32(Console.ReadLine());
                        itemEntrega = itensEntregaDisponiveis.ProcurarPorId(itemId);
                        if(itemEntrega == null)
                        {
                            Console.WriteLine("Não foi encontrado item com o id informado");
                            break;
                        }
                        Console.WriteLine("Digite o id do ponto de entrega:");
                        localId = Convert.ToInt32(Console.ReadLine());
                        pontoDeEntrega = locais.ProcurarPorId(localId);
                        if (pontoDeEntrega == null)
                        {
                            Console.WriteLine("Não foi encontrado ponto de entrega com o id informado");
                            break;
                        }
                        pontoDeEntrega.ItensEntrega.Push(itemEntrega);
                        itensEntregaDisponiveis.Remover(itemEntrega);
                        Console.WriteLine("Adiciona com sucesso!");
                        break;

                    case 5:
                        Console.WriteLine("Digite o id do ponto de entrega:");
                        localId = Convert.ToInt32(Console.ReadLine());
                        pontoDeEntrega = locais.ProcurarPorId(localId);
                        if (pontoDeEntrega == null)
                        {
                            Console.WriteLine("Não foi encontrado ponto de entrega com o id informado");
                            break;
                        }

                        Console.WriteLine("Digite o id do caminhão:");
                        caminhaoId = Convert.ToInt32(Console.ReadLine());
                        caminhao = caminhoes.ProcurarPorId(caminhaoId);
                        if (caminhao == null)
                        {
                            Console.WriteLine("Não foi encontrado caminhão com o id informado");
                            break;
                        }
                        caminhao.Locais.Inserir(pontoDeEntrega);
                        for (int i = 0; i < pontoDeEntrega.ItensEntrega.Top + 1; i++)
                        {
                            caminhao.ItensEntrega.Push(pontoDeEntrega.ItensEntrega.Items[i]);
                        }
                        locaisDisponiveis.Remover(pontoDeEntrega);
                        Console.WriteLine("Adiciona com sucesso!");
                        break;

                    case 6:

                        if(locaisDisponiveis.Tamanho > 0)
                        {
                            int quantidadeDeLocaisDisponiveis = locaisDisponiveis.Tamanho;
                            for (int i = 0; i < quantidadeDeLocaisDisponiveis; i++)
                            {
                                No<Caminhao> caminhaoMaisVazio = caminhoes.Primeiro;
                                No<Caminhao> caminhaoDoLoop = caminhoes.Primeiro;

                                for (int j = 0; j < caminhoes.Tamanho - 1; j++)
                                {
                                    caminhaoDoLoop = caminhaoDoLoop.Proximo;
                                    if(caminhaoDoLoop.Item.Locais.Tamanho < caminhaoMaisVazio.Item.Locais.Tamanho)
                                    {
                                        caminhaoMaisVazio = caminhaoDoLoop;
                                    }
                                }

                                caminhaoMaisVazio.Item.Locais.Inserir(locaisDisponiveis.Primeiro.Item);
                                var quantidadeDeItensEntregaNoLocal = locaisDisponiveis.Primeiro.Item.ItensEntrega.Top + 1;
                                for (int k = 0; k < quantidadeDeItensEntregaNoLocal; k++)
                                {
                                    ItemEntrega? itensEntreguesDoLocal = locaisDisponiveis.Primeiro.Item.ItensEntrega.Pop();
                                    caminhaoMaisVazio.Item.ItensEntrega.Push(itensEntreguesDoLocal);
                                }
                                locaisDisponiveis.Remover(locaisDisponiveis.Primeiro.Item);
                            }
                        }

                        int totalDePontosDeEntrega = 0;
                        int totalDeItensEntregues = 0;

                        var caminhaoAtual = caminhoes.Primeiro;
                        for (int i = 0; i < caminhoes.Tamanho; i++)
                        {
                            Console.WriteLine("#############################");
                            caminhaoAtual.Item.Print();

                            totalDePontosDeEntrega += caminhaoAtual.Item.Locais.Tamanho;
                            totalDeItensEntregues += caminhaoAtual.Item.ItensEntrega.Top + 1;
                            caminhaoAtual = caminhaoAtual.Proximo;
                        }

                        Console.WriteLine($"Total de pontos de entrega: {totalDePontosDeEntrega}");
                        Console.WriteLine($"Total de itens entregues: {totalDeItensEntregues}");

                        break;

                    case 0:
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Escolha outra opção...");
                        break;
                }
            }
        }


    }
}



