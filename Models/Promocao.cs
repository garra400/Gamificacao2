using System;
using System.Collections.Generic;
using System.Linq;
using gamificacao2.UI;
using gamificacao2.Models;
using gamificacao2.Interface;

namespace gamificacao2.Models;

public class Promocao
{
    public Produto Produto { get; set; }
    public decimal Desconto { get; set; }

    public Promocao(Produto produto, decimal desconto)
    {
        Produto = produto;
        Desconto = desconto;
    }

    public override string ToString()
    {
        return $"{Produto.Nome} - Desconto: {Desconto}%";
    }
}