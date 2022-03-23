namespace RecipeConverterApp
{
    internal class Converter
    {   
        public static double ConvertUnit(double amountToConvert, string convertingFrom, string convertingTo)
        {
            // First step in conversion is to find the starting unit of measurement.
            var unitFrom = CookingUnit.CookingList.Single(x => x.Name.ToLower() == convertingFrom.ToLower() || x.Abbreviation.ToLower() == convertingFrom.ToLower());
            
            // Second step is to get the amount of the starting unit of measurement in milliliters.
            var firstCalc = amountToConvert * unitFrom.MilliliterEquivalent;

            // Third step is to get the desired unit of measurement we are converting to.
            var unitTo = CookingUnit.CookingList.Single(x => x.Name.ToLower() == convertingTo.ToLower() || x.Abbreviation.ToLower() == convertingTo.ToLower());
            
            // Last step is to divide the first calculation by the milliliters amount of our desired unit of measurement and return it.
            return firstCalc / unitTo.MilliliterEquivalent;
        }
    }
}