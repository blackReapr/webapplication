using AutoMapper;
using WebApplication5.Data.Data;
using WebApplication5.Data.Entities;
using WebApplication5.Dtos.GroupDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroupController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public GroupController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("")]
    public async Task<IActionResult> Get()
    {
        IEnumerable<Group> groups = await _context.Groups.Include(g => g.Students).AsNoTracking().ToListAsync();
        return Ok(_mapper.Map<IEnumerable<GroupReturnDto>>(groups));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        Group? group = await _context.Groups.Include(g => g.Students).AsNoTracking().FirstOrDefaultAsync(group => group.Id == id);
        if (group == null) return NotFound();
        return Ok(_mapper.Map<GroupReturnDto>(group));
    }

    [HttpPost("")]
    public async Task<IActionResult> Post(GroupCreateDto groupCreateDto)
    {
        Group group = _mapper.Map<Group>(groupCreateDto);
        await _context.Groups.AddAsync(group);
        await _context.SaveChangesAsync();
        return Created();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, GroupCreateDto groupCreateDto)
    {
        Group? group = await _context.Groups.FirstOrDefaultAsync(g => g.Id == id);
        if (group == null) return NotFound();
        _mapper.Map(groupCreateDto, group);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        Group? group = await _context.Groups.FirstOrDefaultAsync(g => g.Id == id);
        if (group == null) return NotFound();
        _context.Groups.Remove(group);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
