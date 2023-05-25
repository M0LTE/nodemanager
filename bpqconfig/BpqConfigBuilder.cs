namespace bpqconfig
{
    public class BpqConfigBuilder
    {
        private readonly BpqConfig _config = new BpqConfig();

        public BpqConfigBuilder AddPort(BpqPort port)
        {
            if (port.Number == null)
            {
                port.Number = _config.Ports.Count + 1;
            }
            _config.Ports.Add(port);
            return this;
        }

        public BpqConfig Build()
        {
            return _config;
        }

        public BpqConfigBuilder WithLocator(string v)
        {
            _config.Locator = v;
            return this;
        }

        public BpqConfigBuilder WithNodeAlias(string v)
        {
            _config.NodeAlias = v;
            return this;
        }

        public BpqConfigBuilder WithNodeCall(string v)
        {
            _config.NodeCall = v;
            return this;
        }

        public BpqConfigBuilder WithOpinionatedDefaults()
        {
            _config.Simple = true;
            _config.AutoSave = true;
            _config.NodesInterval = 10;
            _config.MinQual = 10;
            _config.IdInterval = 15;
            return this;
        }

        public BpqConfigBuilder WithPassword(string v)
        {
            _config.Password = v;
            return this;
        }

        public BpqConfigBuilder WithDefaultTexts()
        {
            _config.IdMsg = $"BPQ node {_config.NodeAlias}:{_config.NodeCall}";
            _config.CText = "Welcome to this node.\nType ? for help.";
            return this;
        }

        public BpqConfigBuilder WithChatEnabled(string applicationCall, string applicationAlias)
        {
            _config.LinChat = true;
            _config.Applications.Add(new BpqApplication(_config.Applications.Count + 1, "CHAT", null, applicationCall, applicationAlias, 255));
            return this;
        }
    }
}
