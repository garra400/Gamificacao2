using System;
using System.Collections.Generic;
using System.Linq;
using gamificacao2.UI;
using gamificacao2.Models;
using gamificacao2.Interface;

namespace gamificacao2.Interface;
public class Menupromocoes{
    public static void GerenciarPromocoes(List<Promocao> promocoes, List<Produto> produtos)
    {
        while (true)
        {
            Console.WriteLine("\nGERENCIAR PROMOÇÕES");
            Console.WriteLine("1 - Mostrar Promoções");
            Console.WriteLine("2 - Adicionar Promoção");
            Console.WriteLine("3 - Modificar Promoção");
            Console.WriteLine("4 - Excluir Promoção");
            Console.WriteLine("0 - Voltar");

            Console.Write("Opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    IPromocoes.MostrarPromocoes(promocoes);
                    break;
                case "2":
                    IPromocoes.AdicionarPromocao(promocoes, produtos);
                    break;
                case "3":
                    IPromocoes.ModificarPromocao(promocoes);
                    break;
                case "4":
                    IPromocoes.ExcluirPromocao(promocoes);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Digite novamente.");
                    break;
            }
        }
    }
}