﻿using DadosSistema.Models;
using DadosSistema.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadosSistema
{
    public class VendasRepositorioInMemory : IVendaRepositorio
    {
        private List<Venda> _vendas = new List<Venda>()
        {
            new Venda("Cliente1", new List<ItemVenda>()
                {
                    new ItemVenda(new Produto("Produto1", 10.5m), 2),
                    new ItemVenda(new Produto("Produto2", 20.0m), 1)
                }),
                new Venda("Cliente2", new List<ItemVenda>()
                {
                    new ItemVenda(new Produto("Produto3", 15.75m), 3),
                    new ItemVenda(new Produto("Produto1", 10.5m), 1)
                }),
                new Venda("Cliente3", new List<ItemVenda>()
                {
                    new ItemVenda(new Produto("Produto2", 20.0m), 2),
                    new ItemVenda(new Produto("Produto3", 15.75m), 1)
                }),
                new Venda("Cliente4", new List<ItemVenda>()
                {
                    new ItemVenda(new Produto("Produto1", 10.5m), 3),
                    new ItemVenda(new Produto("Produto2", 20.0m), 2)
                }),
                new Venda("Cliente5", new List<ItemVenda>()
                {
                    new ItemVenda(new Produto("Produto3", 15.75m), 2),
                    new ItemVenda(new Produto("Produto1", 10.5m), 1)
                }),
                new Venda("Cliente6", new List<ItemVenda>()
                {
                    new ItemVenda(new Produto("Produto2", 20.0m), 1),
                    new ItemVenda(new Produto("Produto3", 15.75m), 1),
                    new ItemVenda(new Produto("Produto1", 10.5m), 1)
                }),
                new Venda("Cliente7", new List<ItemVenda>()
                {
                    new ItemVenda(new Produto("Produto1", 10.5m), 2),
                    new ItemVenda(new Produto("Produto2", 20.0m), 2)
                }),
                new Venda("Cliente8", new List<ItemVenda>()
                {
                    new ItemVenda(new Produto("Produto3", 15.75m), 1),
                    new ItemVenda(new Produto("Produto1", 10.5m), 1)
                }),
                new Venda("Cliente9", new List<ItemVenda>()
                {
                    new ItemVenda(new Produto("Produto2", 20.0m), 3),
                    new ItemVenda(new Produto("Produto3", 15.75m), 1)
                }),
                new Venda("Cliente10", new List<ItemVenda>()
                {
                    new ItemVenda(new Produto("Produto1", 10.5m), 1),
                    new ItemVenda(new Produto("Produto2", 20.0m), 1),
                    new ItemVenda(new Produto("Produto3", 15.75m), 1)
                })


            //new Venda("Cliente1", new List<ItemVenda>()
            //{
            //    new ItemVenda("Produto1", 10.5m, 2),
            //    new ItemVenda("Produto2", 20.0m, 1)
            //}),
            //new Venda("Cliente2", new List<ItemVenda>()
            //{
            //    new ItemVenda("Produto3", 15.75m, 3),
            //    new ItemVenda("Produto1", 10.5m, 1)
            //}),
            //new Venda("Cliente3", new List<ItemVenda>()
            //{
            //    new ItemVenda("Produto2", 20.0m, 2),
            //    new ItemVenda("Produto3", 15.75m, 1)
            //}),
            //new Venda("Cliente4", new List<ItemVenda>()
            //{
            //    new ItemVenda("Produto1", 10.5m, 3),
            //    new ItemVenda("Produto2", 20.0m, 2)
            //}),
            //new Venda("Cliente5", new List<ItemVenda>()
            //{
            //    new ItemVenda("Produto3", 15.75m, 2),
            //    new ItemVenda("Produto1", 10.5m, 1)
            //}),
            //new Venda("Cliente6", new List<ItemVenda>()
            //{
            //    new ItemVenda("Produto2", 20.0m, 1),
            //    new ItemVenda("Produto3", 15.75m, 1),
            //    new ItemVenda("Produto1", 10.5m, 1)
            //}),
            //new Venda("Cliente7", new List<ItemVenda>()
            //{
            //    new ItemVenda("Produto1", 10.5m, 2),
            //    new ItemVenda("Produto2", 20.0m, 2)
            //}),
            //new Venda("Cliente8", new List<ItemVenda>()
            //{
            //    new ItemVenda("Produto3", 15.75m, 1),
            //    new ItemVenda("Produto1", 10.5m, 1)
            //}),
            //new Venda("Cliente9", new List<ItemVenda>()
            //{
            //    new ItemVenda("Produto2", 20.0m, 3),
            //    new ItemVenda("Produto3", 15.75m, 1)
            //}),
            //new Venda("Cliente10", new List<ItemVenda>()
            //{
            //    new ItemVenda("Produto1", 10.5m, 1),
            //    new ItemVenda("Produto2", 20.0m, 1),
            //    new ItemVenda("Produto3", 15.75m, 1)
            //})
        };
        public Venda Add(Venda venda)
        {
            _vendas.Add(venda);
            return venda;
        }

        public List<Venda> Get()
        {
            return _vendas;
        }

        public Venda? GetById(int id)
        {
            var venda = _vendas.FirstOrDefault(venda => venda.Id == id);
            return venda;
        }
    }
}