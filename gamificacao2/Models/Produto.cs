using System;
using System.Collections.Generic;
using System.Linq;

namespace gamificacao2.Models;

class Produto
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }

    public Produto(string nome, decimal preco, int quantidade)
    {
        Nome = nome;
        Preco = preco;
        Quantidade = quantidade;
    }

    public override string ToString()
    {
        return $"{Nome} - Preço: R$ {Preco:F2} - Quantidade: {Quantidade}";
    }
}