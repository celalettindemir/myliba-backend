using Case.Core.DTO.Page;
using Case.Core.Responses.Service;
using Case.Domain.DTO;
using Case.Service;
using Microsoft.AspNetCore.Mvc;

namespace Case.API.Controllers;

public class PersonalController:BaseController
{
    private readonly IPersonalService _personalService;

    public PersonalController(IPersonalService personalService)
    {
        _personalService = personalService;
    }

    [HttpGet]
    public ServiceResponse<PageResponse<PersonalDTO>> Personals([FromQuery]PageParameters parameters)
    {
        return _personalService.GetAll(parameters);
    }
    [HttpGet("{id}")]
    public async Task<ServiceResponse<PersonalDTO>> Personal(string id)
    {
        return await _personalService.GetById(id);
    }
    [HttpPost]
    public async Task<ServiceResponse<bool>> CreatePersonal(PersonalSaveDTO model)
    {
        return await _personalService.CreatePersonal(model);
    }
    
    [HttpPut]
    public async Task<ServiceResponse<bool>> UpdatePersonal(PersonalUpdateDTO model)
    {
        return await _personalService.UpdatePersonal(model);
    }
    [HttpDelete("{id}")]
    public async Task<ServiceResponse<bool>> DeletePersonal(string id)
    {
        return await _personalService.DeletePersonal(id);
    }
}