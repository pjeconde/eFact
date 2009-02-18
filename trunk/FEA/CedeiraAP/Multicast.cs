using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Cedeira.SV
{
	public class Multicast
	{
		int port;
		byte etapa;
		bool etapaRecibida=false;
		byte etapaEnCalculo=255;
		byte ultimaEtapaEnCalculo=255;
		bool terminar=false;
		bool terminarTx=false;
		UdpClient server;
		IPEndPoint sender;
		int recursividad=0;
		IPAddress[] iplocales=Dns.GetHostEntry(Dns.GetHostName()).AddressList;

		public Multicast()
		{
		}

		public Multicast(int Port)
		{
			port=Port;
		}

		public Multicast(int Port, byte Etapa)
		{
			port=Port;
			etapa=Etapa;
		}

		public void send() 
		{
			server = new UdpClient();
			sender = new IPEndPoint(IPAddress.Broadcast, port); 
			while(!terminarTx)
			{
				Console.WriteLine("Envío en puerto: {0} Etapa: {1}", port, Convert.ToString(etapa));
				byte[] b=System.Text.Encoding.ASCII.GetBytes(Convert.ToString(etapa));
				server.Send(b, b.Length, sender);
				Thread.Sleep(100);
			}
			terminarTx=false;
			server.Close();
			server=null;
			sender=null;
		}

		public void recv() 
		{
			sender = new IPEndPoint(IPAddress.Any, port);
			server = new UdpClient(sender);
			while(!terminar)
			{
				Console.WriteLine("Esperando...");
				recibirDiscriminado();
				recursividad=0;
			}
			terminar=false;
			server.Close();
			server=null;
			sender=null;
		}

		private void recibirDiscriminado()
		{
			byte[] buffer = new byte[1024];
			buffer = server.Receive(ref sender); 

			string str = System.Text.Encoding.ASCII.GetString(buffer, 0, buffer.Length);
			Console.WriteLine("RX: " + str.Trim());

			for(int i=0;i<iplocales.Length;i++)
			{
				if(!iplocales[i].Equals(sender.Address) || str.Equals("255"))
				{
					Console.WriteLine("Mensaje recibido de {0}:", sender.ToString());
					etapaEnCalculo=Convert.ToByte(str);
					break;
				}
				else
				{
					Console.WriteLine("Mensaje descartado de {0}:", sender.ToString());
					recursividad++;
					System.Console.WriteLine("Recursividad:"+recursividad);
					if(recursividad<100)
					{
						recibirDiscriminado();
					}
					else
					{
						
						etapaEnCalculo=255;
					}
				}
			}
		}

		public bool EtapaEnRevaluo(byte EtapaEnCalculoLocal)
		{
			for(int i=0;i<400;i++)
			{
				if (etapaEnCalculo.Equals(EtapaEnCalculoLocal) || etapaEnCalculo.Equals(0) || EtapaEnCalculoLocal.Equals(0))
				{
					etapaRecibida=true;
					break;
				}
				else
				{
					etapaRecibida=false;
				}
				Thread.Sleep(10);
			}
			return etapaRecibida;
		}

        public byte queEtapaEnRevaluo()
        {
            TimeSpan ts = TimeSpan.FromSeconds(2);
            DateTime inicio = DateTime.Now;
            byte auxEtapa=255;
            while (((TimeSpan)(DateTime.Now - inicio)).CompareTo(ts) < 0)
            {
                auxEtapa = etapaEnCalculo;
                if (auxEtapa != 255)
                {
                    return auxEtapa;
                }
            }
            return auxEtapa;
        }

        public System.Collections.ArrayList queEtapasEnRevaluo()
        {
            TimeSpan ts = TimeSpan.FromSeconds(2);
            DateTime inicio = DateTime.Now;
            byte auxEtapa = 255;

            System.Collections.ArrayList etapas = new System.Collections.ArrayList();

            while (((TimeSpan)(DateTime.Now - inicio)).CompareTo(ts) < 0)
            {
                auxEtapa = etapaEnCalculo;
                if (auxEtapa != 255)
                {
                    if (!etapas.Contains(auxEtapa))
                    {
                        etapas.Add(auxEtapa);
                    }
                }
            }
            return etapas;
        }

		public byte EtapaEnCalculo
		{
			get
			{
				if(ultimaEtapaEnCalculo.Equals(etapaEnCalculo))
				{
					ultimaEtapaEnCalculo=255;
					etapaEnCalculo=255;
				}
				else
				{
					ultimaEtapaEnCalculo=etapaEnCalculo;
				}
				return ultimaEtapaEnCalculo;
			}
		}
		public bool Terminar
		{
			set
			{
				terminar=value;
			}
		}
		public bool TerminarTx
		{
			set
			{
				terminarTx=value;
			}
		}
		public byte Etapa
		{
			set
			{
				etapa=value;
			}
			get
			{
				return etapa;
			}
		}
		public IPAddress IPrecibida
		{
			get
			{
				return sender.Address;
			}
		}
		public bool MismoTX
		{
			get
			{
				int ip=iplocales.Length;
				for(int i=0;i<ip;i++)
				{
					if(iplocales[i].Equals(sender.Address) || sender.Address.Address.Equals(new IPEndPoint(IPAddress.Parse("0.0.0.0"), port).Address.Address))
					{
						return true;
					}
				}
				return false;
			}
		}
	}
}
