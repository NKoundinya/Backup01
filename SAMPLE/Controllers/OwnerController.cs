using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SAMPLE.Controllers
{
    [ApiController]
    [Route("owner-start")]
    public class OwnerController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IMapper _mapper;

        public OwnerController(ILoggerManager logger, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _logger = logger;
            _repoWrapper = repositoryWrapper;
            _mapper = mapper;
        }
        // GET START
        [HttpGet("all-owners")]
        public IActionResult GetAllOwners()
        {
            try
            {
                var owners = _repoWrapper.Owner.GetAllOwners();
                _logger.LogInfo($"Returned all owners from database.");
                foreach (var owner in owners)
                {
                    _logger.LogInfo($"Owner -> {owner.OwnerId}");
                    foreach (var acc in owner.Accounts)
                    {
                        _logger.LogInfo($"Account -> {acc.AccountId} Type -> {acc.AccountType}");
                    }
                }

                var ownersResult = _mapper.Map<IEnumerable<OwnerDto>>(owners);
                return Ok(ownersResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("owner/{id}", Name = "OwnerById")]
        public IActionResult GetOwnerById(Guid id)
        {
            try
            {
                var owner = _repoWrapper.Owner.GetOwnerById(id);
                if (owner == null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with id: {id}");

                    var ownerResult = _mapper.Map<OwnerDto>(owner);
                    return Ok(ownerResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/owner-account")]
        public IActionResult GetOwnerWithDetails(Guid id)
        {
            try
            {
                var owner = _repoWrapper.Owner.GetOwnerWithDetails(id);
                if (owner == null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with details for id: {id}");

                    var ownerResult = _mapper.Map<OwnerDto>(owner);

                    return Ok(ownerResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerWithDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        // GET END

        // POST START
        [HttpPost("create-owner")]
        public IActionResult CreateOwner([FromBody]OwnerForCreationDto owner)
        {
            try
            {
                if (owner == null)
                {
                    _logger.LogError("Owner object sent from client is null.");
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var ownerEntity = _mapper.Map<Owner>(owner);

                _repoWrapper.Owner.CreateOwner(ownerEntity);
                _repoWrapper.Save();

                var createdOwner = _mapper.Map<OwnerDto>(ownerEntity);

                return CreatedAtRoute("OwnerById", new { id = createdOwner.OwnerId }, createdOwner);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        // POST END

        // PUT START
        [HttpPut("update-owner/{id}")]
        public IActionResult UpdateOwner(Guid id, [FromBody]OwnerForUpdateDto ownerForUpdate)
        {
            try
            {
                if (ownerForUpdate == null)
                {
                    _logger.LogError("Owner object sent from client is null.");
                    return BadRequest("Owner object is null");
                }

                var ownerEntity = _repoWrapper.Owner.GetOwnerById(id);
                if (ownerEntity == null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound("Object Not Found");
                }

                _mapper.Map(ownerForUpdate, ownerEntity);

                _repoWrapper.Owner.UpdateOwner(ownerEntity);
                _repoWrapper.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        // PUT END

        // DELETE START {
        [HttpDelete("{id}/delete")]
        public IActionResult DeleteOwner(Guid id)
        {
            try
            {
                var ownerEntity = _repoWrapper.Owner.GetOwnerById(id);
                if (ownerEntity == null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repoWrapper.Owner.RemoveOwner(ownerEntity);
                _repoWrapper.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        // DELETE END }
    }
}