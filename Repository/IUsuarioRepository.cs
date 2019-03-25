using System.Collections.Generic;
using testeapi.Models;

namespace testeapi.Repository
{
    public interface IUsuarioRepository
    {
        void Add(Usuario user);
        IEnumerable<Usuario> GetAll();
        Usuario find (long id);
        void Remove(long id);
        void Update(Usuario user);
    }
}