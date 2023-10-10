using Microsoft.AspNetCore.SignalR;
using ZapWeb.Data;
using ZapWeb.Models;
using ZapWeb.Services;

namespace ZapWeb.Hubs
{
    public class ZapWebHub : Hub
    {
        private readonly UsuarioService _usuarioService;

        public ZapWebHub(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task Cadastrar(Usuario usuario)
        {
            try
            {
                bool cadastrou = await _usuarioService.InsertUsuario(usuario);

                if (cadastrou)
                    await Clients.Caller.SendAsync("UsuarioCadastrado", true, usuario, "Usuário cadastrado com sucesso.");
                else
                    await Clients.Caller.SendAsync("UsuarioCadastrado", false, null, "Não foi possível cadastrar o usuário.");
            }
            catch (Exception e)
            {
                await Clients.Caller.SendAsync("UsuarioCadastrado", false, null, e.Message);
            }
        }

        public async Task Login(Usuario usuario)
        {
            try
            {
                Usuario? dbUsuario = await _usuarioService.GetUsuarioByEmailAsync(usuario.Email);

                if (dbUsuario == null)
                    await Clients.Caller.SendAsync("UsuarioLogado", false, null, "Usuário não encontrado.");
                else if (dbUsuario.Senha == usuario.Senha)
                    await Clients.Caller.SendAsync("UsuarioLogado", true, dbUsuario, "");
                else
                    await Clients.Caller.SendAsync("UsuarioLogado", false, null, "Senha incorreta.");
            }
            catch (Exception e)
            {
                await Clients.Caller.SendAsync("UsuarioLogado", false, null, e.Message);
            }
        }
    }
}