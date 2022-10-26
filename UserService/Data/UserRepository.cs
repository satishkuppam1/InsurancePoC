using UserService.Dtos;
using UserService.Model;

namespace UserService.Data
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users;
        private List<CartItem> _cartItems;
        private ShoppingCart _shoppingCart;
        public UserRepository()
        {
            _users = new List<User>();
            _users.Add(new User
            {
                UserId = 101,
                FirstName = "Palash",
                LastName = "Asija",
                Role = "Agent",
                UserName = "pa@gmail.com",
                Password = "palash@18",
                ContactNo = "992929292"
            });
            _users.Add(new User
            {
                UserId = 102,
                FirstName = "sam",
                LastName = "Billings",
                Role = "Customer",
                UserName = "sam@gmail.com",
                Password = "sam@18",
                ContactNo = "998298292"
            });
            _users.Add(new User
            {
                UserId = 103,
                FirstName = "Steve",
                LastName = "Smith",
                Role = "Customer",
                UserName = "steve@gmail.com",
                Password = "steve@18",
                ContactNo = "73373783"
            });
            

            _cartItems = new List<CartItem>();
            _shoppingCart = new ShoppingCart();
        }

        public User Login(string username, string password)
        {
            User data = (from u in _users
                         where u.UserName == username && u.Password == password
                         select u).FirstOrDefault();
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public void AddToCart(int policyId, int userId)
        {
            int id = 0;
            if(_cartItems.Count() > 0)
            {
                id = _cartItems.Max( x=> x.ItemId ) + 1;
            }
            else
            {
                id = 1;
            }
            _cartItems.Add(new CartItem
            {
                ItemId = id,
                CartId = 1 ,
                UserId = userId,
                PolicyId = policyId,
                DateCreated = DateTime.Now
            });

        }

        public List<CartItem> GetCartItems(int cartId, int userId)
        {
            List<CartItem> item = (from c in _cartItems 
                                    where c.CartId == cartId && c.UserId == c.UserId
                                    select c).ToList();
            return item;
        }

        public CartItem RemoveCartItem(int cartId, int userId, int itemId)
        {
            CartItem item = (from c in _cartItems 
            where c.CartId == cartId && c.ItemId == itemId && c.UserId == userId
            select c).FirstOrDefault();
            _cartItems.Remove(item);
            return item;
        }

        //     public LoginDto Login(string username, string password)
        //     {
        //         User user = (from u in _users
        //                     where u.UserName == username && u.Password == password
        //                     select u).FirstOrDefault();
        //         LoginDto logindto = new LoginDto();
        //         if(user!=null)
        //         {
        //             logindto.UserId = user.UserId;
        //             logindto.Role = user.Role;
        //             logindto.IsSuccesful = true;
        //         }
        //         else
        //         {
        //             logindto.IsSuccesful = false;
        //         }
        //         return logindto;
        //     }
    }
}