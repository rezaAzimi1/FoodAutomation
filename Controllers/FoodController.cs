using FoodAutomation.Model;
using FoodAutomation.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodAutomation.Controllers{
    [Route("api/food")]
    [ApiController]
    public class FoodController:ControllerBase{
        int adminUser=123456;
        string adminPass="de1399";
        private readonly FoodDBService _db;
        public FoodController(){
            _db=new FoodDBService();
        }
        //https://localhost:5001/api/food
        // {
	    //     "foodName":"قیمه",
        // 	"dateOfservingFood":"2020-10-06T00:00:00",
	    //     "meal":"نهار",
	    //     "personFood":[]
        // }
        [HttpPost]
        public ActionResult setFood(Food foodIn){
            if(_db.setFood(foodIn))return Ok(foodIn);
            else return BadRequest();
        }
        //https://localhost:5001/api/food/2?id=123456&pass=de1399
        [HttpDelete("{foodid}")]
        public ActionResult deleteFoodById(int foodid,int id,string pass){
            if(adminUser==id&&adminPass==pass){
                if(_db.deleteFoodById(foodid))return Ok();
                else return NotFound();
            }else return BadRequest();
        }
        //https://localhost:5001/api/food/7?id=123456&pass=de1399
        // {
        //     "foodName":null,
        //     "dateOfservingFood":"2020-10-07T00:00:00",
        //     "meal":"شام",
        //     "personFood":[]
        // }
        [HttpPut("{foodid}")]
        public ActionResult UpdateFood(int foodid,int id,string pass,Food food){
            if(adminUser==id&&adminPass==pass){
                if(_db.updateFoodById(food,foodid))return Ok();
                else return BadRequest();
            }else return NotFound();
        }
    }
}