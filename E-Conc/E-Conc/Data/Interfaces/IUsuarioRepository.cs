﻿using E_Conc.Data.Repository.Interfaces;
using E_Conc.Models;

namespace E_Conc.Data.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario GetUsuarioByEmail(string email);
        Usuario GetUsuarioById(string usuarioId);
    }
}