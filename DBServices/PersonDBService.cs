namespace FoodAutomation.Services{
    public class PersonDBService{
        private readonly DBContext _db; 
        public PersonDBService(){
            _db=new DBContext();
        }
    }
}