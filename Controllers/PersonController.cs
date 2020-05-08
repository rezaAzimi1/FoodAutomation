using FoodAutomation.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodAutomation.Controllers{
    [Route("api")]
    [ApiController]
    public class PersonController:ControllerBase{
        private readonly PersonDBService _db;
        public PersonController(){
            _db=new PersonDBService();
        }
    }
}