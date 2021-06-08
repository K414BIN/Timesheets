﻿using System;
using Timesheets.Data.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Services.Managers.Interfaces;

namespace Timesheets.Services.Managers.Implementetion
{
    public class ContractManager :  IContractManager
    {
        private readonly IContractRepo _contractRepo;

        public ContractManager(IContractRepo contractRepo)
        {
            _contractRepo = contractRepo;
        }

        public async Task<bool?> CheckContractIsActive(Guid id)
        {
            return await _contractRepo.CheckContractIsActive(id);
            
        }
    }
}
