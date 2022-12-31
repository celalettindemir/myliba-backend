using AutoMapper;
using Case.Core.DTO.Page;
using Case.Core.Responses.Service;
using Case.Domain.DTO;
using Case.Domain.Entity;
using Case.Repository;

namespace Case.Service;

public class PersonalService : IPersonalService
{
    private readonly IGenericRepository<Personal> _personalRepository;
    private readonly IMapper _mapper;

    public PersonalService(IGenericRepository<Personal> personalRepository, IMapper mapper)
    {
        _personalRepository = personalRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<bool>> CreatePersonal(PersonalSaveDTO model)
    {
        try
        {
            await _personalRepository.AddAsync(_mapper.Map<Personal>(model));
            return new ServiceResponse<bool>()
            {
                data = true,
                message = "success",
                status = true
            };
        }
        catch (Exception e)
        {
            return new ServiceResponse<bool>()
            {
                data = false,
                message = e.Message,
                status = false
            };
        }
    }

    public async Task<ServiceResponse<bool>> UpdatePersonal(PersonalUpdateDTO model)
    {
        try
        {
            await _personalRepository.UpdateAsync(model.Id, _mapper.Map<Personal>(model));
            return new ServiceResponse<bool>()
            {
                data = true,
                message = "success",
                status = true
            };
        }
        catch (Exception e)
        {
            return new ServiceResponse<bool>()
            {
                data = false,
                message = e.Message,
                status = false
            };
        }
    }

    public ServiceResponse<PageResponse<PersonalDTO>> GetAll(PageParameters parameters)
    {
        try
        {
            
            var personals = _personalRepository.Get().Skip((parameters.page) * parameters.size)
                .Take(parameters.size).ToList();
            return new ServiceResponse<PageResponse<PersonalDTO>>()
            {
                data = new PageResponse<PersonalDTO>()
                {
                    data = personals.Select(p=>_mapper.Map<PersonalDTO>(p)).ToList(),
                    totalItems = 20
                },
                message = "success",
                status = true
            };
        }
        catch (Exception e)
        {
            return new ServiceResponse<PageResponse<PersonalDTO>>()
            {
                data = new PageResponse<PersonalDTO>(),
                message = e.Message,
                status = false
            };
        }
    }

    public async Task<ServiceResponse<PersonalDTO>> GetById(string id)
    {
        try
        {
            var personal = await _personalRepository.GetByIdAsync(id);
            return new ServiceResponse<PersonalDTO>()
            {
                data = _mapper.Map<PersonalDTO>(personal),
                message = "success",
                status = true
            };
        }
        catch (Exception e)
        {
            return new ServiceResponse<PersonalDTO>()
            {
                data = new PersonalDTO(),
                message = e.Message,
                status = false
            };
        }
    }

    public async Task<ServiceResponse<bool>> DeletePersonal(string id)
    {
        try
        {
            Personal personal = await _personalRepository.GetByIdAsync(id);
            if (personal == null)
                throw new Exception("Cannot find personal");
            personal.IsDeleted = true;
            await _personalRepository.UpdateAsync(personal.Id, personal);
            return new ServiceResponse<bool>()
            {
                data = true,
                message = "success",
                status = true
            };
        }
        catch (Exception e)
        {
            return new ServiceResponse<bool>()
            {
                data = false,
                message = e.Message,
                status = false
            };
        }
    }
}