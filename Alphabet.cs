using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptor
{
    internal class Alphabet
    {
        private char[]? alphabet = null;

        public Alphabet(char[] alphabet)
        {
            if (alphabet.Length > 0)
            {
                this.alphabet = new char[alphabet.Length];
                this.alphabet = alphabet;
            }
        }
        public Alphabet(Alphabet alph, int startSymbol)
        {
            alphabet = new char[alph.getSize()];
            for (int i = 0; i < alph.getSize(); i++, startSymbol++)
            {
                alphabet[i] = alph.getSymbol(startSymbol);
            }
        }
        public Alphabet(Alphabet alph)
        {
            if (alph.getSize() <= 0)
            {
                Console.WriteLine("Alphabet in copy-constructor is empty");
                return;
            }
            this.alphabet = new char[alph.getSize()];
            for (int i = 0; i < alph.getSize(); i++)
            {
                this.alphabet[i] = alph.getSymbol(i);
            }
        }
        public char getSymbol(int index)
        {
            if (alphabet != null)
            {
                index %= alphabet.Length;
                if (index < 0)
                {
                    return alphabet[alphabet.Length + index % alphabet.Length];
                }
                else
                {
                    return alphabet[index];
                }
            }
                return '\0';
            
        }

        public int getIndex(char symbol)
        {
            if (alphabet != null)
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (alphabet.ElementAt(i) == symbol)
                    return i;
            }
            return -1;
        }
        
        public void print()
        {
            if (alphabet == null || alphabet.Length == 0)
            {
                Console.WriteLine("Alphabet is empty!");
            } else
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    Console.Write(alphabet.ElementAt(i) + " ");
                }
                Console.WriteLine();
            }
        }
        public int getSize()
        {
            if (alphabet != null)
                return alphabet.Length;
            else
                return -1;
        }
        ~Alphabet()
        {
            if (alphabet == null)
                Console.WriteLine("Alphabet is empty");
            Console.WriteLine("Destroying Alphabet object");
        }
    }
}
