namespace RentalApp;                                     

public class Discount
{
    private const float bonus = 0.05f;
    private const float bonus1 = 0.1f;
    private const float bonus2 = 0.15f;
    private float tempDiscount = 0;
     
    public Discount()
    {
        Profit = 0;
        ProcentDiscount = 0;
    }
    
    public float Profit { get; set; }
    public int ProcentDiscount { get; set; }

    public float DiscountCalculation(float fPrice, int day, int numberOfCameras)
    {
        this.Profit = fPrice * day * numberOfCameras;
        if (this.Profit < 0)                 
            this.Profit = this.Profit * (-1);

        if (this.Profit >= 2500 && this.Profit < 5000)
        {
            this.ProcentDiscount = 5;
            tempDiscount = this.Profit;
            tempDiscount *= bonus;
            this.Profit -= tempDiscount;
        }
        else
        if (this.Profit >= 5000 && this.Profit < 8000)
        {
            this.ProcentDiscount = 10;
            tempDiscount = this.Profit;
            tempDiscount *= bonus1;
            this.Profit -= tempDiscount;
        }
        else
        if (this.Profit >= 8000)
        {
            this.ProcentDiscount = 15;
            tempDiscount = this.Profit;
            tempDiscount *= bonus2;
            this.Profit -= tempDiscount;
        }

        return (float)Math.Round(this.Profit, 2);
    }
}
