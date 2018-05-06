﻿using E_Conc.Enum;
using E_Conc.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace E_Conc.Models
{
    public class Usuario : IdentityUser
    {
        public string Ra { get; private set; }
        public string Senha { get; private set; }   
        public string NomeCompleto { get; private set; }
        public string Telefone { get; private set; }
        public string Instituicao { get; private set; }
        public string InstituicaoSigla { get; private set; }
        public TipoUsuario TipoUsuario { get; private set; }

        public Usuario() { }

        public Usuario(RegistroContaViewModel modelo)
        {
            Ra = modelo.Ra;
            Senha = modelo.Senha;
            NomeCompleto = modelo.NomeCompleto;
            Telefone = modelo.Telefone;
            Instituicao = modelo.Instituicao;
            InstituicaoSigla = modelo.InstituicaoSigla;
            TipoUsuario = modelo.TipoUsuario;
        }
    }
}