using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Dtos
{
    public class CartItemDto
    {
        public int ItemId { get; set; }
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int PolicyId { get; set; }
        public string PolicyName { get; set; }
        public decimal Premium { get; set; }
    }
}