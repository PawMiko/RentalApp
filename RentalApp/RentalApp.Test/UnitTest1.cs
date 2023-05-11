namespace RentalApp.Test;

public class Tests
{

    [Test]
    public void CheckResultAfterDiscount()
    {

        var res = new Discount();

        res.DiscountCalculation(999.998f, 2, 2);

        var result = res.Profit;

        Assert.AreEqual(3799.99, Math.Round(result, 2));
    }

    [Test]
    public void CheckAverageProfitsPerDay()
    {

        var restat = new Statistics();

        restat.AddCashToStat(1000, 2, 3800);
        restat.AddCashToStat(1000, 2, 3800);

        float result = restat.AverageProfitsPerDay;

        Assert.AreEqual(1900, result);
    }

    [Test]
    public void CheckTheDiscountAmount()
    {
        var res = new Discount();

        res.DiscountCalculation(1000, 2, 2);

        float result = res.ProcentDiscount;

        Assert.AreEqual(5, result);
    }
}