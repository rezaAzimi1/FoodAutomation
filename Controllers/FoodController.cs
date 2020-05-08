using FoodAutomation.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodAutomation.Controllers{
    [Route("api")]
    [ApiController]
    public class FoodController:ControllerBase{
        int adminUser=123456;
        string adminPass="de1399";
        private readonly GeneralDBService _db;
        public FoodController(){
            _db=new GeneralDBService();
        }
    }
}