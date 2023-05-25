namespace bpqconfig
{
    public class BpqApplication
    {
        public BpqApplication(int number, string command, string? newCommand, string applicationCall, string applicationAlias, int quality, string? l2Alias = null)
        {
            Number = number;
            Command = command;
            NewCommand = newCommand;
            Call = applicationCall;
            Alias = applicationAlias;
            Quality = quality;
            L2Alias = l2Alias;
        }

        public int? Number { get; set; }
        public string? Command { get; set; }
        public string? NewCommand { get; set; }
        public string? Call { get; set; }
        public string? Alias { get; set; }
        public int? Quality { get; set; }
        public string? L2Alias { get; set; }

        public override string ToString() => $"APPLICATION {Number},{Command},{NewCommand},{Call},{Alias},{Quality}{Utils.CommaIfNotNull(L2Alias)}{L2Alias}";
    }
}