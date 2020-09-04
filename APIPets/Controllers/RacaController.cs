﻿using System;
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
    public class RacaController : ControllerBase
    {
        RacaRepository repo = new RacaRepository(); 

        // GET: api/<RacaController>
        [HttpGet]
        public List<Raca> Get()
        {
            return repo.LerTodos();
        }

        // GET api/<RacaController>/5
        [HttpGet("{id}")]
        public Raca Get(int id)
        {
            return repo.BuscarPorId(id);
        }

        // POST api/<RacaController>
        [HttpPost]
        public Raca Post([FromBody] Raca a)
        {
            return repo.Cadastrar(a);
        }

        // PUT api/<RacaController>/5
        [HttpPut("{id}")]
        public Raca Put(int id, [FromBody] Raca a)
        {
            return repo.Alterar(id, a);
        }

        // DELETE api/<RacaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Excluir(id);
        }
    }
}
