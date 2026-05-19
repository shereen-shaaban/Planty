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

        //[HttpGet("{name:alpha}")]
        //public Generlresponse Getproductbyname(string name)
        //{
        //    Product product= repo.Getbyname(name);
        //    GetproductDTO getproductDTO = new GetproductDTO();
        //    getproductDTO.Name=product.Name;
        //    getproductDTO.Price=product.Price;
        //    getproductDTO.Image = product.Image;
        //    getproductDTO.Description=product.Description;
           
        //    Generlresponse generalresponse   = new Generlresponse();
        //    if(product != null)
        //    {
        //        generalresponse.data = getproductDTO;
        //        generalresponse.Sucess= true;

        //    }
        //    else
        //    {
        //        generalresponse.data = "noyfound";
        //        generalresponse.Sucess= false;
        //    }
        //    return generalresponse;
        //}

        [HttpPost]
        public IActionResult Addproduct(AddproductDTO addproduct)
        {
            Product product=new Product();
            product.Cid = addproduct.CategoryId;
			product.Name = addproduct.Name;
            product.Price = addproduct.Price;
            product.Description = addproduct.Description;
            product.Image = addproduct.Image;
            product.quanity=addproduct.quanity;
            repo.ADD(product);
            return CreatedAtAction("Getproductbyid", new {id=product.Id},product);
        }
        [HttpDelete("{id:int}")]
        public Generlresponse Deleteproduct(int id)
        {
            Product product = repo.Getbyid(id);
            Generlresponse generlresponse=new Generlresponse();
            if (product != null)
            {
                repo.Delete(product);
                generlresponse.data = "deleted successfuly";
                generlresponse.Sucess = true;
            }
            else
            {
                generlresponse.data = "notfound";
                generlresponse.Sucess = false;
            }
            return generlresponse;
        }
        [HttpPut("{id}")]
        public Generlresponse Updateproduct(int id,AddproductDTO addproductDTO)
        {
            Product product = repo.Getbyid(id);
            Generlresponse generlresponse=new Generlresponse();
            if (product != null)
            {
                product.Name = addproductDTO.Name;
                product.Price = addproductDTO.Price;
                product.Description = addproductDTO.Description;
                product.Image = addproductDTO.Image;
                product.quanity = addproductDTO.quanity;
                repo.Edit(product);
                generlresponse.data = "updated successfuly";
                generlresponse.Sucess = true;
            }
            else
            {
                generlresponse.data = "not found";
                generlresponse.Sucess = false;
            }

            return generlresponse;

        }




        }
    }
