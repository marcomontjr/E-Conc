﻿using System;
using E_Conc.Data.Interfaces;
using E_Conc.Models;
using E_Conc.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Conc.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoRepository _produtoRepo;
        private readonly IItemPedidoRespository _itemPedidoRepo;
        private readonly IEmailService _emailService;
        private readonly ISmsService _smsService;

        public PedidoController(IProdutoRepository produtoRepo,
                                IItemPedidoRespository itemPedidoRepo,
                                IEmailService emailService,
                                ISmsService smsService)
        {
            _produtoRepo = produtoRepo;
            _itemPedidoRepo = itemPedidoRepo;
            _emailService = emailService;
            _smsService = smsService;
        }
        
        [Authorize]
        public IActionResult Carrinho(int? produtoId)
        {
            if (produtoId.HasValue)
                return View(_itemPedidoRepo.AddItemPedido(produtoId.Value));

            return View();
        }

        [Authorize]
        public IActionResult Resumo(int? itemPedidoId)
        {
            if (itemPedidoId.HasValue)
            {
                var itemPedido = _itemPedidoRepo.GetById(itemPedidoId.Value);
                string emailAluno = User.Identity.Name;

                EnviaEmailParaOrientador(itemPedido.Usuario, itemPedido.Produto.Nome, emailAluno);
                EnviarEmailParaAluno(itemPedido, emailAluno);

                EnviarSmsParaOrientador(itemPedido.Usuario);

                return View(itemPedido);
            }

            return View();
        }

        private void EnviarSmsParaOrientador(Usuario usuario)
        {
            _smsService.SendSmsAsync
                (usuario.PhoneNumber, "Olá " + usuario.NomeCompleto + ", Um aluno adquiriu um projeto" +
                "através da plataforma E-Conc, confira seu e-mail para maiores informações");
        }

        private void EnviarEmailParaAluno(ItemPedido itemPedido, string emailAluno)
        {
            _emailService.SendEmailAsync(emailAluno, "E-Conc - Confirmação de Compra de Produto",
                       $"Olá " + emailAluno.Split('@')[0] + ", você aderiu  produto " + itemPedido.Produto.Nome +
                       "em " + DateTime.Now + " e agora pode mandar um email para o orientador responsável pelo projeto para mais detalhes" +
                       "Nome do Orientador: " + itemPedido.Produto.Usuario.NomeCompleto + 
                       "Email: " + itemPedido.Produto.Usuario.Email);
        }

        private void EnviaEmailParaOrientador(Usuario usuario, string NomeProduto, string emailAluno)
        {
            _emailService.SendEmailAsync(usuario.Email, "E-Conc - Aviso de Compra de Produto",
                       $"Olá " + usuario.NomeCompleto + ", informamos que seu projeto " + NomeProduto +
                       " foi adquirido pelo aluno " + emailAluno.Split('@')[0] + 
                       "(Email: " + emailAluno + 
                       "), att Equipe E-Conc");
        }

        [Authorize]
        public IActionResult RemoverItemDoCarrinho(int? itemPedido)
        {
            if (itemPedido.HasValue)
                _itemPedidoRepo.RemoveItemPedido(itemPedido.Value);

            return RedirectToAction("Carrossel", "Produto");
        }
    }
}