using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingAppDemo.API.Controllers
{
    //1)if we get request : http://localhost:5000/api/values and the type of request is get  
    //2)if we get request : http://localhost:5000/api/values/5 and the type of request is get     
    [Route("api/[controller]")]// at place of controller values is substituted making the values.con...cs class the controller class
    [ApiController]
    public class valuesController : ControllerBase
    {
        private readonly DataContext _context;

        public valuesController(DataContext context)
        {
            _context = context;

        }
        //1) then this method will be called as it has no parameters
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

        //2) then this method will be called as it has a parameter "id"
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(value);
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {

        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}