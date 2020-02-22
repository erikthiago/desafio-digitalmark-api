using Microsoft.AspNetCore.Mvc;
using SistEnferHos.Domain.Commands.Hospital;
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
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalRepository _repository;
        private readonly IHospitalCommandHandlerBase _handler;

        public HospitalController(IHospitalRepository repository, IHospitalCommandHandlerBase handler)
        {
            _repository = repository;
            _handler = handler;
        }

        // GET: api/Hospital
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

        // GET: api/Hospital/nurses
        [HttpGet("{hospitalId}/nurses", Name = "GetHospitalNurses")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IEnumerable GetHospitalStudents(Guid hospitalId)
        {
            var retorno = _repository.GetEntitiesByRelationId(hospitalId);
            return retorno;
        }

        // GET: api/Hospital/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public Hospital GetById(Guid id)
        {
            var Hospital = _repository.GetById(id);
            return Hospital;
        }

        // POST: api/Hospital
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ICommandResult Post([FromBody]CreateHospitalCommand value)
        {
            var result = _handler.Handle(value);
            return result;
        }

        // PUT: api/Hospital/5
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ICommandResult Put([FromBody]UpdateHospitalCommand value)
        {
            var result = _handler.Handle(value);
            return result;
        }

        // DELETE: api/Hospital/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ICommandResult Delete(Guid id)
        {
            DeleteHospitalCommand command = new DeleteHospitalCommand();
            command.Id = id;
            var result = _handler.Handle(command);
            return result;
        }
    }
}