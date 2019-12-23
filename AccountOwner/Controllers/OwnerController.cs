using AutoMapper;
using Entity.DataTransferObjects;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AccountOwner.Controllers
{
    [Route("owner-start")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        public OwnerController(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllOwners()
        {
            var owners = _repositoryWrapper.Owner.GetAllOwners();

            var ownerList = _mapper.Map<IEnumerable<OwnerDto>>(owners);

            return Ok(ownerList);
        }
    }
}