using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PolicyService.Model;

namespace PolicyService.Data
{
    public class PolicyRepository : IPolicyRepository
    {
        public IPolicyRepository policyRepository;
        public List<Policy> _policies;

        public PolicyRepository(){
            _policies= new List<Policy>();
            _policies.Add(new Policy
            {
                PolicyId=1,
                PolicyName="Iprotect",
                PolicyType="Health Insurance",
                Insurer="ICICI",
                Premium=500
            });
            _policies.Add(new Policy
            {
                PolicyId=2,
                PolicyName="Life",
                PolicyType="Term Insurance",
                Insurer="LIC",
                Premium=350
            });
            _policies.Add(new Policy
            {
                PolicyId=3,
                PolicyName="CarProtect",
                PolicyType="Car Insurance",
                Insurer="HDFC Ergo",
                Premium=500
            }); 
        }
        public IEnumerable<Policy> GetPoliciesByName(string name)
        {
            return _policies.Where(d=>d.PolicyType.Contains(name)).ToList();
        }

        public Policy GetPolicy(int id)
        {
            var result= _policies.FirstOrDefault(d => d.PolicyId==id);
            return result;
        }

        public IEnumerable<Policy> GetPolicies()
        {
            return _policies;
        }

        public Policy DeletePolicy(int id)
        {
            var result = _policies.Where(a => a.PolicyId==id).FirstOrDefault();
            if(result!=null)
            {
            _policies.Remove(result);
            return result;
            }
            return null;
        }

        public Policy AddPolicy(Policy policy){
         _policies.Add(policy);
         return policy;     
        }
         public Policy Update(Policy policy, int id){
            Policy updated= _policies.FirstOrDefault(a => a.PolicyId==id);
            updated.PolicyName= policy.PolicyName;
            updated.PolicyType=policy.PolicyType;
            updated.Premium=policy.Premium;
            updated.Insurer= policy.Insurer;
            return updated;
         }
    
    }
    }
