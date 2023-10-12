using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class DepartamentoController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DepartamentoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DepartamentoDto>>> Get()
    {
        var depa = await _unitOfWork.Departamentos.GetAllAsync();
        return _mapper.Map<List<DepartamentoDto>>(depa);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DepartamentoDto>> Get(int id)
    {
        var depa = await _unitOfWork.Departamentos.GetByIdAsync(id);
        if(depa == null) 
            return NotFound();
        return _mapper.Map<DepartamentoDto>(depa);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Departamento>> Post([FromBody] DepartamentoDto depaDto)
    {
        var depa = _mapper.Map<Departamento>(depaDto);
        _unitOfWork.Departamentos.Add(depa);
        await _unitOfWork.SaveAsync();
        if(depa == null)
            return BadRequest();
        depaDto.Id = depa.Id;
        return CreatedAtAction(nameof(Post), new{id = depaDto.Id}, depaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DepartamentoDto>> Put(int id, [FromBody] DepartamentoDto depaDto)
    {
        if( depaDto == null)
            return BadRequest();        
        if( depaDto.Id == 0 )
            depaDto.Id = id;
        if( depaDto.Id != id )
            return BadRequest();
        var depa = _mapper.Map<Departamento>(depaDto);
        _unitOfWork.Departamentos.Update(depa);
        await _unitOfWork.SaveAsync();
        return depaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var dep = await _unitOfWork.Departamentos.GetByIdAsync(id);
        if ( dep == null )
            return NotFound();
        _unitOfWork.Departamentos.Remove(dep);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}