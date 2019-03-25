using System.Collections.Generic;
using System.Linq;
using testeapi.Models;

namespace testeapi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioDbContext _contexto;
        public UsuarioRepository(UsuarioDbContext ctx)
        {
            _contexto=ctx;
        }
        public void Add(Usuario user)
        {
            _contexto.Usuarios.Add(user);
            _contexto.SaveChanges();
        }

        public Usuario find(long id)
        {
            return _contexto.Usuarios.FirstOrDefault(u => u.idusuario == id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _contexto.Usuarios.ToList();
        }

        public void Remove(long id)
        {
            var entity = _contexto.Usuarios.First(u => u.idusuario == id);
            _contexto.Usuarios.Remove(entity);
            _contexto.SaveChanges();
        }

        public void Update(Usuario user)
        {
            _contexto.Usuarios.Update(user);
            _contexto.SaveChanges();
        }
    }
}