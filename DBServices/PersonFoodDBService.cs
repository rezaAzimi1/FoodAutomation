using System;
using System.Linq;
using FoodAutomation.Model;

namespace FoodAutomation.Services{
        public class PersonFoodDBService{
        private readonly DBContext _db; 
        public PersonFoodDBService(){
            _db=new DBContext();
        }
        public bool setPersonFood(PersonFood person){
            //for set time by server
            //person.RecordTime=new DateTime();
            try{
                _db.PersonFoods.Add(person);
                _db.SaveChanges();
            }catch (Exception) 
            {
                return false;
                
            }
            return true;
        }
        public PersonFood getPersonFoodById(int personId,int foodId){
            try{
            return _db.PersonFoods.First(pf=>pf.PersonId==personId&&pf.FoodId==foodId);
            }catch(Exception){return null;}
        }
        public bool deletePersonFoodById(int personId,int foodId){
                PersonFood personFood=this.getPersonFoodById(personId,foodId);
                if (personFood==null)return false;
                try{
                _db.Remove(personFood);
                _db.SaveChanges();
                }catch(Exception){
                    return false;
                }  
                return true;
        }
        public bool updatePersonFoodById(PersonFood updatePersonFood,int personId,int foodId){
                PersonFood personFood=this.getPersonFoodById(personId,foodId);
                if (personFood==null)return false;
                try{
                    //If FoodCount, FoodId, and PersonId are not below 0, they will not be placed
                if(updatePersonFood.FoodCount>=0)personFood.FoodCount=updatePersonFood.FoodCount;
                if(updatePersonFood.PersonId>=0)personFood.PersonId=updatePersonFood.PersonId;
                if(updatePersonFood.FoodId>=0)personFood.FoodId=updatePersonFood.FoodId;
                personFood.RecordTime=new DateTime();
                _db.Update(personFood);
                _db.SaveChanges();
                }catch(Exception){
                    return false;
                }  
                return true;
        }
    }
}