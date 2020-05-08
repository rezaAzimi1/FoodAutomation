namespace FoodAutomation.Services{
    public class GeneralDBService{
        private readonly DBContext _db; 
        public GeneralDBService(){
            _db=new DBContext();
        }
    }
}