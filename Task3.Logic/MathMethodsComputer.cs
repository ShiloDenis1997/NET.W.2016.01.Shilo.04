using System;

namespace Task3.Logic
{
    public static class MathMethodsComputer
    {
        /// <summary>
        /// Method computes root of n degree from <paramref name="value"/>. It uses
        /// Newton's method
        /// </summary>
        /// <param name="value"></param>
        /// <param name="power">degree of root</param>
        /// <param name="epsilon">accurancy of calculations</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws int next situations:
        /// 1. <paramref name="power"/> is less than 1;</exception>
        /// 2. <paramref name="power"/> is even 
        /// and <paramref name="value"/> is less than zero
        /// 3. <paramref name="epsilon"/> is less or equal than 0 or greater or 
        /// equal than 1
        public static double Sqrtn(this double value, int power, double epsilon)
        {
            if (power < 1)
                throw new ArgumentException
                    ($"{nameof(power)} must be equal or greater than 1");
            if (value < 0 && ((power & 1) == 0))
                throw new ArgumentException
                    ($"{nameof(power)} is even. {nameof(value)} " +
                     "must be equal or greater than 0 ");
            if (!(epsilon > 0 && epsilon < 1))
                throw new ArgumentException
                    ($"{epsilon} must be greater than 0 and less than 1");
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
