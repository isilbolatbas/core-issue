using System.Collections.Generic;
using core_issue.model;

namespace core_issue.Service
{
    public interface IPersonService
    {
        public List<Person> GetPerson();

        public void AddPerson(Person persons);

        public void UpdatePerson(Person persons);

        public void DeletePerson(string id);
        
        Person GetPersons(string id);  
    }
}