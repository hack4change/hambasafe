using System;

namespace Hambasafe.Services.Helper
{
    public static class DistanceCalculator
    {
        public static double Distance(double latitude1, double longitude1, double latitude2, double longitude2)
        {
            var theta = longitude1 - longitude2;
            var distance = Math.Sin(DegreesToRadians(latitude1)) * Math.Sin(DegreesToRadians(latitude2)) + 
                           Math.Cos(DegreesToRadians(latitude1)) * Math.Cos(DegreesToRadians(latitude2)) * Math.Cos(DegreesToRadians(theta));

            distance = Math.Acos(distance);
            distance = RadiansToDegrees(distance);

            return distance * 60 * 1.853159616;
        }

        private static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }

        private static double RadiansToDegrees(double radians)
        {
            return radians / Math.PI * 180.0;
        }
    }
}
