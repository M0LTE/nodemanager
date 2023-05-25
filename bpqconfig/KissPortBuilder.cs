using System;

namespace bpqconfig
{
    public class KissPortBuilder
    {
        private readonly BpqPort _port = new BpqPort();

        public KissPortBuilder()
        {
            _port.Type = "ASYNC";
            _port.Protocol = "KISS";
        }

        public BpqPort Build()
        {
            return _port;
        }

        public KissPortBuilder DisableDigipeating()
        {
            _port.DigiFlag = 0;
            return this;
        }

        public KissPortBuilder SetAckModeOn()
        {
            _port.KissOptions = "ACKMODE";
            return this;
        }

        public KissPortBuilder SetComPort(string comPort, int speed)
        {
            _port.ComPort = comPort;
            _port.Speed = speed;
            return this;
        }

        public KissPortBuilder SetId(string id)
        {
            _port.Id = id;
            return this;
        }

        public KissPortBuilder SetMinQual(int v)
        {
            _port.MinQual = v;
            return this;
        }

        public KissPortBuilder SetNumber(int v)
        {
            _port.Number = v;
            return this;
        }

        public KissPortBuilder SetQuality(int v)
        {
            _port.Quality = v;
            return this;
        }

        public KissPortBuilder SetSensibleVhfLinkParameters()
        {
            _port.Frack = 4000;
            _port.PacLen = 150;
            return this;
        }
    }
}
