using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//封装素数的类利用迭代器枚举上下限之间的素数集合

namespace cs_lesson4
{
    public class Primes
    {
        private long min;
        private long max;
        public Primes() : this(2, 100)
        {
        }
        public Primes(long minimum, long maximum)
        {
            if (min < 2)           //限制最小值素数2
                min = 2;
            else
                min = minimum;
            max = maximum;
        }
        public IEnumerator GetEnumerator()
        {
            for (long possiblePrime = min; possiblePrime <= max; possiblePrime++)  //提取上下限之间的素数
            {
                bool isPrime = true;      //假设从这个数开始
                for (long possibleFactor = 2; possibleFactor <=
                (long)Math.Floor(Math.Sqrt(possiblePrime)); possibleFactor++)    //判断是否是素数，该数能否被2到该数的平方根之间所有数整除
                {
                    long remainderAfterDivision = possiblePrime % possibleFactor;
                    if (remainderAfterDivision == 0)     //能被整除，不是素数
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)       //素数，使用yield传给foreach
                {
                    yield return possiblePrime;   
                }
            }
        }
        
        class Program
        {
            static void Main(string[] args)
            {
                Primes primesFrom2To1000 = new Primes(2, 1000);    //数值范围
                foreach (long i in primesFrom2To1000)
                    Console.Write("{0} ", i);     //输出该值
                Console.ReadKey();
            }

        }
    }
}