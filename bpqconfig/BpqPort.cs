using System.Text;

namespace bpqconfig
{
    public class BpqPort
    {
        public int? Number { get; set; }
        public string? Id { get; set; }
        public string? Driver { get; set; }
        public string? Type { get; set; }
        public string? Protocol { get; set; }
        public string? KissOptions { get; set; }
        public string? ComPort { get; set; }
        public int? Speed { get; set; }
        public int? TxDelay { get; set; }
        public int? Frack { get; set; }
        public int? PacLen { get; set; }
        public int? DigiFlag { get; set; }
        public int? DigiPort { get; set; }
        public int? Quality { get; set; }
        public int? MinQual { get; set; }
        public int? MaxFrame { get; set; }
        public int? RespTime { get; set; }
        public int? Retries { get; set; }
        public string? Unproto { get; set; }
        public BpqPortConfig? Config { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("PORT");
            sb.AppendLineIfNotNull(Number, "  PORTNUM={0}");
            sb.AppendLineIfNotNull(Id, "  ID={0}");
            sb.AppendLineIfNotNull(Driver, "  DRIVER={0}");
            sb.AppendLineIfNotNull(Type, "  TYPE={0}");
            sb.AppendLineIfNotNull(Protocol, "  PROTOCOL={0}");
            sb.AppendLineIfNotNull(KissOptions, "  KISSOPTIONS={0}");
            sb.AppendLineIfNotNull(ComPort, "  COMPORT={0}");
            sb.AppendLineIfNotNull(Speed, "  SPEED={0}");
            sb.AppendLineIfNotNull(TxDelay, "  TXDELAY={0}");
            sb.AppendLineIfNotNull(Frack, "  FRACK={0}");
            sb.AppendLineIfNotNull(PacLen, "  PACLEN={0}");
            sb.AppendLineIfNotNull(DigiFlag, "  DIGIFLAG={0}");
            sb.AppendLineIfNotNull(DigiPort, "  DIGIPORT={0}");
            sb.AppendLineIfNotNull(Quality, "  QUALITY={0}");
            sb.AppendLineIfNotNull(MinQual, "  MINQUAL={0}");
            sb.AppendLineIfNotNull(MaxFrame, "  MAXFRAME={0}");
            sb.AppendLineIfNotNull(RespTime, "  RESPTIME={0}");
            sb.AppendLineIfNotNull(Retries, "  RETRIES={0}");
            sb.AppendLineIfNotNull(Unproto, "  UNPROTO={0}");
            sb.AppendLineIfNotNull(Config, "  CONFIG");
            sb.AppendLineIfNotNull(Config, Config?.ToString());
            sb.AppendLine("ENDPORT");
            return sb.ToString();
        }
    }
}