using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyService.Model
{
    public class Policy
    {
        public int PolicyId{get;set;}
        public String PolicyName{get;set;}
        public string PolicyType{get;set;}
        public string Insurer{get;set;} 
        public int Premium{get;set;}
          
        }
}
