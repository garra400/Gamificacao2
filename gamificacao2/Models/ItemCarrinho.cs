using System;
using System.Collections.Generic;
using System.Linq;
using gamificacao2;

namespace gamificacao2.Models;

class ItemCarrinho
{
    public Produto Produto { get; set; }
    public int Quantidade { get; set; }

    public ItemCarrinho(Produto produto, int quantidade)
    {
        Produto = produto;
        Quantidade = quantidade;
    }
}