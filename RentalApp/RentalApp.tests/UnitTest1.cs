namespace RentalApp.tests
{
    public class Tests
    {
       
        public void Test1()
        {

            //aarange
            var buisnes = new Statistics();
            float cameraCost;
            int numberOfCameras;
            int numberOdDay; 
             buisnes.DiscountCalculation(1000, 4, 4);


            //act
            var test =3+3;
            //assert

            Assert.AreEqual(333,test);
        }
    }
} 