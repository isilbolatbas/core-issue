using System;
using core_issue.Database;
using core_issue.model;
using core_issue.Service;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace test_api_issue
{
    public class UnitTest1
    {

        [Fact]
        public void addPersonTest()
        {
            var person1 = new Person() {id=  "klddhjfs", firstname = "lşs", lastname= "lşkf" };
            var person2 = new Person() {id=  "kdfhgvslds", firstname = "lşs", lastname= "lşkf" };
 
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("person_db")
                .Options;
 
            using (var context = new DatabaseContext(options))
            {
                var repository = new PersonService(context);
                repository.AddPerson(person1);
                repository.AddPerson(person2);
                context.SaveChanges();
            }
 
            using (var context = new DatabaseContext(options))
            {
                var repository = new PersonService(context);
                repository.GetPerson().Count.Equals(2);

            }
        }
        
        [Fact]
        public void deletePersonTest()
        {
            var person1 = new Person() {id=  "klds", firstname = "lşs", lastname= "lşkf" };
            var person2 = new Person() {id=  "kdflds", firstname = "lşs", lastname= "lşkf" };
 
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("person_db")
                .Options;
 
            using (var context = new DatabaseContext(options))
            {
                var repository = new PersonService(context);
                repository.AddPerson(person1);
                repository.AddPerson(person2);
                context.SaveChanges();
            }
 
            using (var context = new DatabaseContext(options))
            {
                var repository = new PersonService(context);
                repository.DeletePerson(person1.id);
                context.SaveChanges();
            }
 
            using (var context = new DatabaseContext(options))
            {
                var repository = new PersonService(context);
                repository.GetPerson().Count.Equals(1);
            }
        }
    }
}