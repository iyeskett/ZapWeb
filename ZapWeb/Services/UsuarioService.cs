using Microsoft.EntityFrameworkCore;
using ZapWeb.Data;
using ZapWeb.Models;

namespace ZapWeb.Services
{
    public class UsuarioService
    {
        private readonly ZapWebContext _context;

        public UsuarioService(ZapWebContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetUsuarioByEmailAsync(string email) => await _context.Usuarios.FirstOrDefaultAsync(_ => _.Email == email);

        public async Task<bool> InsertUsuario(Usuario usuario)
        {
            Usuario? dbUsuario = await GetUsuarioByEmailAsync(usuario.Email);
            if (dbUsuario != null)
                throw new Exception("Email já cadastrado.");

            try
            {
                await _context.Usuarios.AddAsync(usuario);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}