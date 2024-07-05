using ApplicationCore.DTO_s.CategoryDTO;
using ApplicationCore.DTO_s.ProductsDTO;
using ApplicationCore.Entities.Concrete;
using AutoMapper;
using DataAccess.Services.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepo.GetFilteredListAsync(
                select: x => new ProductDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    CategoryId = x.CategoryId,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    Status = x.Status
                },
                where: x => x.Status != ApplicationCore.Entities.Abstract.Status.Passive,
                orderBy: x => x.OrderByDescending(z => z.CreatedDate)
            );
            return Ok(products);
        }

        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);

            var dto = _mapper.Map<ProductDTO>(product);

            if (dto is not null)
                return Ok(dto);

            return NotFound("Bu id'ye sahip product yok!");
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductDTO model)
        {
            if (model == null)
            {
                return BadRequest("Bir şeyler ters gitti!");
            }

            if (await _productRepo.AnyAsync(x => x.Name == model.Name))
            {
                return BadRequest("Bu isimde bir product var. Farklı bir isim seçiniz!");
            }

            var product = _mapper.Map<Product>(model);

            await _productRepo.AddAsync(product);

            return Ok($"Product eklenmiştir! \n{product.Name}\n{product.Price}");
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromForm] UpdateProductDTO model)
        {
            if (model is null)
            {
                return BadRequest("Bir şeyler ters gitti!");
            }

            if (await _productRepo.AnyAsync(x => x.Name == model.Name && x.Id != model.Id))
            {
                return BadRequest("Bu isim kullanılmaktadır. Başka bir isim seçiniz!");
            }

            if (!await _productRepo.AnyAsync(x => x.Id == model.Id && x.Status != ApplicationCore.Entities.Abstract.Status.Passive))
            {
                return NotFound("Bu id'ye sahip bir product bulunamadı!");
            }

            var entity = await _productRepo.GetByIdAsync(model.Id);

            var product = _mapper.Map<Product>(model);
            product.CreatedDate = entity.CreatedDate;

            await _productRepo.UpdateAsync(product);
            return Ok($"Product güncellenmiştir!\nProduct Bilgileri: \n{product.Name}\n{product.Price}");
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id <= 0)
                return BadRequest("Bir şeyler ters gitti!");

            var product = await _productRepo.GetByIdAsync(id);

            if (product is null)
                return NotFound("Product bulunamadı!");

            await _productRepo.DeleteAsync(product);
            return Ok("Product silinmiştir!");
        }
    }
}
