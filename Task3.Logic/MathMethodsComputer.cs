using System;

namespace Task3.Logic
{
    public static class MathMethodsComputer
    {
        /// <summary>
        /// Method computes root of n degree from value. It uses
        /// Newton's method
        /// </summary>
        /// <param name="value"></param>
        /// <param name="power">degree of root</param>
        /// <param name="epsilon">accurancy of calculations</param>
        /// <returns></returns>
        public static double Sqrtn(this double value, int power, double epsilon)
        {
            if (power < 1)
                throw new ArgumentException("power must be equal or greater than 1");
            if (value < 0)
                throw new ArgumentException("vaue must be equal or greater than 0 ");
            if (epsilon <= 0)
                throw new ArgumentException("epsilon must be greater than 0");
            double xk;
            epsilon /= 10;
            double xkp1 = 1;
            do
            {
                xk = xkp1;
                xkp1 = SqrtnNewtonIteration(xk, value, power);
            } while (Math.Abs(xk - xkp1) > epsilon);

            return xkp1;
        }

        /// <summary>
        /// Do one iteration of Newton's method
        /// </summary>
        /// <param name="xk">current approximation</param>
        /// <param name="value">original value</param>
        /// <param name="power">degree of root</param>
        /// <returns>next approximation of sqrtn(value)</returns>
        private static double SqrtnNewtonIteration(double xk, double value, int power)
        {
            return ((power - 1) * xk + value / Math.Pow(xk, power - 1)) / power;
        }
    }
}
