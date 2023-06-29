using System;
using System.Collections.Generic;
using System.Linq;
using gamificacao2.UI;
using gamificacao2.Models;
using gamificacao2.Interface;

namespace gamificacao2.UI;
public class ICarrinho{
    public static void GerenciarCarrinho(Carrinho carrinho, List<Produto> produtos)
    {
        while (true)
        {
            Console.WriteLine("\nGERENCIAR CARRINHO");
            Console.WriteLine("1 - Mostrar Carrinho");
            Console.WriteLine("2 - Adicionar Produto ao Carrinho");
            Console.WriteLine("3 - Remover Produto do Carrinho");
            Console.WriteLine("4 - Modificar Quantidade de um Produto do Carrinho");
            Console.WriteLine("0 - Voltar");

            Console.Write("Opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    MostrarCarrinho(carrinho);
                    break;
                case "2":
                    AdicionarProdutoAoCarrinho(carrinho, produtos);
                    break;
                case "3":
                    RemoverProdutoDoCarrinho(carrinho);
                    break;
                case "4":
                    ModificarQuantidadeProdutoDoCarrinho(carrinho);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Digite novamente.");
                    break;
            }
        }
    }

    public static void MostrarCarrinho(Carrinho carrinho)
    {
        Console.WriteLine("\nCARRINHO DE COMPRAS");
        if (carrinho.Produtos.Count == 0)
        {
            Console.WriteLine("O carrinho está vazio.");
        }
        else
        {
            for (int i = 0; i < carrinho.Produtos.Count; i++)
            {
                Console.WriteLine($"Produto {i + 1}: {carrinho.Produtos[i].ToString()}");
            }
        }
    }

    public static void AdicionarProdutoAoCarrinho(Carrinho carrinho, List<Produto> produtos)
    {
        Console.WriteLine("\nADICIONAR PRODUTO AO CARRINHO");

        if (produtos.Count == 0)
        {
            Console.WriteLine("Não há produtos cadastrados.");
            return;
        }

        IProduto.MostrarProdutos(produtos);

        Console.Write("Selecione o número do produto para adicionar ao carrinho: ");
        int numeroProduto;
        if (!int.TryParse(Console.ReadLine(), out numeroProduto) || numeroProduto < 1 || numeroProduto > produtos.Count)
        {
            Console.WriteLine("Número de produto inválido. Operação cancelada.");
            return;
        }

        Produto produto = produtos[numeroProduto - 1];

        Console.Write("Quantidade do Produto: ");
        int quantidade;
        if (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade < 1)
        {
            Console.WriteLine("Quantidade inválida. Operação cancelada.");
            return;
        }

        carrinho.AdicionarProduto(produto, quantidade);

        Console.WriteLine("Produto adicionado ao carrinho com sucesso.");
    }

    public static void RemoverProdutoDoCarrinho(Carrinho carrinho)
    {
        Console.WriteLine("\nREMOVER PRODUTO DO CARRINHO");

        if (carrinho.Produtos.Count == 0)
        {
            Console.WriteLine("O carrinho está vazio.");
            return;
        }

        MostrarCarrinho(carrinho);

        Console.Write("Selecione o número do produto a ser removido do carrinho: ");
        int numeroProduto;
        if (!int.TryParse(Console.ReadLine(), out numeroProduto) || numeroProduto < 1 || numeroProduto > carrinho.Produtos.Count)
        {
            Console.WriteLine("Número de produto inválido. Operação cancelada.");
            return;
        }

        carrinho.RemoverProduto(numeroProduto - 1);

        Console.WriteLine("Produto removido do carrinho com sucesso.");
    }

    public static void ModificarQuantidadeProdutoDoCarrinho(Carrinho carrinho)
    {
        Console.WriteLine("\nMODIFICAR QUANTIDADE DE UM PRODUTO DO CARRINHO");

        if (carrinho.Produtos.Count == 0)
        {
            Console.WriteLine("O carrinho está vazio.");
            return;
        }

        MostrarCarrinho(carrinho);

        Console.Write("Selecione o número do produto para modificar a quantidade: ");
        int numeroProduto;
        if (!int.TryParse(Console.ReadLine(), out numeroProduto) || numeroProduto < 1 || numeroProduto > carrinho.Produtos.Count)
        {
            Console.WriteLine("Número de produto inválido. Operação cancelada.");
            return;
        }

        Produto produto = carrinho.Produtos[numeroProduto - 1].Produto;

        Console.Write("Nova Quantidade do Produto: ");
        int novaQuantidade;
        if (!int.TryParse(Console.ReadLine(), out novaQuantidade) || novaQuantidade < 1)
        {
            Console.WriteLine("Quantidade inválida. Operação cancelada.");
            return;
        }

        carrinho.ModificarQuantidadeProduto(produto, novaQuantidade);

        Console.WriteLine("Quantidade do produto modificada com sucesso.");
    }
    public static void RealizarPagamento(Carrinho carrinho)
    {
        Console.WriteLine("\nREALIZAR PAGAMENTO");

        if (carrinho.Produtos.Count == 0)
        {
            Console.WriteLine("O carrinho está vazio.");
            return;
        }

        decimal valorTotal = carrinho.CalcularValorTotal();

        Console.WriteLine($"Valor Total do Carrinho: R$ {valorTotal:F2}");

        Console.Write("Informe o valor pago: ");
        decimal valorPago;
        if (!decimal.TryParse(Console.ReadLine(), out valorPago) || valorPago < valorTotal)
        {
            Console.WriteLine("Valor pago inválido. Operação cancelada.");
            return;
        }

        decimal troco = valorPago - valorTotal;

        Console.WriteLine($"Troco: R$ {troco:F2}");

        carrinho.LimparCarrinho();

        Console.WriteLine("Pagamento realizado com sucesso. O carrinho foi limpo.");
    }
}