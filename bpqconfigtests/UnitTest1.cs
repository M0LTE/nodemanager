using bpqconfig;
using FluentAssertions;

namespace bpqconfigtests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var kissPortBuilder = new KissPortBuilder();
            kissPortBuilder
                .SetId("VHF")
                .SetComPort("/dev/ttyACM0", 57600)
                .SetAckModeOn()
                .SetSensibleVhfLinkParameters()
                .SetQuality(191)
                .SetMinQual(20)
                .DisableDigipeating();

            var telnetPortBuilder = new TelnetPortBuilder();
            telnetPortBuilder
                .WithReasonableDefaults()
                .WithPortNumber(9)
                .WithId("Telnet")
                .AddUser("tf", "xxxxxxxx", "m0lte", null, true);

            var builder = new BpqConfigBuilder();
            var config = builder
                .WithOpinionatedDefaults()
                .WithNodeCall("MB7NGP")
                .WithNodeAlias("GILWEL")
                .WithLocator("JO01ap")
                .WithPassword("abc123")
                .WithDefaultText()
                .AddPort(kissPortBuilder.Build())
                .AddPort(telnetPortBuilder.Build())
                .WithChatEnabled("MB7NGP-9", "GPCHAT")
                .Build();

            string fileContent = config.Generate().Replace("\r\n", "\n");

            var expected = @"SIMPLE
NODECALL=MB7NGP
NODEALIAS=GILWEL
LOCATOR=JO01ap
PASSWORD=abc123
AUTOSAVE=1
NODESINTERVAL=10
MINQUAL=10
IDINTERVAL=15
IDMSG:
BPQ node GILWEL:MB7NGP
***
CTEXT:
Welcome to this node.
Type ? for help.
***
LINCHAT

PORT
  PORTNUM=1
  ID=VHF
  TYPE=ASYNC
  PROTOCOL=KISS
  KISSOPTIONS=ACKMODE
  COMPORT=/dev/ttyACM0
  SPEED=57600
  FRACK=4000
  PACLEN=150
  DIGIFLAG=0
  QUALITY=191
  MINQUAL=20
ENDPORT

PORT
  PORTNUM=9
  ID=Telnet
  DRIVER=Telnet
  CONFIG
    LOGGING=1
    CMS=1
    DisconnectOnClose=1
    TCPPORT=8010
    FBBPORT=8011
    HTTPPORT=8008
    LOGINPROMPT=user:
    PASSWORDPROMPT=password:
    MAXSESSIONS=10
    CTEXT=Welcome to the node\n Enter ? for list of commands\n\n
    USER=tf,xxxxxxxx,m0lte,,SYSOP
ENDPORT

APPLICATION 1,CHAT,,MB7NGP-9,GPCHAT,255
";

            fileContent.Should().Be(expected.Replace("\r\n", "\n"));
        }
    }
}