using System.Collections.Generic;

namespace FoodAutomation.Model{
    public class Person{
        public int PersonId{get;set;}
        
        public string Pass{get;set;}
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public string Post{get;set;}

        public List<PersonFood> PersonFood{get;set;}=new List<PersonFood>();
    }
}