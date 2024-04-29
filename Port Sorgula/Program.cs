using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Port_Sorgula
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Lütfen hedef IP adresini veya alan adını girin: ");
            string hedef = Console.ReadLine();

            Console.Write("Lütfen sorgulanacak port numarasını girin: ");
            int port;

            // Kullanıcı geçerli bir port numarası girene kadar döngüyü tekrar et
            while (!int.TryParse(Console.ReadLine(), out port) || port < 0 || port > 65535)
            {
                Console.WriteLine("Geçersiz port numarası. Lütfen 0 ile 65535 arasında bir port numarası girin.");
                Console.Write("Lütfen sorgulanacak port numarasını girin: ");
            }

            try
            {
                // TCP bağlantısı oluştur
                TcpClient client = new TcpClient();
                client.Connect(hedef, port);

                Console.WriteLine($"Port {port} {hedef} adresine açık.");
                client.Close();
            }
            catch (Exception)
            {
                Console.WriteLine($"Port {port} {hedef} adresine kapalı.");
            }
        }
    }
}
