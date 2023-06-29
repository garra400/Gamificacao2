using System;
using System.Collections.Generic;
using System.Linq;
using gamificacao2.Models;
using gamificacao2.UI;
using gamificacao2.Interface;

namespace gamificacao2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sistema de E-commerce - Loja de Roupas");
            Console.WriteLine("======================================");

            // Criação dos objetos
            List<Produto> produtos = new List<Produto>();
            List<Promocao> promocoes = new List<Promocao>();
            Carrinho carrinho = new Carrinho();

            while (true)
            {
                Console.WriteLine("\nMENU PRINCIPAL");
                Console.WriteLine("1 - Gerenciar Produtos");
                Console.WriteLine("2 - Gerenciar Promoções");
                Console.WriteLine("3 - Gerenciar Carrinho");
                Console.WriteLine("4 - Realizar Pagamento");
                Console.WriteLine("0 - Sair do Sistema");

                Console.Write("Opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        IProduto.GerenciarProdutos(produtos);
                        break;
                    case "2":
                        Menupromocoes.GerenciarPromocoes(promocoes, produtos);
                        break;
                    case "3":
                        ICarrinho.GerenciarCarrinho(carrinho, produtos);
                        break;
                    case "4":
                        ICarrinho.RealizarPagamento(carrinho);
                        break;
                    case "0":
                        Console.WriteLine("Saindo do sistema...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Digite novamente.");
                        break;
                }
            }
        }        
    }
}
