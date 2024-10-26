using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptor
{
    internal class CommunicationChannel
    {
        private Tuple<long, long> publicKeys;
        List <string> message;

        public CommunicationChannel()
        {
            Console.WriteLine("Channel for communications was created at " + DateTime.Now);
        }

        public void setPublicKeys(Tuple <long, long> publicKeys)
        {
            Console.WriteLine("Channel contains new pair public keys: " + publicKeys.ToString());
            this.publicKeys = publicKeys;
        }

        public void setMessage(List <string> message)
        {
            Console.WriteLine("Channel contains new message: ");
            foreach(string str in message) {
                Console.Write(str + " ");
            } Console.WriteLine();
            this.message = message;
        }

        public Tuple <long, long> getPublicKeys()
        {
            return publicKeys;
        }

        public List <string> getMessage()
        { 
            return message;
        }

        ~CommunicationChannel()
        {
            Console.WriteLine("Communication channel was closed at " + DateTime.Now);
        }
    }
}
