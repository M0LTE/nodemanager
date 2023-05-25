namespace bpqconfig
{
    public class BpqAxipPortMap
    {
        // https://www.cantab.net/users/john.wiseman/Documents/BPQAXIP.htm

        public string? Callsign { get; set; }
        public string? Ip { get; set; }
        public string? Proto { get; set; }
        public int? Port { get; set; }
        public bool? B { get; set; }

        public override string ToString() => $"MAP {Callsign} {Ip} {Proto} {Port}{(B == true ? " B" : "")}";
    }
}