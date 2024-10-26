using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptor
{
    internal class Vigener
    {
        private string? key = null;
        private string? saveKey = null;
        private Alphabet[] vectorAlph;
        public Vigener(Alphabet alph, string key)
        {
            if (key != null && key.Length > 0)
            {
                this.key = key;
                
                    //Creating of 1-dim empty alphabet
                    saveKey = key;
                    vectorAlph = new Alphabet[alph.getSize()];
                    for (int i = 0; i < alph.getSize(); i++)
                    {
                        vectorAlph[i] = new Alphabet(alph, i);
                    }
                    
                    Console.WriteLine("Created 2-dim Alphabet: ");
                    for (int i = 0; i < alph.getSize(); i++)
                    {
                        vectorAlph[i].print();
                    }
                    return;
                
            } else
            {
                Console.WriteLine("Key is null. Break");
                return;
            }
        }
        
        public string getCryptString(string data)
        {
            if (nullAndEmptyCheck())
                return "";
            key = saveKey;
            if (key.Length < data.Length)
            {
                int startLength = key.Length;
                int j = startLength;
                while (j != data.Length)
                {
                    key += key[j - startLength];
                    j++;
                }
            }

            string message = "";
            Alphabet temporaryAlphabet = new Alphabet(vectorAlph[0]);
            for (int i = 0; i < data.Length; i++)
            {
                message += vectorAlph[temporaryAlphabet.getIndex(data[i])].getSymbol(temporaryAlphabet.getIndex(key[i]));
            }
            return message;
        }
        public string getDecryptString(string data)
        {
            if (nullAndEmptyCheck())
                return "";
            if (data == null || data.Length == 0) 
                return "";
            string message = data;
            key = saveKey;
            if (key.Length < message.Length)
            {
                int startLength = key.Length;
                int j = startLength;
                while (j != message.Length)
                {
                    key += key[j - startLength];
                    j++;
                }
            }
            string decryptMessage = "";
            Alphabet temporaryAlphabet = new Alphabet(vectorAlph[0]);
            for (int i = 0; i < message.Length; i++)
            {
                decryptMessage += temporaryAlphabet.getSymbol(vectorAlph[temporaryAlphabet.getIndex(key[i])].getIndex(message[i]));
            }
            return decryptMessage;
        }

        public void changeKey(string newKey)
        {
            if (newKey != null && newKey.Length > 0)
            {
                saveKey = newKey;
            }
        }
        private bool nullAndEmptyCheck()
        {
            if (key == null || key.Length == 0 || vectorAlph.Length == 0)
                return true;
            return false;
        }

        ~Vigener()
        {
            Console.WriteLine("Vigener object was deleted");
        }
    }
}
