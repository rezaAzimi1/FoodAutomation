using System;
using System.Collections.Generic;
using System.Linq;
using FoodAutomation.Model;
using Microsoft.EntityFrameworkCore;

namespace FoodAutomation.Services{
    public class GeneralDBService{
        private readonly DBContext _db; 
        public GeneralDBService(){
            _db=new DBContext();
        }
        public Person getPersonByIDPass(int personId,string pass){
            try{
                return _db.Persons.First(p=>p.PersonId==personId && p.Pass==pass);
            }catch (Exception)
            {
                return null;
            }
        }
        public Person getPersonByIDPassFull(int personId,string pass){
            try{
                return _db.Persons.Include(p=>p.PersonFood).ThenInclude(pf=>pf.Food).First(p=>p.PersonId==personId&&p.Pass==pass);
            }catch (Exception)
            {
                return null;
            }
        }
        public List<Food> getFoodlistPerson(int personId,string pass,DateTime datea){
            try{
            //datea is now
            int lowLimit=-24;
            int highLimit=26;
            var query= (from f in _db.Foods 
                    where f.DateOfservingFood <= datea.AddDays(highLimit).Date && f.DateOfservingFood >= datea.AddDays(lowLimit).Date select new Food{
                        FoodId=f.FoodId,
                        FoodName=f.FoodName,
                        DateOfservingFood=f.DateOfservingFood,
                        meal=f.meal,
                        PersonFood=((List<PersonFood>)(from innerp in _db.Persons 
                                    join innerpf in  _db.PersonFoods on innerp.PersonId equals innerpf.PersonId
                                    join innerf in _db.Foods on innerpf.FoodId equals innerf.FoodId
                                    where innerp.Pass == pass && innerp.PersonId==personId && innerpf.FoodId==f.FoodId select new PersonFood{
                                         RecordTime =innerpf.RecordTime,
                                         FoodCount=innerpf.FoodCount,
                                         PersonId=innerpf.PersonId,
                                         FoodId=innerpf.FoodId
                                    }))
                    }).ToList();
            return query;
            }catch{
                return null;
            }
        }
        public List<Food> getFoodOfDate50ago(DateTime date){
            try{    
                //date is now
                int lowLimit=-50;
                var query= (from f in _db.Foods 
                where f.DateOfservingFood >= date.AddDays(lowLimit).Date select new Food{
                FoodId=f.FoodId,
                FoodName=f.FoodName,
                DateOfservingFood=f.DateOfservingFood,
                meal=f.meal,}).ToList();
            return query;            
            }catch (Exception)
            {
                return null;
            }
        }
        public bool orderFood(PersonFood order){
            try{
                _db.PersonFoods.Add(order);
                _db.SaveChanges();
            }catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}