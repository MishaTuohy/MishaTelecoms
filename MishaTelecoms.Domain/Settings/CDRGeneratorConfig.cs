using System.Collections.Generic;

namespace MishaTelecoms.Domain.Settings
{
    public class CDRGeneratorConfig
    {
        public List<string> Countries { get; }
        public List<string> CallType { get; }
        public string Filepath { get; }
    }
}