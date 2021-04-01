using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core_issue.Controllers;
using core_issue.Database;
using core_issue.model;
using core_issue.Service;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace fluent_test_api
{

    public class PersonTestWithFluent
    {

        [Fact]
        public void GetAllPersonTest()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("person_db")
                .Options;

            var context = new DatabaseContext(options);
            // Arrange
            var controller = new PersonController(new PersonService(context));

            // Act
            var result =  controller.Get();

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var persons = okResult.Value.Should().BeAssignableTo<IEnumerable<Person>>().Subject;

            persons.Count().Should().Be(50);
        }
        
        [Fact]
        public void personAddTest()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("person_db")
                .Options;

            var context = new DatabaseContext(options);
            // Arrange
            var controller = new PersonController(new PersonService(context));
            var newPerson = new Person
            {
                id = "60",
                firstname = "Selma",
                lastname = "Bolatbas",
            };

            // Act
            var result =  controller.Create(newPerson);

            // Assert
            var okResult = result.Should().BeOfType<CreatedAtActionResult>().Subject;
            var person = okResult.Value.Should().BeAssignableTo<Person>().Subject;
            person.id.Should().Be("61");
            
        }
        
      


    }

}





