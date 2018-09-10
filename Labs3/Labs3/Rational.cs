using System;

namespace Labs3
{
    public struct Rational
    {
        public Rational(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new DivideByZeroException();
            Numerator = numerator;
            Denominator = denominator;
            Even();
        }
        /// Числитель дроби
        public int Numerator { get; set; }
        /// Знаменатель дроби
        public int Denominator { get; set; }
        /// Целая часть числа Z.N:D, Z. получается делением числителя на знаменатель и
        /// отбрасыванием остатка
        public int Base { get { return Numerator / Denominator; } }
        ///// Дробная часть числа Z.N:D, N:D
        public int Fraction { get { return Numerator % Denominator; } }
        /// Операция сложения, возвращает новый объект - рациональное число,
        /// которое является суммой чисел c и this
        /// 

        public Rational Add(Rational c)
        {
            var lcm = MyMath.LeastCommonMultiply(Denominator,c.Denominator);
            var newNumerator = Numerator*lcm/Denominator;
            c.Numerator *=  lcm/c.Denominator;
            return new Rational(newNumerator + c.Numerator, lcm);
        }

        public Rational Sub(Rational c)
        {
            return Add(c.Negate());
        }
        /// Операция смены знака, возвращает новый объект - рациональное число,
        /// которое являтеся разностью числа 0 и this
        public Rational Negate()
        {
            return new Rational(-Numerator,Denominator);
        }
        /// Операция умножения, возвращает новый объект - рациональное число,
        /// которое является результатом умножения чисел x и this
        public Rational Multiply(Rational x)
        {
            return new Rational(Numerator*x.Numerator,Denominator*x.Denominator);
        }
        /// Операция деления, возвращает новый объект - рациональное число,
        /// которое является результатом деления this на x
        public Rational DivideBy(Rational x)
        {
            return new Rational(Numerator*x.Denominator,Denominator*x.Numerator);
        }

        public override string ToString()
        {
            return Base==0? String.Format("{0}:{1}", Fraction.ToString(), Denominator.ToString()) :
                String.Format("{0}.{1}:{2}", Base.ToString(),Fraction.ToString(), Denominator.ToString());
        }
        /// Создание экземпляра рационального числа из строкового представления Z.N:D
        /// допускается N > D, также допускается
        /// Строковое представления рационального числа
        /// Результат конвертации строкового представления в рациональное
        /// число
        /// true, если конвертация из строки в число была успешной,
        /// false если строка не соответствует формату
        /// 
        
        public static bool TryParse(string input, out Rational result)
        {
            try
            {
                var inputSplited = input.Split('.');
                int integerPart=0;
                if (inputSplited.Length == 2)
                {
                    integerPart = Convert.ToInt32(inputSplited[0]);
                    inputSplited = inputSplited[1].Split(':');
                }
                else
                    inputSplited = inputSplited[0].Split(':');
                var denominator = Convert.ToInt32(inputSplited[1]);
                var numerator = Convert.ToInt32(inputSplited[0]) + integerPart * denominator;
                result = new Rational(numerator, denominator);
                return true;
            }
            catch(Exception e)
            {
                result = new Rational();
                return false;
            }
        }
        /// Приведение дроби - сокращаем дробь на общие делители числителя
        /// и знаменателя. Вызывается реализацией после каждой арифметической операции
        private void Even()
        {
            var gcd = MyMath.GreatestCommonDivisor(Numerator,Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
        }

        public static Rational operator +(Rational c1, Rational c2)
        {
            return c1.Add(c2);
        }
        public static Rational operator -(Rational c1, Rational c2)
        {
            return c1.Sub(c2);
        }
        public static Rational operator *(Rational c1, Rational c2)
        {
            return c1.Multiply(c2);
        }
        public static Rational operator /(Rational c1, Rational c2)
        {
            return c1.DivideBy(c2);
        }
    }
}
