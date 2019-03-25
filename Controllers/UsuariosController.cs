using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using testeapi.Models;
using testeapi.Repository;

namespace testeapi.Controllers
{
    [Route("api/[Controller]")]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepositorio;
        public UsuariosController(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepositorio = usuarioRepo;
            
        }

        [HttpGet]

        public IEnumerable<Usuario> GetAll(){
            return _usuarioRepositorio.GetAll();
        }

        [HttpGet("{id}",Name="GetUsuario")]

        public IActionResult GetById(long id){

            var usuario = _usuarioRepositorio.find(id);
            if(usuario==null)
                return NotFound();

            return new ObjectResult(usuario);

        }

        [HttpPost]
        public IActionResult Create([FromBody] Usuario usuario){
            if(usuario == null)
                return BadRequest();

            _usuarioRepositorio.Add(usuario);

            return CreatedAtRoute("GetUsuario", new {id=usuario.idusuario}, usuario);

        }

        [HttpPut("{id}")]

        public IActionResult Update(long id, [FromBody] Usuario usuario){
            if(usuario==null || usuario.idusuario!=id)
                return BadRequest();
            var _usuario = _usuarioRepositorio.find(id);

            if(_usuario==null)
                return NotFound();

            _usuario.email= usuario.email;
            _usuario.nome= usuario.nome;

            _usuarioRepositorio.Update(_usuario);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(long id){
            var usuario = _usuarioRepositorio.find(id);

            if(usuario== null)
                return NotFound();

            _usuarioRepositorio.Remove(id);
            return new NoContentResult();
        }
    }
}