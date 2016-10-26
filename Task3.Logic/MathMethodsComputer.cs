using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Logic
{
    public static class MathMethodsComputer
    {
        public static double Sqrtn(this double value, int power, double epsilon)
        {
            if (power < 1)
                throw new ArgumentException("power must be equal or greater than 1");
            if (value < 0)
                throw new ArgumentException("vaue must be equal or greater than 0 ");
            if (epsilon <= 0)
                throw new ArgumentException("epsilon must be greater than 0");
            double xk;
            double xkp1 = 1;
            do
            {
                xk = xkp1;
                xkp1 = SqrtnNewtonIteration(xk, value, power);
            } while (Math.Abs(xk - xkp1) > epsilon);

            return xkp1;
        }

        private static double SqrtnNewtonIteration(double xk, double value, int power)
        {
            return ((power - 1) * xk + value / Math.Pow(xk, power - 1)) / power;
        }
    }
}
