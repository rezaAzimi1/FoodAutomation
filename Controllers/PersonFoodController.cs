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
        //https://localhost:5001/api/order
        // {
        //     "recordTime": "2020-05-06T14:50:31.6339372",
        //     "foodCount": 6,
        //     "personId": 2,
        //     "foodId": 1,
        //     "person": null,
        //     "food": null
        // }
        [HttpPost]
        public ActionResult setPersonFood(PersonFood personFoodIn){
            if(_db.setPersonFood(personFoodIn))return Ok(personFoodIn);
            else return BadRequest();
        }
        //https://localhost:5001/api/order/d?personId=2&foodId=1
        [HttpDelete("{type}")]
        public ActionResult deletePersonFoodById(string type,int personId,int foodId){
                if(_db.deletePersonFoodById(personId,foodId))return Ok();
                else return NotFound();
        }
        //https://localhost:5001/api/order/u?personId=2&foodId=1
        // {
        //     "recordTime": "2020-05-06T14:50:31.6339372",
        //     "foodCount": 4,
        //     "personId": -1,
        //     "foodId": -1,
        //     "person": null,
        //     "food": null
        // }
        //****recordTime can be any value****
        [HttpPut("{type}")]
        public ActionResult UpdatePersonFood(string type,int personId,int foodId,PersonFood personFoodUpdate){
            System.Console.WriteLine(personFoodUpdate.FoodId);
            if(_db.updatePersonFoodById(personFoodUpdate,personId,foodId))return Ok();
            else return BadRequest();
        }
    }
}