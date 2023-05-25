namespace bpqconfig
{
    public class BpqTelnetPortUser
    {
        public string? User { get; set; }
        public string? Password { get; set; }
        public string? Callsign { get; set; }
        public string? Application { get; set; }
        public bool? Sysop { get; set; }
        public bool Anon { get; set; }

        public override string ToString()
        {
            // https://www.cantab.net/users/john.wiseman/Documents/TelnetServer.htm

            if (Anon)
            {
                return $"USER=ANON,{Password}";
            }
            
            return $"USER={User},{Password},{Callsign},{Application}{Utils.CommaIfNotNull(Sysop)}{(Sysop == true ? "SYSOP" : "")}";
        }
    }
}