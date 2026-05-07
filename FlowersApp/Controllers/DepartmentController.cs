using DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantsBAL.Services;
using PlantsDTO.DTO.DepartmentDTO;

namespace FlowersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
		private readonly IBaseservice<Department> repo;
		public DepartmentController(IBaseservice<Department> _repo)
		{
			repo = _repo;
		}

		[HttpGet]
		public IActionResult Getalldepartment()
		{
			List<Department> departments = repo.Getall();
			if (departments.Count > 0)
			{
				List<GetDepartmentDTO> getDepartmentDTOslist= new List<GetDepartmentDTO>();
				foreach(Department department in departments)
				{
					GetDepartmentDTO getDepartmentDTO = new GetDepartmentDTO();
					getDepartmentDTO.Name = department.Name;
					getDepartmentDTOslist.Add(getDepartmentDTO);
				}
				return Ok(getDepartmentDTOslist);

			}
			else
				return BadRequest("there isn't any Department untill now");
		}

		[HttpGet("{id}")]
		public IActionResult GetDepartmentbyid(int id)
		{
			Department department=repo.Getbyid(id);
			if (department == null)
				return BadRequest();
			else
			{
				GetDepartmentDTO getDepartmentDTO = new GetDepartmentDTO();
				getDepartmentDTO.Name= department.Name;
				return Ok(getDepartmentDTO);
			}
				
		}

		[HttpPost]
		public IActionResult AddDepartment(AddDepartmentDTO addDepartmentDTO)
		{
			Department department = new Department();
			department.Name = addDepartmentDTO.Name;
			repo.ADD(department);
			return CreatedAtAction("GetDepartmentbyid", new { id = department.Id }, department);

		}

	}
}
