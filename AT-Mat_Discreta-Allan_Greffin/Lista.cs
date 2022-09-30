using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_Mat_Discreta_Allan_Greffin
{
    public class Lista<T> where T : IPrintable
    {
        public int Tamanho { get; set; }
        public No<T> Primeiro { get; set; }
        public No<T> Ultimo { get; set; }

        public Lista()
        {
            Tamanho = 0;
            Primeiro = null;
            Ultimo = null;
        }

        public T? ProcurarPorId(int id)
        {
            No<T> atual = Primeiro;
            while (atual != null)
            {
                if (atual.Item.Id == id)
                {
                    return atual.Item;
                }
                atual = atual.Proximo;
            }
            return default(T);
        }

        public void Inserir(T item)
        {
            No<T> novo = new No<T>(item);
            if (Tamanho == 0)
            {
                Primeiro = novo;
                Ultimo = novo;
            }
            else
            {
                Ultimo.Proximo = novo;
                Ultimo = novo;
            }
            Tamanho++;
        }

        public No<T> Buscar(T item)
        {
            No<T> result = null;
            if (Tamanho > 0)
            {
                No<T> atual = Primeiro;
                while (atual != null)
                {
                    if (atual.Item.Equals(item))
                    {
                        result = atual;
                        break;
                    }
                    atual = atual.Proximo;
                }
            }
            return result;
        }

        public void Remover(T item)
        {
            if (Tamanho > 0)
            {
                No<T> atual = Primeiro;
                No<T> anterior = null;
                while (atual != null)
                {
                    if (atual.Item.Equals(item))
                    {
                        if (atual == Primeiro)
                        {
                            Primeiro = atual.Proximo;
                            Tamanho--;
                        }
                        else if (atual == Ultimo)
                        {
                            anterior.Proximo = null;
                            Ultimo = anterior;
                            Tamanho--;
                        }
                        else
                        {
                            anterior.Proximo = atual.Proximo;
                            Tamanho--;
                        }
                        break;
                    }
                    anterior = atual;
                    atual = atual.Proximo;
                }
            }
        }

        public void Imprimir()
        {
            if (Tamanho > 0)
            {
                No<T> atual = Primeiro;
                while (atual != null)
                {
                    Console.WriteLine(atual.Item);
                    atual = atual.Proximo;
                }
            }
        }
    }
}

