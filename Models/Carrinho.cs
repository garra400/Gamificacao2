using System;
using System.Collections.Generic;
using System.Linq;
using gamificacao2.UI;
using gamificacao2.Models;
using gamificacao2.Interface;

namespace gamificacao2.Models;

public class Carrinho
{
    public List<ItemCarrinho> Produtos { get; set; }

    public Carrinho()
    {
        Produtos = new List<ItemCarrinho>();
    }

    public void AdicionarProduto(Produto produto, int quantidade)
    {
        ItemCarrinho itemExistente = Produtos.Find(item => item.Produto == produto);

        if (itemExistente != null)
        {
            itemExistente.Quantidade += quantidade;
        }
        else
        {
            ItemCarrinho novoItem = new ItemCarrinho(produto, quantidade);
            Produtos.Add(novoItem);
        }
    }

    public void RemoverProduto(int index)
    {
        Produtos.RemoveAt(index);
    }

    public void ModificarQuantidadeProduto(Produto produto, int novaQuantidade)
    {
        ItemCarrinho itemExistente = Produtos.Find(item => item.Produto == produto);

        if (itemExistente != null)
        {
            itemExistente.Quantidade = novaQuantidade;
        }
    }

    public decimal CalcularValorTotal()
    {
        decimal valorTotal = 0;

        foreach (ItemCarrinho item in Produtos)
        {
            decimal valorProduto = item.Produto.Preco * item.Quantidade;
            valorTotal += valorProduto;
        }

        return valorTotal;
    }

    public void LimparCarrinho()
    {
        Produtos.Clear();
    }
}