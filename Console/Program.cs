using System;
using System.Linq;
using System.Net.Sockets;

namespace Console_nt117
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing: start.");
            Console.Write("Enter IP address PLC: ");
            
            string ip = Console.ReadLine();

            if(ip == null || ip == "" || ip.IncorrentFormatIP())
            {
                Console.WriteLine("Incorrent format IP address!");
            }
            else
            {
                TcpClient tcpClient = new TcpClient();
                int port = 10005;

                try
                {
                    tcpClient.Connect(ip, port);
                    NetworkStream stream = tcpClient.GetStream();

                    byte[] send = "4bc001e0000000000000000047657450726748656164000010270000".ToBytes();
                    stream.Write(send, 0, send.Length);

                    byte[] responseData = new byte[64];
                    stream.Read(responseData, 0, responseData.Length);

                    string response = string.Join("", responseData.Select(x => x.ToString("X2")));
                    Console.WriteLine("Size msg: " + response.Length);
                    Console.WriteLine("msg view: " + response);

                    byte[] dataCut = responseData.GetPassword();

                    byte[] decrypt = LogoMath.symDecrypt(dataCut, LogoMath.keyForBinFile);
                    string pswd = LogoMath.getSdAndPsw(decrypt);

                    Console.WriteLine("Password size: " + pswd.Length);
                    Console.WriteLine("Password: " + pswd);

                    tcpClient.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("Testing: stop.");
            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }
    }
}