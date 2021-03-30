using System.Collections.Generic;
using System.Linq;
using core_issue.Database;
using core_issue.model;

namespace core_issue.Service
{
    public class PersonService :IPersonService
    {
        private readonly DatabaseContext _context;  
        
        public PersonService(DatabaseContext context)  
        {  
            _context = context;  
        } 
        
        public List<Person> GetPerson()
        {
            return _context.Person.ToList();
        }

        public void AddPerson(Person persons)
        {
            _context.Person.Add(persons);
            _context.SaveChanges();
        }

        public void UpdatePerson(Person persons)
        {
            _context.Person.Update(persons);  
            _context.SaveChanges();
        }

        public void DeletePerson(string id)
        {
            var person = _context.Person.FirstOrDefault(t => t.id == id);  
            _context.Person.Remove(person);  
            _context.SaveChanges();
        }
        
        public Person GetPersons(string id)  
        {  
            return _context.Person.FirstOrDefault(t => t.id == id);  
        }  
    }
}