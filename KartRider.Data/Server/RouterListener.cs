using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace KartRider
{
	public class RouterListener
	{
		public static string sIP;

		public static int port;

		public static string forceConnect;

		public static System.Net.IPEndPoint CurrentUDPServer { get; set; }

		public static string ForceConnect { get; set; }

		public static TcpListener Listener { get; private set; }

		public static SessionGroup MySession { get; set; }

		public static IPAddress client = null;

		static RouterListener()
		{
			string str = "0.0.0.0";
			RouterListener.sIP = str;
			int str1 = 39312;
			RouterListener.port = str1;
		}

		public static void OnAcceptSocket(IAsyncResult ar)
		{
			try
			{
				Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				Socket clientSocket = RouterListener.Listener.EndAcceptSocket(ar);
				RouterListener.ForceConnect = RouterListener.sIP;
				RouterListener.MySession = new SessionGroup(clientSocket, null);
				System.Threading.Thread.Sleep(3000);
				IPEndPoint clientEndPoint = clientSocket.RemoteEndPoint as IPEndPoint;
				if (clientEndPoint != null)
				{
					RouterListener.client = clientEndPoint.Address;
					Console.WriteLine("Client IP: " + RouterListener.client.ToString());
					GameSupport.PcFirstMessage();
				}
				else
				{
					RouterListener.Listener.BeginAcceptSocket(new AsyncCallback(RouterListener.OnAcceptSocket), null);
				}
			}
			catch
			{
			}
			RouterListener.Listener.BeginAcceptSocket(new AsyncCallback(RouterListener.OnAcceptSocket), null);
		}

		public static void Start()
		{
			Console.WriteLine("Load server IP : {0}:{1}", (object)RouterListener.sIP, (object)RouterListener.port);
			//Console.WriteLine(Adler32Helper.GenerateAdler32_UNICODE("china_R12", 0));
			//Console.WriteLine(Adler32Helper.GenerateAdler32_ASCII("PrEnterShopPacket", 0));
			RouterListener.Listener = new TcpListener(IPAddress.Parse(RouterListener.sIP), RouterListener.port);
			RouterListener.Listener.Start();
			RouterListener.Listener.BeginAcceptSocket(new AsyncCallback(RouterListener.OnAcceptSocket), (object)null);
			RouterListener.CurrentUDPServer = new System.Net.IPEndPoint(IPAddress.Parse(RouterListener.sIP), 39311);
		}
	}
}
