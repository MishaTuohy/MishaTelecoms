using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Domain.Settings
{
    public class CDRGeneratorConfig
    {
        public List<string> Countries { get; }
        public List<string> CallType { get; }
        public string Filepath { get; }
    }
}
