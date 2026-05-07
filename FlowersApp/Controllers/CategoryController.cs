using DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantsBAL.Services;
using PlantsDTO.DTO.CategoryDTO;

namespace FlowersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IBaseservice<Category> repo;
        public CategoryController(IBaseservice<Category> _repo)
        {
            repo= _repo;
        }

        [HttpGet]
        public ActionResult Getallcategories()
        {
            List<Category> categories = repo.Getall();
            if (categories.Count > 0)
            {
                List<GetCategoryDTO> getCategoryDTOslist = new List<GetCategoryDTO>();

                foreach (Category category in categories)
                {
					GetCategoryDTO getCategoryDTO = new GetCategoryDTO();
                    getCategoryDTO.Name = category.Name;
                    getCategoryDTO.Description = category.Description;

                    getCategoryDTOslist.Add(getCategoryDTO);

                    

				}
                return Ok(getCategoryDTOslist);
            }
            else
                return BadRequest();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult getcategorybyid(int id)
        {
            Category category=repo.Getbyid(id);
            if(category == null)
                return NotFound("not found");
            else
            {
                GetCategoryDTO getCategoryDTO=new GetCategoryDTO();
                getCategoryDTO.Name = category.Name;
                getCategoryDTO.Description = category.Description;
                return Ok(getCategoryDTO);
            }
        }

        [HttpPost]
        public IActionResult AddCategory(GetCategoryDTO getCategoryDTO)
        {
            Category category=new Category();
            category.Name = getCategoryDTO.Name;
            category.Description = getCategoryDTO.Description;
            return CreatedAtAction("getcategorybyid", new { id = category.Id }, category);
        }



    }
}
