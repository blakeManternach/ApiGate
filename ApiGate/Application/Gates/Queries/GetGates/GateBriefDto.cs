using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGate.Application.Gates.Queries.GetGates
{
    public class GateBriefDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Category { get; set; }
    }
}
