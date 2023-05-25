using System;
using System.ComponentModel;

namespace bpqconfig
{
    public class TelnetPortBuilder
    {
        private readonly BpqPort _port = new BpqPort();

        public TelnetPortBuilder()
        {
            _port.Driver = "Telnet";
        }

        public BpqPort Build()
        {
            return _port;
        }

        public TelnetPortBuilder WithId(string id)
        {
            _port.Id = id;
            return this;
        }

        public TelnetPortBuilder WithPortNumber(int v)
        {
            _port.Number = v;
            return this;
        }

        public TelnetPortBuilder AddUser(string username, string password, string callsign, string? application, bool sysop)
        {
            _port.Config ??= new BpqTelnetPortConfig();

            var config = _port.Config as BpqTelnetPortConfig;

            config?.Users?.Add(new BpqTelnetPortUser
            {
                User = username,
                Password = password,
                Callsign = callsign,
                Application = application,
                Sysop = sysop
            });

            return this;
        }

        public TelnetPortBuilder WithReasonableDefaults()
        {
            _port.Config = new BpqTelnetPortConfig
            {
                Logging = true,
                Cms = true,
                DisconnectOnClose = true,
                TcpPort = 8010,
                FbbPort = 8011,
                HttpPort = 8008,
                LoginPrompt = "user:",
                PasswordPrompt = "password:",
                MaxSessions = 10,
                CText = "Welcome to the node\n Enter ? for list of commands\n\n",
            };

            return this;
        }
    }
}