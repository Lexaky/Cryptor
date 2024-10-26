using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Cryptor
{
    internal class RSA
    {
        private long p, q;
        private long n, m;
        private long d, e;
        private Tuple<long, long> openKeys;
        private Tuple<long, long> privateKeys;

        Alphabet alph;
        public RSA(Alphabet alph)
        {
            this.alph = alph;
            initiateKeysGeneration();
        }
        public RSA(Alphabet alph, long p, long q)
        {
            if (IsTheNumberSimple(p) && IsTheNumberSimple(q))
            {
                this.alph = alph;
                initiateKeysGeneration(p, q);
            } else
            {
                Console.WriteLine("'p' or 'q' is not a simple numbers");
                this.alph = alph;
                initiateKeysGeneration();
                
            }
        }
        private void initiateKeysGeneration(long p = 0, long q = 0)
        {
            if (p == 0 && q == 0)
            {
                Random rand = new Random();
                while (!IsTheNumberSimple(p))
                {
                    p = rand.Next(2, 256);
                }
                while (!IsTheNumberSimple(q))
                {
                    q = rand.Next(2, 256);
                }
            }
 
            Console.WriteLine(q);
            Console.WriteLine(p);
            n = p * q;
            m = (p - 1) * (q - 1);
            d = getD(m);
            e = getE(d, m);

            openKeys = new Tuple<long, long>(e, n);
            privateKeys = new Tuple<long, long>(d, n);
        }
        private bool IsTheNumberSimple(long n)
        {
            if (n < 2)
                return false;

            if (n % 2 == 0)
                return false;

            for (long i = 3; i < n; i++)
                if (n % i == 0)
                    return false;

            return true;
        }
        public string RSA_Dedoce(List<string> input, long d, long n)
        {
            string result = "";

            BigInteger bi;

            foreach (string item in input)
            {
                bi = new BigInteger(Convert.ToDouble(item));
                bi = BigInteger.Pow(bi, (int)d);

                BigInteger n_ = new BigInteger((int)n);

                bi = bi % n_;

                int index = Convert.ToInt32(bi.ToString());

                result += (alph.getSymbol(index)).ToString();
            }

            return result;
        }
        public List<string> RSA_Endoce(string s, long e, long n)
        {
            List<string> result = new List<string>();

            BigInteger bi;

            for (int i = 0; i < s.Length; i++)
            {
                int index = alph.getIndex((char)s[i]);

                bi = new BigInteger(index);
                bi = BigInteger.Pow(bi, (int)e);

                BigInteger n_ = new BigInteger((int)n);

                bi = bi % n_;

                result.Add(bi.ToString());
            }

            return result;
        }
        public void setNewPublicKeys(Tuple <long, long> pair)
        {
            d = pair.Item1;
            n = pair.Item2;
        }
        private long getE(long d, long m)
        {
            long e = 10;

            while (true)
            {
                if ((e * d) % m == 1)
                    break;
                else
                    e++;
            }

            return e;
        }
        private long getD(long m)
        {
            long d = m - 1;

            for (long i = 2; i <= m; i++)
                if ((m % i == 0) && (d % i == 0)) //если имеют общие делители
                {
                    d--;
                    i = 1;
                }

            return d;
        }
        public Tuple <long, long> getPublicKeys()
        {
            return openKeys;
        }
        public Tuple <long, long> getPrivateKeys()
        {
            return privateKeys;
        }
    }
}
