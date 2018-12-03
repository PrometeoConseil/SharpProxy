using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SharpProxy
{
    public class ProxyThread
    {
        public int ExternalPort { get; set; }
        public int InternalPort { get; set; }
        public bool RewriteHostHeaders { get; set; }
        public bool Stopped { get; set; }

        private TcpListener _listener;
        private readonly long _proxyTimeoutTicks = new TimeSpan(0, 1, 0).Ticks;        
        private const string HTTP_SEPARATOR = "\r\n";
        private const string HTTP_HEADER_BREAK = HTTP_SEPARATOR + HTTP_SEPARATOR;        
        private readonly string[] _httpSeparators = { HTTP_SEPARATOR };
        private readonly string[] _httpHeaderBreaks = { HTTP_HEADER_BREAK };

        public ProxyThread(int extPort, int intPort, bool rewriteHostHeaders)
        {
            ExternalPort = extPort;
            InternalPort = intPort;
            RewriteHostHeaders = rewriteHostHeaders;
            Stopped = false;
            _listener = null;

            new Thread(Listen).Start();
        }

        public void Stop()
        {
            Stopped = true;
            _listener?.Stop();
        }

        protected void Listen()
        {
            _listener = new TcpListener(new IPEndPoint(IPAddress.Any, ExternalPort));
            _listener.Start();

            while (!Stopped)
            {
                try
                {
                    TcpClient client = _listener.AcceptTcpClient();
                    //Dispatch the thread and continue listening...
                    new Thread(() => Proxy(client)).Start();
                }
                catch (Exception)
                {
                    //TODO: Remove this. Only here to catch breakpoints.
                    //bool failed = true;
                }
            }
        }

        protected void Proxy(object arg)
        {
            var buffer = new byte[16384];
            int clientRead = -1;
            int hostRead = -1;

            long lastTime = DateTime.Now.Ticks;

            try
            {
                //Setup connections
                using (var client = (TcpClient)arg)
                using (var host = new TcpClient())
                {
                    host.Connect(new IPEndPoint(IPAddress.Loopback, InternalPort));

                    //Setup our streams
                    using (var clientIn = new BinaryReader(client.GetStream()))
                    using (var clientOut = new BinaryWriter(client.GetStream()))
                    using (var hostIn = new BinaryReader(host.GetStream()))
                    using (var hostOut = new BinaryWriter(host.GetStream()))
                    {
                        //Start funneling data!
                        while (clientRead != 0 || hostRead != 0 || (DateTime.Now.Ticks - lastTime) <= _proxyTimeoutTicks)
                        {
                            while (client.Connected && (clientRead = client.Available) > 0)
                            {
                                clientRead = clientIn.Read(buffer, 0, buffer.Length);

                                //Rewrite the host header?
                                if (RewriteHostHeaders && clientRead > 0)
                                {
                                    string str = Encoding.UTF8.GetString(buffer, 0, clientRead);

                                    int startIdx = str.IndexOf(HTTP_SEPARATOR + "Host:", StringComparison.Ordinal);
                                    if (startIdx >= 0)
                                    {
                                        int endIdx = str.IndexOf(HTTP_SEPARATOR, startIdx + 1, str.Length - (startIdx + 1), StringComparison.Ordinal);
                                        if (endIdx > 0)
                                        {
                                            string replace = str.Substring(startIdx, endIdx - startIdx);
                                            string replaceWith = HTTP_SEPARATOR + "Host: localhost:" + InternalPort;

                                            Trace.WriteLine("Incoming HTTP header:\n\n" + str);

                                            str = str.Replace(replace, replaceWith);

                                            Trace.WriteLine("Rewritten HTTP header:\n\n" + str);
                                            
                                            byte[] strBytes = Encoding.UTF8.GetBytes(str);
                                            Array.Clear(buffer, 0, buffer.Length);
                                            Array.Copy(strBytes, buffer, strBytes.Length);
                                            clientRead = strBytes.Length;
                                        }
                                    }
                                }

                                hostOut.Write(buffer, 0, clientRead);
                                lastTime = DateTime.Now.Ticks;
                                hostOut.Flush();
                            }
                            while (host.Connected && (hostRead = host.Available) > 0)
                            {
                                hostRead = hostIn.Read(buffer, 0, buffer.Length);
                                clientOut.Write(buffer, 0, hostRead);
                                lastTime = DateTime.Now.Ticks;
                                clientOut.Flush();
                            }

                            //Sleepy time?
                            if (Stopped)
                                return;
                            if (clientRead == 0 && hostRead == 0)
                            {
                                Thread.Sleep(100);
                            }
                        }

                        //long waitTime = DateTime.Now.Ticks - lastTime;
                    }
                }
            }
            catch (Exception)
            {
                //TODO: Remove this. Only here to catch breakpoints.
                //bool failed = true;
            }
        }
    }
}