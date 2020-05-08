using Microsoft.AspNetCore.Mvc;
using FoodAutomation.Services;
using FoodAutomation.Model;

namespace FoodAutomation.Controllers{
    [Route("api/order")]
    [ApiController] 
    public class PersonFoodController:ControllerBase{
        private readonly PersonFoodDBService _db;
        public PersonFoodController(){
            _db=new PersonFoodDBService();
        }
        [HttpGet("{type}")]
        public ActionResult GetAction(int type,int personId,int foodId){
            return Ok(_db.getPersonFoodById(personId,foodId));
        }
        [HttpPost]
        public ActionResult setPersonFood(PersonFood personFoodIn){
            if(_db.setPersonFood(personFoodIn))return Ok(personFoodIn);
            else return BadRequest();
        }

        [HttpDelete("{type}")]
        public ActionResult deletePersonFoodById(string type,int personId,int foodId){
                if(_db.deletePersonFoodById(personId,foodId))return Ok();
                else return NotFound();
        }
        
        [HttpPut("{type}")]
        public ActionResult UpdatePersonFood(string type,int personId,int foodId,PersonFood personFoodUpdate){
            if(_db.updatePersonFoodById(personFoodUpdate,personId,foodId))return Ok();
            else return BadRequest();
        }
    }
}