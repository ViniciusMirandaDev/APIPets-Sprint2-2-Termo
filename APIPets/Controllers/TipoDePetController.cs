using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIPets.Domais;
using APIPets.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDePetController : ControllerBase
    {
        TipoDePetRepository repo = new TipoDePetRepository();

        // GET: api/<TipoDePetController>
        [HttpGet]
        public List<TipoDePet> Get()
        {
            return repo.LerTodos();
        }

        // GET api/<TipoDePetController>/5
        [HttpGet("{id}")]
        public TipoDePet Get(int id)
        {
            return repo.BuscarPorId(id);
        }

        // POST api/<TipoDePetController>
        [HttpPost]
        public TipoDePet Post([FromBody] TipoDePet a)
        {
            return repo.Cadastrar(a);
        }

        // PUT api/<TipoDePetController>/5
        [HttpPut("{id}")]
        public TipoDePet Put(int id, [FromBody] TipoDePet a)
        {
            return repo.Alterar(id, a);
        }

        // DELETE api/<TipoDePetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Excluir(id);
        }
    }
}
