using FoodAutomation.Model;
using FoodAutomation.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodAutomation.Controllers{
    [Route("api/person")]
    [ApiController]
    public class PersonController:ControllerBase{
        private readonly PersonDBService _db;
        public PersonController(){
            _db=new PersonDBService();
        }
        // https://localhost:5001/api/person
        // {
        //     "pass": "44444",
        //     "firstName": "متین",
        //     "lastName": "امینی",
        //     "post": "مدرس",
        //     "personFood": []
        // }
        [HttpPost]
        public ActionResult setPerson(Person personIn){
            if(_db.setPerson(personIn))return Ok(personIn);
            else return BadRequest();
        }
        //https://localhost:5001/api/person/d?id=5&pass=44444
        [HttpDelete("{type}")]
        public ActionResult deletePersonById(string type,int id,string pass){
                if(_db.deletePersonById(id,pass))return Ok();
                else return NotFound();
        }
        //https://localhost:5001/api/person/u?id=6&pass=44444
        // {
        //     "pass": "44444",
        //     "firstName": null,
        //     "lastName": null,
        //     "post": " مدرس",
        //     "personFood": []
        // }
        [HttpPut("{type}")]
        public ActionResult UpdatePerson(string type,int id,string pass,Person personUpdate){
            if(_db.updatePersonById(personUpdate,id,pass))return Ok();
            else return BadRequest();
        }
    }
}