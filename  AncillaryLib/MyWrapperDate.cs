using System;

namespace  FoodAutomation.AncillaryLib{
    public class MyWrapperDate{
            //&date=20091202
            public static DateTime IntDateToDateTime(int date){
            int year = date / 10000;
            int month = ((date - (10000 * year)) / 100);
            int day = (date - (10000 * year) - (100 * month));
            return new DateTime(year, month, day); 
        }
    }
}