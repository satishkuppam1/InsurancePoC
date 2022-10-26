using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PolicyService.Model;

namespace PolicyService.Data
{
    public interface IPolicyRepository
    {
        public IEnumerable<Policy> GetPolicies();

        public Policy GetPolicy(int id);

        public IEnumerable<Policy> GetPoliciesByName(string name);

        public Policy AddPolicy(Policy policy);

        public Policy DeletePolicy(int id);

        public Policy Update(Policy policy,int id);

    }
}