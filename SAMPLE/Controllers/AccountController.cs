using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrainingProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IMapper _mapper;

        public AccountController(ILoggerManager logger, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _logger = logger;
            _repoWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllAccounts()
        {
            var accounts = _repoWrapper.Account.GetAllAccounts();

            var accountsList = _mapper.Map<IEnumerable<AccountDto>>(accounts);

            return Ok(accountsList);
        }

        [HttpGet("{id}", Name = "AccountById")]
        public IActionResult GetAccountById(Guid id)
        {
            var account = _repoWrapper.Account.GetAccountById(id);

            var retrievedAcc = _mapper.Map<AccountDto>(account);

            return Ok(retrievedAcc);
        }

        [HttpPost]
        public IActionResult AddAccount([FromBody] AccountDto account)
        {
            var newAccount = _mapper.Map<Account>(account);

            _repoWrapper.Account.CreateAccount(newAccount);
            _repoWrapper.Save();

            return CreatedAtRoute("AccountById", new { id = newAccount.AccountId }, newAccount);
        }
    }
}