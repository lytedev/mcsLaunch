using System;

namespace mcsLaunch
{
    [Serializable]
    public class Server
    {
        public string IP { get; set; }
        public string Nickname { get; set; }

        public Server()
        {

        }

        public Server(string ip, string nickname)
        {
            IP = ip;
            Nickname = nickname;
        }
    }
}
