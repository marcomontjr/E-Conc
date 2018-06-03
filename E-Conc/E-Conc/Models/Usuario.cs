﻿using E_Conc.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace E_Conc.Models
{
    public class Usuario : IdentityUser
    {
        public string Ra { get; private set; }
        public string NomeCompleto { get; private set; }
        public string Instituicao { get; private set; }
        public string InstituicaoSigla { get; private set; }

        public Usuario() { }

        public Usuario(RegistroContaViewModel modelo)
        {
            Ra = modelo.Ra;
            PasswordHash = modelo.Senha;
            NomeCompleto = modelo.NomeCompleto;
            PhoneNumber = modelo.Telefone;
            Instituicao = modelo.Instituicao;
            InstituicaoSigla = modelo.InstituicaoSigla;
            UserName = modelo.Email;
            Email = modelo.Email;
        }

        public Usuario(ContaMinhaContaViewModel modelo)
        {
            NomeCompleto = modelo.NomeCompleto;
            PhoneNumber = modelo.NumeroDeCelular;
            TwoFactorEnabled = modelo.HabilitarAutenticacaoDeDoisFatores;
            PhoneNumberConfirmed = modelo.NumeroCelularConfirmado;
        }
    }
}