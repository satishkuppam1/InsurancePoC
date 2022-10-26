using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Client;
using UserService.Data;
using UserService.Dtos;
using UserService.Model;
using System.Linq;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public const string CartSessionKey = "CartId";
        private readonly IConfiguration _config;
        private readonly PolicyClient _policyClient;
        private IUserRepository _userRepository;
        public UserController(IConfiguration config,IUserRepository userRepository,PolicyClient policyClient)
        {
            _userRepository = userRepository;
            _config = config;
            _policyClient=policyClient;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(Login user)
        {
            User userAvailable = _userRepository.Login(user.Username,user.Password);
            if(userAvailable != null)
            {
                return Ok(new JwtService(_config).GenerateToken(
                    userAvailable.UserId.ToString(),
                    userAvailable.FirstName,
                    userAvailable.LastName,
                    userAvailable.Role,
                    userAvailable.UserName,
                    userAvailable.ContactNo
                ));
            }
            return Unauthorized();
        }

        [HttpPost("AddToCart")]
        public IActionResult AddToCart(int policyId, int userId)
        {
            _userRepository.AddToCart(policyId,userId);
            return Ok();
        } 

        [HttpGet("GetCartItems")]
        public async Task<IActionResult> GetCartItems(int cartId,int userId)
        {
            //return Ok(_userRepository.GetCartItems(cartId,userId));
            var policies = await _policyClient.GetPoliciesAsync();
            var listOfCartItems =  _userRepository.GetCartItems(cartId,userId);
            CartItemDto dto = new CartItemDto();
            Policy obj = new Policy();
            for (int i=0 ; i < listOfCartItems.Count(); i++)
            {
               dto.CartId = listOfCartItems[i].CartId;
               dto.ItemId = listOfCartItems[i].ItemId;
               dto.UserId = listOfCartItems[i].UserId;
               dto.PolicyId = listOfCartItems[i].PolicyId;
               obj = (from p in policies where p.PoliyId == listOfCartItems[i].PolicyId select p).FirstOrDefault();
               dto.PolicyName = obj.PolicyName;
               dto.Premium = obj.Premium;
            }

            return Ok(dto);
        }


        [HttpDelete("DeleteCartItem")]
        public IActionResult RemoveCartItem(int cartId, int userId, int policyId)
        {
            return Ok(_userRepository.RemoveCartItem(cartId,userId,policyId));
        }
    }
    
}