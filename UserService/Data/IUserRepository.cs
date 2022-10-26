using UserService.Dtos;
using UserService.Model;

namespace UserService.Data
{
    public interface IUserRepository
    {
        public User Login(string username,string password);
        public void AddToCart(int policyId, int userId);
        public List<CartItem> GetCartItems(int cartId, int userId);
        public CartItem RemoveCartItem(int cartId, int userId,int policyId);
    }
}