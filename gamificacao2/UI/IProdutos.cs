using System;
using System.Collections.Generic;
using System.Linq;

namespace gamificacao2.UI;
public class IProduto{
    static void GerenciarProdutos(List<Produto> produtos)
    {
        while (true)
        {
            Console.WriteLine("\nGERENCIAR PRODUTOS");
            Console.WriteLine("1 - Mostrar Produtos");
            Console.WriteLine("2 - Adicionar Produto");
            Console.WriteLine("3 - Modificar Produto");
            Console.WriteLine("4 - Excluir Produto");
            Console.WriteLine("0 - Voltar");

            Console.Write("Opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    MostrarProdutos(produtos);
                    break;
                case "2":
                    AdicionarProduto(produtos);
                    break;
                case "3":
                    ModificarProduto(produtos);
                    break;
                case "4":
                    ExcluirProduto(produtos);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Digite novamente.");
                    break;
            }
        }
    }

    static void MostrarProdutos(List<Produto> produtos)
    {
        Console.WriteLine("\nLISTA DE PRODUTOS");
        if (produtos.Count == 0)
        {
            Console.WriteLine("Não há produtos cadastrados.");
        }
        else
        {
            for (int i = 0; i < produtos.Count; i++)
            {
                Console.WriteLine($"Produto {i + 1}: {produtos[i].ToString()}");
            }
        }
    }

    static void AdicionarProduto(List<Produto> produtos)
    {
        Console.WriteLine("\nADICIONAR PRODUTO");

        Console.Write("Nome do Produto: ");
        string nome = Console.ReadLine();

        Console.Write("Preço do Produto: ");
        decimal preco;
        if (!decimal.TryParse(Console.ReadLine(), out preco))
        {
            Console.WriteLine("Preço inválido. Operação cancelada.");
            return;
        }

        Console.Write("Quantidade do Produto: ");
        int quantidade;
        if (!int.TryParse(Console.ReadLine(), out quantidade))
        {
            Console.WriteLine("Quantidade inválida. Operação cancelada.");
            return;
        }

        Produto produto = new Produto(nome, preco, quantidade);
        produtos.Add(produto);

        Console.WriteLine("Produto adicionado com sucesso.");
    }

    static void ModificarProduto(List<Produto> produtos)
    {
        Console.WriteLine("\nMODIFICAR PRODUTO");

        if (produtos.Count == 0)
        {
            Console.WriteLine("Não há produtos cadastrados.");
            return;
        }

        MostrarProdutos(produtos);

        Console.Write("Selecione o número do produto a ser modificado: ");
        int numeroProduto;
        if (!int.TryParse(Console.ReadLine(), out numeroProduto) || numeroProduto < 1 || numeroProduto > produtos.Count)
        {
            Console.WriteLine("Número de produto inválido. Operação cancelada.");
            return;
        }

        Produto produto = produtos[numeroProduto - 1];

        Console.Write("Novo Nome do Produto: ");
        string novoNome = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(novoNome))
        {
            produto.Nome = novoNome;
        }

        Console.Write("Novo Preço do Produto: ");
        decimal novoPreco;
        if (decimal.TryParse(Console.ReadLine(), out novoPreco))
        {
            if (novoPreco >= 0)
            {
                produto.Preco = novoPreco;
            }
            else
            {
                Console.WriteLine("Preço inválido. Operação cancelada.");
                return;
            }
        }

        Console.Write("Nova Quantidade do Produto: ");
        int novaQuantidade;
        if (int.TryParse(Console.ReadLine(), out novaQuantidade))
        {
            if (novaQuantidade >= 0)
            {
                produto.Quantidade = novaQuantidade;
            }
            else
            {
                Console.WriteLine("Quantidade inválida. Operação cancelada.");
                return;
            }
        }

        Console.WriteLine("Produto modificado com sucesso.");
    }

    static void ExcluirProduto(List<Produto> produtos)
    {
        Console.WriteLine("\nEXCLUIR PRODUTO");

        if (produtos.Count == 0)
        {
            Console.WriteLine("Não há produtos cadastrados.");
            return;
        }

        MostrarProdutos(produtos);

        Console.Write("Selecione o número do produto a ser excluído: ");
        int numeroProduto;
        if (!int.TryParse(Console.ReadLine(), out numeroProduto) || numeroProduto < 1 || numeroProduto > produtos.Count)
        {
            Console.WriteLine("Número de produto inválido. Operação cancelada.");
            return;
        }

        produtos.RemoveAt(numeroProduto - 1);
        Console.WriteLine("Produto excluído com sucesso.");
    }
}