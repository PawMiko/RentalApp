namespace RentalApp.Test
{
    public class Tests
    {
       
        [Test]
        public void CheckResultAfterDiscount()
        {

            //arrange
           var res= new Statistics();
            
            res.DiscountCalculation(999.998f, 2, 2);
            //act
          // 
            var result = res.Profit;
            //assets

           
            Assert.AreEqual(3799.99, Math.Round(result,2));
        }
        [Test]
        public void CheckAverageProfitsPerDay()
        {

            //arrange
            var res = new Statistics();

            res.AddCashInMemoryOrFile(1000, 2, 3800);
         
            //act
            // 
            float result = res.AverageProfitsPerDay;
            //assets

            
            Assert.AreEqual(1900, result);
        }
        [Test]
        public void CheckTheDiscountAmount()
        {

            //arrange
            var res = new Statistics();

            res.DiscountCalculation(1000, 2, 2);
            //act
            // 
            float result = res.ProcentDiscount;
            //assets


            Assert.AreEqual(5, result);
        }
    }
}