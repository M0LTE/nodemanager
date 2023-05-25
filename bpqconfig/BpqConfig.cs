using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bpqconfig
{
    public class BpqConfig
    {
        public bool? Simple { get; set; }
        public string? NodeCall { get; set; }
        public string? NodeAlias { get; set; }
        public string? Locator { get; set; }
        public string? MapComment { get; set; }
        public string? Password { get; set; }
        public bool? AutoSave { get; set; }
        public int? NodesInterval { get; set; }
        public int? MinQual { get; set; }
        public int? IdInterval { get; set; }
        public string? IdMsg { get; set; }
        public string? InfoMsg { get; set; }
        public string? CText { get; set; }
        public int? BtInterval { get; set; }
        public string? BText { get; set; }
        public List<BpqPort> Ports { get; set; } = new List<BpqPort>();
        public bool LinMail { get; set; }
        public bool LinChat { get; set; }
        public List<BpqApplication> Applications { get; set; } = new List<BpqApplication>();

        public string Generate()
        {
            var sb = new StringBuilder();

            sb.AppendLineIfTrue(Simple, "SIMPLE");
            sb.AppendLineIfNotNull(NodeCall, "NODECALL={0}");
            sb.AppendLineIfNotNull(NodeAlias, "NODEALIAS={0}");
            sb.AppendLineIfNotNull(Locator, "LOCATOR={0}");
            sb.AppendLineIfNotNull(Password, "PASSWORD={0}");
            sb.AppendLineIfTrue(AutoSave, $"AUTOSAVE={(AutoSave == true ? 1 : 0)}");
            sb.AppendLineIfNotNull(NodesInterval, "NODESINTERVAL={0}");
            sb.AppendLineIfNotNull(MinQual, "MINQUAL={0}");
            sb.AppendLineIfNotNull(IdInterval, "IDINTERVAL={0}");
            sb.AppendLineIfNotNull(IdMsg, Utils.Newlines("IDMSG:\n{0}\n***"));
            sb.AppendLineIfNotNull(CText, Utils.Newlines("CTEXT:\n{0}\n***"));
            sb.AppendLineIfTrue(LinMail, "LINMAIL");
            sb.AppendLineIfTrue(LinChat, "LINCHAT");

            if (Ports.Any())
            {
                sb.AppendLine();
            }

            foreach (var port in Ports)
            {
                sb.AppendLine(port.ToString());
            }

            foreach (var application in Applications)
            {
                sb.AppendLine(application.ToString());
            }

            return sb.ToString();
        }
    }
}