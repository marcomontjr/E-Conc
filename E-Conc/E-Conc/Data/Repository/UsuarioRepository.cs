﻿using E_Conc.Data.Interfaces;
using E_Conc.Models;
using Microsoft.AspNetCore.Http;

namespace E_Conc.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(Contexto context, IHttpContextAccessor contextAccessor)
            : base(context, contextAccessor)
        {

        }
    }
}