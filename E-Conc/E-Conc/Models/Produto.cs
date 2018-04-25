﻿using E_Conc.Enum;
using System;

namespace E_Conc.Models
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Arquivo { get; set; }
        public bool Disponivel { get; set; }
        public Categoria Categoria { get; set; }
        public Orientador Orientador { get; set; }
        public Curso Curso { get; set; }

        public Produto() { }

        public Produto(Guid id, string nome, string arquivo, bool disponivel, Categoria categoria) 
            : this(nome, arquivo, disponivel, categoria)
        {
            Id = id;            
        }

        public Produto(string nome, string arquivo, bool disponivel, Categoria categoria)
        {
            Nome = nome;
            Arquivo = arquivo;
            Disponivel = disponivel;
            Categoria = categoria;
        }        
    }
}