using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.DTOs;
using Vectra.Avaliacao.Backend.Entities;
using Vectra.Avaliacao.Backend.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vectra.Avaliacao.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        IEFContext dbContext;
        IResponse response;

        public ContasController(IEFContext dbContext, IResponse response)
        {
            this.dbContext = dbContext;
            this.response = response;
        }

        // GET: api/<ContasController>
        [HttpGet]
        public Task<Response> Get()
        {
            List<Conta> collections = this.dbContext.Contas.ToList();
            return this.response.GenerateResponse(statusCode: HttpStatusCode.OK, collection: collections);
        }

        // GET api/<ContasController>/5W
        [HttpGet("{id}")]
        public Response Get(int id)
        {
            return null;
        }

        // POST api/<ContasController>
        [HttpPost]
        public Task<Response> Post([FromBody] Conta conta)
        {
            conta.CreatedAt = DateTime.Now;
            conta.IsActive = true;
            this.dbContext.Contas.Add(conta);
            var changes = this.dbContext.SaveChangesAsync();
            string message = changes.Result <= 0 ? "Ocorreu um erro ao tentar criar a conta" : "Operação realizada com sucesso";
            return this.response.GenerateResponse(statusCode: HttpStatusCode.OK, hasError: changes.Result <= 0, message, null);
        }

        // PUT api/<ContasController>/5
        [HttpPut("{id}")]
        public Response Put(int id, [FromBody] Conta conta)
        {
            return null;
        }

        // DELETE api/<ContasController>/5
        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            return null;
        }
    }
}
