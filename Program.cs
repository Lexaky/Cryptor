using Cryptor;

char[] russianSymbols = {'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з',
                        'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р',
                        'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ',
                        'ъ', 'ы', 'ь', 'э', 'ю', 'я', ' ' };

char[] englishSymbols = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 
                          'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 
                          's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ' ' };

const string message = "фулл сообщения для тебя алекс дорогой";
const string englishMessage = "be good be adidas";
const string vigenerKeyRussian = "хало ухалоу";
const string vigenerKeyEnglish = "halo uhello";
Alphabet russian = new Alphabet(russianSymbols);
Alphabet english = new Alphabet(englishSymbols);

Cesar cypherObjectCesar = new Cesar(russian, message, 6);
Console.WriteLine("Crypt view: " + cypherObjectCesar.getCryptString());
Console.WriteLine("Decrypt crypt view: " + cypherObjectCesar.getDecryptString(cypherObjectCesar.getCryptString()));

Vigener cypherObjectVigener = new Vigener(russian, vigenerKeyRussian);
Console.WriteLine("Crypted message: " + cypherObjectVigener.getCryptString(message));
Console.WriteLine("Decrypted message: " + cypherObjectVigener.getDecryptString(cypherObjectVigener.getCryptString(message)));

CommunicationChannel channel = new CommunicationChannel();
Host Alex = new Host(russian, channel);
Host Jeam = new Host(russian, channel);
Alex.sendPublicKeys();
Jeam.setPublicKeys();
Jeam.sendMessage(message);
Alex.getMessage();