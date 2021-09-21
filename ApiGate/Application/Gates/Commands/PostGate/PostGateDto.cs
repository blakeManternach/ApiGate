using ApiGate.Application.Common.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGate.Application.Gates.Commands.PostGate
{
    public class PostGateDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Url(ErrorMessage = "Unproporly formatted URL.")]
        public string Url { get; set; }
        [Range(1600, 2021, ErrorMessage = "Year must be between 1600-2021.")]
        public int? Year { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        [CategoryIsEnum]
        [Required]
        public string Category { get; set; }
    }
}
