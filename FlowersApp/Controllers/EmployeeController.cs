using DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantsBAL.Services;
using PlantsDTO.DTO.EmployeeDTO;
using PlantsDTO.DTO.ProductDTO;

namespace FlowersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
		private readonly IBaseservice<Employee> repo;
		public EmployeeController(IBaseservice<Employee> _repo)
		{
			repo = _repo;
		}

		[HttpGet]
		public Generlresponse GetallEmployees()
		{
			List<Employee> employees = repo.Getall();
			Generlresponse generlresponse = new Generlresponse();
			if (employees.Count > 0)
			{
				List<GetEmployeeDTO> getEmployeeDTOList = new List<GetEmployeeDTO>();
				employees.ForEach((e) =>
				{
					GetEmployeeDTO getEmployeeDTO = new GetEmployeeDTO();
					getEmployeeDTO.Name = e.Name;
					getEmployeeDTO.address1 = e.address1;
					getEmployeeDTO.address2 = e.address2;
					getEmployeeDTO.Birthdate = e.Birthdate;
					getEmployeeDTO.role = e.role;
					
					getEmployeeDTOList.Add(getEmployeeDTO);


				});

				generlresponse.data = getEmployeeDTOList;
				generlresponse.Sucess = true;

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

		[HttpGet("{id:int}")]
		public IActionResult Getemployeebyid(int id)
		{
			Employee employee = repo.Getbyid(id);
			GetEmployeeDTO getEmployeeDTO = new GetEmployeeDTO();

			if (employee != null)
			{
				getEmployeeDTO.Name = employee.Name;
				getEmployeeDTO.address1 = employee.address1;
				getEmployeeDTO.address2 = employee.address2;
				getEmployeeDTO.Birthdate = employee.Birthdate;
				getEmployeeDTO.role = employee.role;
				return Ok(getEmployeeDTO);
			}
			else
				return NotFound("there is'nt any product with that id");
		}

		[HttpGet("{name:alpha}")]
		public Generlresponse Getemployeebyname(string name)
		{
			Generlresponse generalresponse = new Generlresponse();
			Employee employee = repo.Getbyname(name);
			GetEmployeeDTO getEmployeeDTO = new GetEmployeeDTO();

			if (employee != null)
			{
				getEmployeeDTO.Name = employee.Name;
				getEmployeeDTO.address1 = employee.address1;
				getEmployeeDTO.address2 = employee.address2;
				getEmployeeDTO.Birthdate = employee.Birthdate;
				getEmployeeDTO.role = employee.role;

				generalresponse.data = getEmployeeDTO;
				generalresponse.Sucess = true;

			}
			else
			{
				generalresponse.data = "noyfound";
				generalresponse.Sucess = false;
			}
			return generalresponse;
		}

		[HttpPost]
		public IActionResult Addproduct(AddemployeeDTO addemployee)
		{
			Employee employee = new Employee();
			employee.Name = addemployee.Name;
			employee.address1= addemployee.address1;
			employee.address2 = addemployee.address2;
			employee.Birthdate = addemployee.Birthdate;
			employee.role = addemployee.role;

			repo.ADD(employee);
			return CreatedAtAction("Getproductbyid", new { id = employee.Id }, employee);
		}
		[HttpDelete("{id:int}")]
		public Generlresponse Deleteproduct(int id)
		{
			Employee employee = repo.Getbyid(id);
			Generlresponse generlresponse = new Generlresponse();
			if (employee != null)
			{
				repo.Delete(employee);
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
		public Generlresponse Updateproduct(int id, AddemployeeDTO addemployee)
		{
			Employee employee = repo.Getbyid(id);
			Generlresponse generlresponse = new Generlresponse();
			if (employee != null)
			{
				employee.Name = addemployee.Name;
				employee.address1 = addemployee.address1;
				employee.address2 = addemployee.address2;
				employee.role= addemployee.role;
				employee.Birthdate=employee.Birthdate;
				repo.Edit(employee);
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
