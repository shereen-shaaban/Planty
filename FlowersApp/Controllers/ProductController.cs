using DAL.Model;
using DAL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantsBAL.Services;
using PlantsDTO.DTO.ProductDTO;

namespace FlowersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
		private readonly IBaseservice<Product> repo;
        public ProductController(IBaseservice<Product> _repo)
        {
            repo = _repo;
        }

        [HttpGet]
        public Generlresponse Getallproducts()
        {
            List<Product> products = repo.Getall();
			Generlresponse generlresponse = new Generlresponse();
			if (products.Count > 0)
            {
                List<GetproductDTO> getallproductDTOList = new List<GetproductDTO>();
                products.ForEach((e) =>
                {
                    GetproductDTO getproductDTO = new GetproductDTO();
                    getproductDTO.Name = e.Name;
                    getproductDTO.Price = e.Price;
                    getproductDTO.Description = e.Description;
                    getproductDTO.Image = e.Image;
                    getallproductDTOList.Add(getproductDTO);


                });
                
                generlresponse.data = getallproductDTOList;
                generlresponse.Sucess=true;

				//return generlresponse;
            }
            else
            {
                generlresponse.data = "no products exist until now";
                generlresponse.Sucess = false;
                //return generlresponse;
            }
            return generlresponse;
                

        }

        [HttpGet("{id}")]
        public IActionResult Getproductbyid(int id)
        {
            Product product=repo.Getbyid(id);

            if(product != null)
            {
				GetproductDTO getproductDTO=new GetproductDTO();
                getproductDTO.Name=product.Name;
                getproductDTO.Price=product.Price;
                getproductDTO.Image=product.Image;
                getproductDTO.Description=product.Description;
				return Ok(getproductDTO);
            }
            else
				return NotFound("there is'nt any product with that id");
              
        }

        [HttpPost]
        public IActionResult Addproduct(AddproductDTO addproduct)
        {
            Product product=new Product();
            product.Name = addproduct.Name;
            product.Price = addproduct.Price;
            product.Description = addproduct.Description;
            product.Image = addproduct.Image;
            product.quanity=addproduct.quanity;
            repo.ADD(product);
            return CreatedAtAction("Getproductbyid", new {id=product.Id},product);
        }
        //[HttpDelete]
        //      public  IActionResult Deleteproduct(int id)
        //      {

        //      }
        //      [HttpPut]
        //public IActionResult Updateproduct(int id)
        //{

    


}
}
