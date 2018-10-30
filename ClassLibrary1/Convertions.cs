using System;

namespace Server
{
    public class Convertions
    {
        public double GramsToOunces(double Grams)
        {
            return Grams / 28.3495;
        }

        public double OuncesToGrams(double Ounces)
        {
            return Ounces * 28.3495;
        }
    }
}
