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
    }
}