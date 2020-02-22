using Microsoft.AspNetCore.Mvc;
using SistEnferHos.Domain.Commands.Nurse;
using SistEnferHos.Domain.Entities;
using SistEnferHos.Domain.Handlers.Interface;
using SistEnferHos.Domain.Helpers.Interfaces;
using SistEnferHos.Domain.Repositories;
using System;
using System.Collections;
using System.Net;

namespace SistEnferHos.API.V1.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class NurseController : ControllerBase
    {
        private readonly INurseRepository _repository;
        private readonly INurseCommandHandlerBase _handler;

        public NurseController(INurseRepository repository, INurseCommandHandlerBase handler)
        {
            _repository = repository;
            _handler = handler;
        }

        // GET: api/Nurse
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IEnumerable GetAll()
        {
            var retorno = _repository.GetAllEntities();
            return retorno;
        }

        // GET: api/Nurse/5
        [HttpGet("{id}", Name = "GetById")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public Nurse GetById(Guid id)
        {
            var Nurse = _repository.GetById(id);
            return Nurse;
        }

        // POST: api/Nurse
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ICommandResult Post([FromBody]CreateNurseCommand value)
        {
            var result = _handler.Handle(value);
            return result;
        }

        // PUT: api/Nurse/5
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ICommandResult Put([FromBody]UpdateNurseCommand value)
        {
            var result = _handler.Handle(value);
            return result;
        }

        // DELETE: api/Nurse/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ICommandResult Delete(Guid id)
        {
            DeleteNurseCommand command = new DeleteNurseCommand();
            command.Id = id;
            var result = _handler.Handle(command);
            return result;
        }
    }
}