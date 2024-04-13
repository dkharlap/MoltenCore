using Microsoft.AspNetCore.Mvc;
using MoltenCore.Boilerplate.Domain.Interfaces;
using MoltenCore.Boilerplate.Models;
using MoltenCore.Interfaces;

namespace MoltenCore.Boilerplate.Controllers
{
    /// <summary>
    /// Ctor
    /// </summary>
    [Route("boilerplates/v1")]
    [ApiController]
    [ProducesResponseType(typeof(ApplicationExceptionCode), 401)]
    [ProducesResponseType(typeof(ApplicationExceptionCode), 403)]
    public class BoilerplateController(IBoilerplateDomain domain, IUserContext userContext) : ControllerBase
    {

        /// <summary>
        /// Creates new boilerplate.
        /// </summary>
        /// <response code="201">Boilerplate created.</response>
        /// <response code="400">Boilerplate could not be created with provided arguments.</response>
        /// <response code="500">Oops! Something went wrong.</response>
        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(typeof(ApplicationExceptionCode), 400)]
        [ProducesResponseType(typeof(ApplicationExceptionCode), 500)]
        public async Task<IActionResult> Create([FromBody] BoilerplateCreate boilerplate, CancellationToken cancellationToken = default)
        {
            var id = await _domain.Create(boilerplate, cancellationToken);

            return StatusCode(201, id);
        }


        /// <summary>
        /// Gets boilerplate by ID.
        /// </summary>
        /// <response code="201">Boilerplate</response>
        /// <response code="400">Could not get the boilerplate by provided ID.</response>
        /// <response code="500">Oops! Something went wrong.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Models.Boilerplate), 200)]
        [ProducesResponseType(typeof(ApplicationExceptionCode), 400)]
        [ProducesResponseType(typeof(ApplicationExceptionCode), 500)]
        public async Task<Models.Boilerplate> Get(string id, CancellationToken cancellationToken = default)
        {
            var entity = await _domain.Get(id, cancellationToken);
            return entity;
        }

        /// <summary>
        /// Gets boilerplate by ID.
        /// </summary>
        /// <response code="201">Boilerplate</response>
        /// <response code="400">Could not get the boilerplate by provided ID.</response>
        /// <response code="500">Oops! Something went wrong.</response>
        [HttpGet]
        [ProducesResponseType(typeof(Models.Boilerplate), 200)]
        [ProducesResponseType(typeof(ApplicationExceptionCode), 400)]
        [ProducesResponseType(typeof(ApplicationExceptionCode), 500)]
        public async Task<IEnumerable<Models.Boilerplate>> GetList(CancellationToken cancellationToken = default)
        {
            var entities = await _domain.GetList(cancellationToken);
            return entities;
        }


        /// <summary>
        /// Updates existing boilerplate.
        /// </summary>
        /// <response code="200">Boilerplate updated.</response>
        /// <response code="400">Boilerplate could not be updated.</response>
        /// <response code="500">Oops! Something went wrong.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApplicationExceptionCode), 400)]
        [ProducesResponseType(typeof(ApplicationExceptionCode), 500)]
        public async Task Update(string id, [FromBody] BoilerplateUpdate boilerplate, CancellationToken cancellationToken = default)
        {
            await _domain.Update(id, boilerplate, cancellationToken);
        }

        /// <summary>
        /// Deletes existing boilerplate.
        /// </summary>
        /// <response code="200">Boilerplate deleted.</response>
        /// <response code="400">Boilerplate could not be deleted.</response>
        /// <response code="500">Oops! Something went wrong.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApplicationExceptionCode), 400)]
        [ProducesResponseType(typeof(ApplicationExceptionCode), 500)]
        public async Task Delete(string id, CancellationToken cancellationToken = default)
        {
            await _domain.Delete(id, cancellationToken);
        }

        #region Private members
        private readonly IBoilerplateDomain _domain = domain;
        private readonly IUserContext _userContext = userContext;
        #endregion
    }
}
