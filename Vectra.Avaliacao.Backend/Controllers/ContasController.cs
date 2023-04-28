using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Channels;
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

        // POST api/<ContasController>
        [HttpPost]
        public Task<Response> Create([FromBody] Conta conta)
        {
            conta.CreatedAt = DateTime.Now;
            conta.IsActive = true;
            this.dbContext.Contas.Add(conta);
            var changes = this.dbContext.SaveChangesAsync();
            string message = changes.Result <= 0 ? "Ocorreu um erro ao tentar criar a conta" : "Operação realizada com sucesso";
            return this.response.GenerateResponse(statusCode: HttpStatusCode.OK, hasError: changes.Result <= 0, message, null);
        }

        // GET: api/<ContasController>
        [HttpGet]
        public Task<Response> List()
        {
            List<Conta> collections = this.dbContext.Contas.ToList();
            return this.response.GenerateResponse(statusCode: HttpStatusCode.OK, collection: collections);
        }

        // GET api/<ContasController>/5W
        [HttpGet("{id}")]
        public Task<Response> FindById(int id)
        {
            var conta = dbContext.Contas.Find(id);
            if (conta == null)
                return this.response.GenerateResponse(statusCode: HttpStatusCode.NotFound, message: "Conta não localizada");

            return this.response.GenerateResponse(statusCode: HttpStatusCode.OK, collection: conta);
        }

        // PUT api/<ContasController>/5
        [HttpPut("{id}")]
        public Task<Response> Update(int id, [FromBody] Conta conta)
        {
            var contaUpdate = dbContext.Contas.Find(id);
            contaUpdate.UpdatedAt = DateTime.Now;
            contaUpdate.Numero = conta.Numero;
            contaUpdate.Agencia = conta.Agencia;
            contaUpdate.Saldo = conta.Saldo;
            contaUpdate.Cliente = conta.Cliente;
            contaUpdate.IsActive = conta.IsActive;

            this.dbContext.Contas.Update(contaUpdate);
            var changes = this.dbContext.SaveChangesAsync();
            string message = changes.Result <= 0 ? "Ocorreu um erro ao tentar atualizar a conta, verifique os dados informados!" : "Operação realizada com sucesso";
            return this.response.GenerateResponse(statusCode: HttpStatusCode.OK, hasError: changes.Result <= 0, message, contaUpdate);

        }

        // DELETE api/<ContasController>/5
        [HttpDelete("{id}")]
        public Task<Response> Delete(int id)
        {
            var contaDelete = dbContext.Contas.Find(id);

            this.dbContext.Contas.Remove(contaDelete);
            var changes = this.dbContext.SaveChangesAsync();
            string message = changes.Result <= 0 ? "Ocorreu um erro ao tentar deletar a conta" : "Operação realizada com sucesso";
            return this.response.GenerateResponse(statusCode: HttpStatusCode.NoContent, hasError: changes.Result <= 0, message, contaDelete); ;
        }
    }
}
