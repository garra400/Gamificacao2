using System;
using System.Collections.Generic;
using System.Linq;

namespace gamificacao2.UI;
public class IPromocoes{
    static void MostrarPromocoes(List<Promocao> promocoes)
    {
        Console.WriteLine("\nLISTA DE PROMOÇÕES");
        if (promocoes.Count == 0)
        {
            Console.WriteLine("Não há promoções cadastradas.");
        }
        else
        {
            for (int i = 0; i < promocoes.Count; i++)
            {
                Console.WriteLine($"Promoção {i + 1}: {promocoes[i].ToString()}");
            }
        }
    }

    static void AdicionarPromocao(List<Promocao> promocoes, List<Produto> produtos)
    {
        Console.WriteLine("\nADICIONAR PROMOÇÃO");

        if (produtos.Count == 0)
        {
            Console.WriteLine("Não há produtos cadastrados.");
            return;
        }

        MostrarProdutos(produtos);

        Console.Write("Selecione o número do produto para associar a promoção: ");
        int numeroProduto;
        if (!int.TryParse(Console.ReadLine(), out numeroProduto) || numeroProduto < 1 || numeroProduto > produtos.Count)
        {
            Console.WriteLine("Número de produto inválido. Operação cancelada.");
            return;
        }

        Produto produto = produtos[numeroProduto - 1];

        Console.Write("Desconto da promoção (em porcentagem): ");
        decimal desconto;
        if (!decimal.TryParse(Console.ReadLine(), out desconto) || desconto < 0 || desconto > 100)
        {
            Console.WriteLine("Desconto inválido. Operação cancelada.");
            return;
        }

        Promocao promocao = new Promocao(produto, desconto);
        promocoes.Add(promocao);

        Console.WriteLine("Promoção adicionada com sucesso.");
    }

    static void ModificarPromocao(List<Promocao> promocoes)
    {
        Console.WriteLine("\nMODIFICAR PROMOÇÃO");

        if (promocoes.Count == 0)
        {
            Console.WriteLine("Não há promoções cadastradas.");
            return;
        }

        MostrarPromocoes(promocoes);

        Console.Write("Selecione o número da promoção a ser modificada: ");
        int numeroPromocao;
        if (!int.TryParse(Console.ReadLine(), out numeroPromocao) || numeroPromocao < 1 || numeroPromocao > promocoes.Count)
        {
            Console.WriteLine("Número de promoção inválido. Operação cancelada.");
            return;
        }

        Promocao promocao = promocoes[numeroPromocao - 1];

        Console.Write("Novo Desconto da Promoção (em porcentagem): ");
        decimal novoDesconto;
        if (!decimal.TryParse(Console.ReadLine(), out novoDesconto) || novoDesconto < 0 || novoDesconto > 100)
        {
            Console.WriteLine("Desconto inválido. Operação cancelada.");
            return;
        }

        promocao.Desconto = novoDesconto;

        Console.WriteLine("Promoção modificada com sucesso.");
    }

    static void ExcluirPromocao(List<Promocao> promocoes)
    {
        Console.WriteLine("\nEXCLUIR PROMOÇÃO");

        if (promocoes.Count == 0)
        {
            Console.WriteLine("Não há promoções cadastradas.");
            return;
        }

        MostrarPromocoes(promocoes);

        Console.Write("Selecione o número da promoção a ser excluída: ");
        int numeroPromocao;
        if (!int.TryParse(Console.ReadLine(), out numeroPromocao) || numeroPromocao < 1 || numeroPromocao > promocoes.Count)
        {
            Console.WriteLine("Número de promoção inválido. Operação cancelada.");
            return;
        }

        promocoes.RemoveAt(numeroPromocao - 1);
        Console.WriteLine("Promoção excluída com sucesso.");
    }
}