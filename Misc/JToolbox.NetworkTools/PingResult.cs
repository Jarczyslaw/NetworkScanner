﻿using System.Net;
using System.Net.NetworkInformation;

namespace JToolbox.NetworkTools
{
    public class PingResult
    {
        public IPAddress Address { get; internal set; }
        public PingReply Reply { get; internal set; }
    }
}