using System;
using System.Collections.Generic;
using System.Linq;
using gamificacao2.UI;
using gamificacao2;

namespace gamificacao2.Interface;
public class Menupromocoes{
    static void GerenciarPromocoes(List<Promocao> promocoes, List<Produto> produtos)
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
                    MostrarPromocoes(promocoes);
                    break;
                case "2":
                    AdicionarPromocao(promocoes, produtos);
                    break;
                case "3":
                    ModificarPromocao(promocoes);
                    break;
                case "4":
                    ExcluirPromocao(promocoes);
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