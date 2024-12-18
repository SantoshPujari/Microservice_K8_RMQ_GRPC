using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
  [ApiController, Route("api/[Controller]")]
  public class PlatformsController : ControllerBase
  {
    private readonly IPlatformRepo _repository;
    private readonly IMapper _mapper;

    public PlatformsController(IPlatformRepo repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
      Console.WriteLine("--> Getting Platforms...");
      
      var PlatfomIems = _repository.GetAllPlatforms();
      return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(PlatfomIems));
    }

    [HttpGet("{id}", Name = "GetPlatformById")]
    public ActionResult<PlatformReadDto> GetPlatformById(int id)
    {
      Console.WriteLine("--> Getting GetPlatformById...");

      var platformItem = _repository.GetPlatformById(id);
      if(platformItem != null)
        return Ok(_mapper.Map<PlatformReadDto> (platformItem));
      else
        return NotFound();
    }

    [HttpPost]
    public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
    {
      Console.WriteLine("--> Getting CreatePlatform...");

      var platformModel = _mapper.Map<Platform>(platformCreateDto);
      _repository.CreatePlatform(platformModel);
      _repository.SaveChanges();

      var PlatformReadDto = _mapper.Map<PlatformReadDto>(platformModel);
      return CreatedAtRoute(nameof(GetPlatformById), new {id = PlatformReadDto.Id}, PlatformReadDto);
    }
  }
  
}