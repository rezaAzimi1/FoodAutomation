using System;
using System.Linq;
using FoodAutomation.Model;

namespace FoodAutomation.Services{
    public class FoodDBService{
        private readonly DBContext _db; 
        public FoodDBService(){
            _db=new DBContext();
        }
                public Food getFoodById(int id){
            try{
            return _db.Foods.First(f=>f.FoodId==id);
            }catch(Exception){return null;}
        }
        public bool deleteFoodById(int id){
                Food food=this.getFoodById(id);
                if (food==null)return false;
                try{
                _db.Remove(food);
                _db.SaveChanges();
                }catch(Exception){
                    return false;
                }  
                return true;
        }
        public bool setFood(Food food){
            try{
                _db.Foods.Add(food);
                _db.SaveChanges();
            }catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool updateFoodById(Food updateFood,int id){
                Food food=this.getFoodById(id);
                if (food==null)return false;
                try{
                    //
                if(updateFood.FoodName!=null)food.FoodName=updateFood.FoodName;
                if(updateFood.meal!=null)food.meal=updateFood.meal;
                if(updateFood.DateOfservingFood!=null)food.DateOfservingFood=updateFood.DateOfservingFood;
                _db.Update(food);
                _db.SaveChanges();
                }catch(Exception){
                    return false;
                }  
                return true;
        }

    }
}