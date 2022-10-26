using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Model;

namespace UserService.Client
{
    public class PolicyClient
    {
        private readonly HttpClient _httpClient;

        public PolicyClient(HttpClient httpClient)
        {
            _httpClient=httpClient;
        }

        public async Task<IReadOnlyCollection<Policy>> GetPoliciesAsync()
        {
            var items = await _httpClient.GetFromJsonAsync<IReadOnlyCollection<Policy>>("GetPolicies");
            return items;
        }
    }
}