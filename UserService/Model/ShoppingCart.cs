using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Model
{
    public class ShoppingCart
    {
        public int CartId { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}