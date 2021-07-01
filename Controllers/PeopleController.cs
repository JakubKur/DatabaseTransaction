using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseTransaction.Database;
using DatabaseTransaction.Interfaces;

namespace DatabaseTransaction.Controllers
{
    [ApiController]
    public class PeopleController : ControllerBase
    {
        IDataService _service;

        public PeopleController(IDataService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("/people")]
        public async Task<JsonResult> GetPeople()
        {
            var persons = await _service.GetPeople();
            return new JsonResult(persons);
        }

        [HttpGet]
        [Route("/addperson")]
        public async Task<JsonResult> AddPerson()
        {
            People p = new();
            p.PersonId = Guid.NewGuid().ToString();
            p.Name = "Jarek";
            p.DateCreated = DateTime.Now;
            bool result = await _service.AddPerson(p);
            if (result)
                return new JsonResult("Dodano");
            else
                return new JsonResult("Error");
        }


        [HttpGet]
        [Route("/addpeople")]
        public async Task<JsonResult> AddPeople()
        {
            var people = new List<People>();
            People p1 = new();
            p1.PersonId = Guid.NewGuid().ToString();
            p1.Name = "Mariusz";
            p1.DateCreated = DateTime.Now;

            People p2 = new();
            p2.PersonId = Guid.NewGuid().ToString();
            p2.Name = "Krzysztof";
            p2.DateCreated = DateTime.Now.AddDays(1);

            people.Add(p1);
            people.Add(p2);


            await _service.AddPeopleByTransaction(people);
            return new JsonResult("Chyba Dodano");

        }

    }
}
