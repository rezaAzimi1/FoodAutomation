using System;
using FoodAutomation.AncillaryLib;
using FoodAutomation.Services;
using Microsoft.AspNetCore.Mvc;


namespace FoodAutomation.Controllers{
    [Route("api")]
    [ApiController]
    public class Controller:ControllerBase{
        int adminUser=123456;
        string adminPass="de1399";
        private readonly GeneralDBService _db;
        public Controller(){
            _db=new GeneralDBService();
        }
               [HttpGet("{type}")]
        public ActionResult getEntity(string type,int id,string pass,int date){
            try{
            //https://localhost:5001/api/person?id=1&pass=101010
            if (type == "person"){
                var data =_db.getPersonByIDPass(id,pass);
                if(data!=null)return Ok(data);
                else return NotFound();
            //https://localhost:5001/api/food?id=123456&pass=de1399&date=20200728
            }else if(type == "food"){
                if(adminUser==id&&adminPass==pass){
                    var data =_db.getFoodOfDate50ago(MyWrapperDate.IntDateToDateTime(date));
                    if(data!=null)return Ok(data);
                    else return NotFound();
                }else return BadRequest();
            //https://localhost:5001/api/personOrders?id=1&pass=101010&date=20200728
            }else if(type=="personOrders"){
                //&date=20091202
                var data=_db.getFoodlistPerson(id,pass,MyWrapperDate.IntDateToDateTime(date));
                if(data!=null)return Ok(data);
                else return NotFound();
            }else return BadRequest();
            }catch(Exception){
                return BadRequest();
            }
        }
    }
}