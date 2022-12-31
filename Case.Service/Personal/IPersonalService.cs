using Case.Core.DTO.Page;
using Case.Core.Responses.Service;
using Case.Domain.DTO;

namespace Case.Service;

public interface IPersonalService
{
    
    Task<ServiceResponse<bool>> CreatePersonal(PersonalSaveDTO model);
    Task<ServiceResponse<bool>> UpdatePersonal(PersonalUpdateDTO model);
    ServiceResponse<PageResponse<PersonalDTO>> GetAll(PageParameters parameters);
    Task<ServiceResponse<PersonalDTO>>  GetById(string id);
    Task<ServiceResponse<bool>>  DeletePersonal(string id);

}