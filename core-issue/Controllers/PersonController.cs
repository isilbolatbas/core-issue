using System;
using System.Collections.Generic;
using core_issue.model;
using core_issue.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace core_issue.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]  
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service;
        
        public PersonController(IPersonService service)
        {
            _service = service;
        }
        
        [HttpGet]  
        public IEnumerable<Person> Get()  
        {  
            return _service.GetPerson();  
        }  
        
        [HttpPost]  
        public IActionResult Create([FromBody]Person person)  
        {  
            if (ModelState.IsValid)  
            {  
                Guid obj = Guid.NewGuid();  
                person.id = obj.ToString();  
                _service.AddPerson(person);  
                return Ok();  
            }  
            return BadRequest();  
        } 
        
        [HttpPut]  
        public IActionResult Edit([FromBody]Person person)  
        {  
            if (ModelState.IsValid)  
            {  
                _service.UpdatePerson(person);  
                return Ok();  
            }  
            return BadRequest();  
        } 
        
        [HttpDelete("{id}")]  
        public IActionResult DeleteConfirmed(string id)  
        {  
            var data = _service.GetPersons(id);  
            if (data == null)  
            {  
                return NotFound();  
            }  
            _service.DeletePerson(id);  
            return Ok();  
        } 


    }
}