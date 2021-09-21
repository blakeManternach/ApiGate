using ApiGate.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGate.Domain.Entities
{
    public class Gate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int? Year { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public GateCategory Category { get; set; }
    }
}
