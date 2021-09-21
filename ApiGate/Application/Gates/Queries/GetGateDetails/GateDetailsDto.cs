using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGate.Application.Gates.Queries.GetGateDetails
{
    public class GateDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int? Year { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string Category { get; set; }

    }
}
