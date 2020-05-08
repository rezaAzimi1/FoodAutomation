using System;
using System.Linq;
using FoodAutomation.Model;

namespace FoodAutomation.Services{
    public class PersonDBService{
        private readonly DBContext _db; 
        public PersonDBService(){
            _db=new DBContext();
        }
                public bool setPerson(Person person){
            try{
                _db.Persons.Add(person);
                _db.SaveChanges();
            }catch (Exception)
            {
                return false;
            }
            return true;
        }
        public Person getPersonById(int id,string pass){
            try{
            return _db.Persons.First(p=>p.PersonId==id&&p.Pass==pass);
            }catch(Exception){return null;}
        }
        public bool deletePersonById(int id,string pass){
                Person person=this.getPersonById(id,pass);
                if (person==null)return false;
                try{
                _db.Remove(person);
                _db.SaveChanges();
                }catch(Exception){
                    return false;
                }  
                return true;
        }
        public bool updatePersonById(Person updatePerson,int id,string pass){
                Person person=this.getPersonById(id,pass);
                if (person==null)return false;
                try{
                if(updatePerson.FirstName!=null)person.FirstName=updatePerson.FirstName;
                if(updatePerson.LastName!=null)person.LastName=updatePerson.LastName;
                if(updatePerson.Pass!=null)person.Pass=updatePerson.Pass;
                if(updatePerson.Post!=null)person.Post=updatePerson.Post;
                _db.Update(person);
                _db.SaveChanges();
                }catch(Exception){
                    return false;
                }  
                return true;
        }
    }
}