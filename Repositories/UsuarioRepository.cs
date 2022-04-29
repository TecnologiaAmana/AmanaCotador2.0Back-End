using amanaWebAPI.Context;
using amanaWebAPI.Domains;
using amanaWebAPI.Interfaces;
using amanaWebAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace amanaWebAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CotadorContext ctx;

        public UsuarioRepository(CotadorContext appContext)
        {
            ctx = appContext;
        }

        public bool Atualizar(int id, Usuario novoUsuario)
        {
            Usuario usuarioBuscado = BuscarPorId(id);

            if (usuarioBuscado == null) return false;
            novoUsuario.IdUsuario = id;

            ctx.Usuarios.Update(novoUsuario);
            ctx.SaveChanges();
            return true;
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public bool Deletar(int id)
        {
            Usuario usuarioBuscado = BuscarPorId(id);

            if (usuarioBuscado == null) return false;

            ctx.Usuarios.Remove(usuarioBuscado);
            ctx.SaveChanges();
            return true;
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == email);

            if (usuario != null)
            {
                if (usuario.Senha.Length < 32)
                {
                    usuario.Senha = Cripto.GerarHash(usuario.Senha);

                    ctx.Usuarios.Update(usuario);
                    ctx.SaveChanges();
                }

                bool comparado = Cripto.CompararSenha(senha, usuario.Senha);

                if (comparado) return usuario;
            }
            return null;
        }
    }
}
