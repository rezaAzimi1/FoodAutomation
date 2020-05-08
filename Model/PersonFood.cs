using System;

namespace FoodAutomation.Model{
    public class PersonFood{
        public DateTime RecordTime{get;set;} 
        public int FoodCount{get;set;}
        public int PersonId{get;set;}
        public int FoodId{get;set;}
        public Person Person {get;set;}
        public Food Food{get;set;}
 
        
    }
}