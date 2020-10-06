using Microsoft.AspNetCore.Mvc;
using Students.Domain.Interfaces;
using Students.Domain.Models;
using System.Data.Odbc;
using System.Threading.Tasks;

namespace Students.Api.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IRepository<Student> _repository;

        public StudentsController(IRepository<Student> repository)
        {
            _repository = repository;
        }

        [HttpGet]

        public async Task<ActionResult<PageResponse<Student>>> GetPageList([FromQuery]PageRequest pageRequest) 
        {
            return await _repository.GetPagedResult(pageRequest.Page, pageRequest.PageSize);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _repository.GetAsync(id);
            if (student != null)
                return Ok(student);
            return NotFound();
            
        }

        [HttpPost]

        public async Task<ActionResult<Student>> PostStudent([FromBody]Student student)
        {
            return await _repository.CreateAsync(student) == 1 ? (ActionResult)Ok(student) : BadRequest(student);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<Student>> DeleteStudent(int id) 
        {
            if (await _repository.RemoveAsync(id))
                return Ok();
            else
                return NotFound();

        }

        [HttpPut]

        public async Task<ActionResult<Student>> PutStudent([FromBody]Student student) 
        {
            if (await _repository.UpdateAsync(student))
                return Ok(student);
            else
                return NotFound();
        }

    }
}
