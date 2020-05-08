using System;
using System.Collections.Generic;

namespace FoodAutomation.Model{
    public class Food{
        public int FoodId{get;set;}
        public string FoodName{get;set;}
        public DateTime DateOfservingFood{get;set;}
        public string meal {get;set;}

        public List<PersonFood> PersonFood{get;set;}=new List<PersonFood>();
    }
}