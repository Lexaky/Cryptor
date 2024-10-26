using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptor
{
    internal class Host
    {
        private List <string> message;
        private Tuple<long, long> anotherHostPublicKeys;
        private RSA ownKeys;
        CommunicationChannel channel;
        public Host(Alphabet alph, CommunicationChannel channel, int p = 0, int q = 0)
        {
            Console.WriteLine("Host created at " + DateTime.Now);
            ownKeys = new RSA(alph, p, q);
            this.channel = channel;
        }

        public void sendPublicKeys()
        {
            channel.setPublicKeys(ownKeys.getPublicKeys());
        }
        public void setPublicKeys()
        {
            this.anotherHostPublicKeys = channel.getPublicKeys();
        }
        public void sendMessage(string message)
        {
            channel.setMessage(ownKeys.RSA_Endoce(message, anotherHostPublicKeys.Item1, anotherHostPublicKeys.Item2));
        }
        public void getMessage()
        {
            string messageOneString = ownKeys.RSA_Dedoce(channel.getMessage(), ownKeys.getPrivateKeys().Item1, ownKeys.getPrivateKeys().Item2);
            Console.WriteLine("Message was: " + messageOneString);
        }

        public Tuple<long, long> myPublicKeys()
        {
            return ownKeys.getPublicKeys();
        }
    }
}
