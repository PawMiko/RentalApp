namespace RentalApp.Test
{
    public class Tests
    {
       
        [Test]
        public void Test1()
        {

            //arrange
           var bu= new Statistics();
            int i = 10;
            int x = 10;
            bu.DiscountCalculation(1000, 2, 2);
            //act
          //  float result = i+x;
            float res = bu.Profit;
            //assets

           // Assert.AreEqual(20, result);
            Assert.AreEqual(3800, res);
        }
    }
}