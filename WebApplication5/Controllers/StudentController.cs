using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data.Data;
using WebApplication5.Data.Entities;
using WebApplication5.Dtos.StudentDtos;

namespace WebApplication5.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public StudentController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("")]
    public async Task<IActionResult> Get()
    {
        IEnumerable<Student> students = await _context.Students.Include(s => s.Group).ToListAsync();
        return Ok(_mapper.Map<IEnumerable<StudentReturnDto>>(students));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        Student? student = await _context.Students.Include(s => s.Group).ThenInclude(g => g.Students).FirstOrDefaultAsync(s => s.Id == id);
        if (student == null) return NotFound();
        return Ok(_mapper.Map<StudentReturnDto>(student));
    }

    [HttpPost]
    public async Task<IActionResult> Post(StudentCreateDto studentCreateDto)
    {
        Group? group = await _context.Groups.Include(g => g.Students).AsNoTracking().FirstOrDefaultAsync(g => g.Id == studentCreateDto.GroupId);
        if (group == null) return NotFound();
        if (group.Limit == group.Students.Count) return Conflict();
        Student student = _mapper.Map<Student>(studentCreateDto);
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
        return Created();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, StudentCreateDto studentCreateDto)
    {
        Student? student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
        if (student == null) return NotFound();
        Group? group = await _context.Groups.Include(g => g.Students).FirstOrDefaultAsync(g => g.Id == studentCreateDto.GroupId);
        if (group == null) return NotFound();
        if (group.Students.Count == group.Limit && student.GroupId != studentCreateDto.GroupId) return Conflict();
        _mapper.Map(studentCreateDto, student);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        Student? student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
        if (student == null) return NotFound();
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
