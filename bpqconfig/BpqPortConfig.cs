using System.Collections.Generic;
using System.Text;

namespace bpqconfig
{
    public abstract class BpqPortConfig
    {
    }

    public class BpqAxipPortConfig : BpqPortConfig
    {
        public int? Udp { get; set; }
        public bool? MHeard { get; set; }
        public bool? BroadcastNodes { get; set; }
        public bool? BroadcastId { get; set; }
        public List<BpqAxipPortMap> Maps { get; set; } = new List<BpqAxipPortMap>();

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLineIfNotNull(Udp, "    UDP {0}");
            sb.AppendLineIfNotNull(MHeard, $"    MHEARD {(MHeard == true ? "ON" : "OFF")}");
            sb.AppendLineIfTrue(BroadcastNodes, "    BROADCAST NODES");
            sb.AppendLineIfTrue(BroadcastId, "    BROADCAST ID");

            foreach (var map in Maps)
            {
                sb.AppendLine(map.ToString());
            }

            return sb.ToString().Trim();
        }
    }

    public class BpqTelnetPortConfig : BpqPortConfig
    {
        public bool? Logging { get; set; }
        public bool? Cms { get; set; }
        public bool? DisconnectOnClose { get; set; }
        public int? TcpPort { get; set; }
        public int? FbbPort { get; set; }
        public int? HttpPort { get; set; }
        public string? LoginPrompt { get; set; }
        public string? PasswordPrompt { get; set; }
        public int? MaxSessions { get; set; }
        public string? CText { get; set; }
        public List<BpqTelnetPortUser> Users { get; set; } = new List<BpqTelnetPortUser>();
        public int? CmdPort { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLineIfNotNull(Logging, $"    LOGGING={(Logging == true ? 1 : 0)}");
            sb.AppendLineIfNotNull(Cms, $"    CMS={(Cms == true ? 1 : 0)}");
            sb.AppendLineIfNotNull(DisconnectOnClose, $"    DisconnectOnClose={(DisconnectOnClose == true ? 1 : 0)}");
            sb.AppendLineIfNotNull(TcpPort, "    TCPPORT={0}");
            sb.AppendLineIfNotNull(FbbPort, "    FBBPORT={0}");
            sb.AppendLineIfNotNull(HttpPort, "    HTTPPORT={0}");
            sb.AppendLineIfNotNull(LoginPrompt, "    LOGINPROMPT={0}");
            sb.AppendLineIfNotNull(PasswordPrompt, "    PASSWORDPROMPT={0}");
            sb.AppendLineIfNotNull(MaxSessions, "    MAXSESSIONS={0}");
            sb.AppendLineIfNotNull(CText, $"    CTEXT={CText?.Replace("\n", "\\n")}");

            foreach (var user in Users)
            {
                sb.AppendLineIfNotNull(user, "    " + user.ToString());
            }

            sb.AppendLineIfNotNull(CmdPort, "    CMDPORT={0}");

            return sb.ToString().TrimEnd();
        }
    }
}
