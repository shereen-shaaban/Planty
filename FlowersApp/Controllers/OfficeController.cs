using DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantsBAL.Services;
using PlantsDTO.DTO.OfficeDTO;
using PlantsDTO.DTO.ProductDTO;

namespace FlowersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
		
			private readonly IBaseservice<Office> repo;
			public OfficeController(IBaseservice<Office> _repo)
			{
				repo = _repo;
			}

			[HttpGet]
			public Generlresponse GetallOffices()
			{
				List<Office> office = repo.Getall();
				Generlresponse generlresponse = new Generlresponse();
				if (office.Count > 0)
				{
					List<OfficeDto> getallproductDTOList = new List<OfficeDto>();
					office.ForEach((e) =>
					{
						OfficeDto officeDto = new OfficeDto();
						officeDto.Name = e.Name;
						officeDto.Description = e.Description;
						officeDto.City = e.City;
						officeDto.Street = e.Street;
						officeDto.Country = e.Country;
						officeDto.Phone = e.Phone;
						getallproductDTOList.Add(officeDto);
					});

					generlresponse.data = getallproductDTOList;
					generlresponse.Sucess = true;
				}
				else
				{
					generlresponse.data = "no office exist until now";
					generlresponse.Sucess = false;
				}
				return generlresponse;


			}

			[HttpGet("{id}")]
			public IActionResult Getproductbyid(int id)
			{
				Office office = repo.Getbyid(id);

				if (office != null)
				{
					OfficeDto getOfficeDto = new OfficeDto();
					getOfficeDto.Name = office.Name;
					getOfficeDto.Description = office.Description;
					getOfficeDto.City = office.City;
					getOfficeDto.Street = office.Street;
					getOfficeDto.Country = office.Country;
					getOfficeDto.Phone = office.Phone;
					return Ok(getOfficeDto);
				}
				else
					return NotFound("there is'nt any office with that id");

			}

			[HttpPost]
			public IActionResult Addproduct(OfficeDto officeDto)
			{
				Office office = new Office();
			    office.Name = officeDto.Name;
				office.Description = officeDto.Description;
				office.City = officeDto.City;
				office.Street = officeDto.Street;
				office.Country = officeDto.Country;
				office.Phone = officeDto.Phone;

				repo.ADD(office);
				return CreatedAtAction("Getproductbyid", new { id = office.Id }, office);
			}
			[HttpDelete("{id:int}")]
			public Generlresponse Deleteproduct(int id)
			{
				Office office = repo.Getbyid(id);
				Generlresponse generlresponse = new Generlresponse();
				if (office != null)
				{
					repo.Delete(office);
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
			public Generlresponse Updateproduct(int id, OfficeDto officeDto)
			{
				Office office = repo.Getbyid(id);
				Generlresponse generlresponse = new Generlresponse();
				if (office != null)
				{
					office.Name = officeDto.Name;
					office.Description = officeDto.Description;
					office.City = officeDto.City;
					office.Street = officeDto.Street;
					office.Country = officeDto.Country;
					office.Phone = officeDto.Phone;
					repo.Edit(office);
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


