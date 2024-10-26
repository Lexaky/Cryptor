using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptor
{
    internal class Cesar
    {
        private Alphabet alph;
        private int key;
        private string data;
        private bool isDataComplete = false;
        public Cesar(Alphabet alph, string data, int key = 0)
        {
            this.alph = alph;
            if (data.Length != 0)
            {
                data = data.ToLower();
                for (int i = 0; i < data.Length; i++)
                {
                    if (alph.getIndex(data.ElementAt(i)) < 0)
                    {
                        Console.WriteLine("Data contains symbols not included in alphabet!");
                        return;
                    }
                }
                this.key = key;
                this.data = data;
                isDataComplete = true;
            }
            else
            {
                Console.WriteLine("Data is null");
                return;
            }
        }

        public string getCryptString()
        {
            if (isDataComplete == true)
            {
                string cryptoString = "";
                for (int i = 0; i < data.Length; i++)
                {
                    cryptoString += alph.getSymbol(alph.getIndex(data.ElementAt(i)) + key);
                }
                return cryptoString;
            }
            else
            {
                return "";
            }
        }
        public string getDecryptString()
        {
            return getDecryptString(this.data);
        }
        public string getDecryptString(string str)
        {
            string decryptoString = "";
            for (int i = 0; i < str.Length; i++)
            {
                decryptoString += alph.getSymbol(alph.getIndex(str.ElementAt(i)) - key);
            }
            return decryptoString;
        }
    
        ~Cesar()
        {
            Console.WriteLine("Cesar alphabet was deleted");
        }
    }
}
