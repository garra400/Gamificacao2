using System;
using System.Collections.Generic;
using System.Linq;
using gamificacao2.UI;
using gamificacao2.Models;
using gamificacao2.Interface;

namespace gamificacao2.Models;

public class ItemCarrinho
{
    public Produto Produto { get; set; }
    public int Quantidade { get; set; }

    public ItemCarrinho(Produto produto, int quantidade)
    {
        Produto = produto;
        Quantidade = quantidade;
    }
}