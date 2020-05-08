namespace FoodAutomation.Services{
    public class FoodDBService{
        private readonly DBContext _db; 
        public FoodDBService(){
            _db=new DBContext();
        }
    }
}