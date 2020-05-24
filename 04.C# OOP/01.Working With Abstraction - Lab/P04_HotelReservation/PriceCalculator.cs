namespace P04_HotelReservation
{
    public class PriceCalculator
    {
        public PriceCalculator()
        {

        }

        public PriceCalculator(decimal pricePerDay, int numberOfDays, Season season, Discount discount)
        {
            this.PricePerDay = pricePerDay;
            this.NumberOfDays = numberOfDays;
            this.Season = season;
            this.Discount = discount;
        }

        public PriceCalculator(decimal pricePerDay, int numberOfDays, Season season)
        {
            this.PricePerDay = pricePerDay;
            this.NumberOfDays = numberOfDays;
            this.Season = season;
            this.Discount = Discount.None;
        }

        public Discount Discount { get; set; }

        public int NumberOfDays { get; set; }

        public decimal PricePerDay { get; set; }

        public Season Season { get; set; }

        public decimal Calculate(decimal pricePerDay, int numberOfDays, Season season, Discount discount)
        {
            int multiplier = (int)season;
            decimal discountMultiplier = (decimal)discount / 100;

            decimal priceBeforeDiscount = pricePerDay * multiplier *  numberOfDays;
            decimal discountedAmount = priceBeforeDiscount * discountMultiplier;
            decimal finalPrice = priceBeforeDiscount - discountedAmount;

            return finalPrice;
        }
    }
}
