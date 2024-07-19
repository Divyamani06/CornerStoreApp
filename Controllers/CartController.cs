using AutoMapper;
using CornerStore.API.Dtos.RequestDtos;
using CornerStore.API.Dtos.ResponseDtos;
using CornerStore.API.Model;
using CornerStore.API.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CornerStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;

        public CartController(ICartService cartService, IMapper mapper)
        {
            _cartService = cartService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCart()
        {
            var cart = await _cartService.GetAllCart();
            if (cart.Count() == 0)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIDCart(Guid id)
        {
            var cart = await _cartService.GetByIdCart(id);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        [HttpPost]
        public async Task<IActionResult> CreatCart(CartRequestDto cart)
        {
            var cartDetails = await _cartService.CreatCart(cart);
            if(cartDetails == null)
            {
                return BadRequest();
            }
            return Ok(cartDetails);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCart(Guid id, CartRequestDto cart)
        {
            if (id == null)
            {
                return BadRequest();
            }
            await _cartService.UpdateCart(id, cart);

            return Ok(cart);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(Guid id)
        {
            var result = await _cartService.DeteleCart(id);
            return Ok(result);
        }
    }

}
