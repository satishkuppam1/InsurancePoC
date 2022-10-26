using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PolicyService.Data;
using PolicyService.Model;

namespace PolicyService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PolicyController : ControllerBase
    {
        public IPolicyRepository _policyRepository;
        public PolicyController(IPolicyRepository policyRepository)
        {
           _policyRepository=policyRepository;
        }

        [HttpGet]
        public IEnumerable<Policy> GetPolicies()        
        {
           return _policyRepository.GetPolicies();
        }
        
        [HttpGet("{id}")]
        public Policy GetPolicy(int id)        
        {
           return _policyRepository.GetPolicy(id);
        }

        [HttpDelete("{id}")]
        public Policy DeletePolicy(int id)        
        {
           return _policyRepository.DeletePolicy(id);
        }
        
        [HttpGet("GetPoliciesByName/{name}")]
        public IEnumerable<Policy> GetPoliciesByName(string name)
        {
            return _policyRepository.GetPoliciesByName(name);
        }
        
        [HttpPost]
        public Policy AddPolicy(Policy policy)
        {
           return _policyRepository.AddPolicy(policy);
        }

        [HttpPut("{id}")]
        public Policy Update(Policy policy,int id)
        {
           return _policyRepository.Update(policy,id);
        }
    }
}