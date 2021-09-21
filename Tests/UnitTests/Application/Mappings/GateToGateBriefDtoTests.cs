using ApiGate.Application.Common.Mappings;
using ApiGate.Application.Gates.Queries.GetGates;
using ApiGate.Domain.Entities;
using ApiGate.Domain.Enums;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.UnitTests.Application.Mappings
{
    public class GateToGateBriefDtoTests 
    {
        IMapper mapper;

        public GateToGateBriefDtoTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new GateToGateBriefDto());
            });
            mapper = config.CreateMapper();
        }

        [Fact]
        public void Test_CheckType()
        {
            var gate1 = new Gate()
            {
                Id = 1,
                Name = "TestGate",
                Url = "https://test.com",
                Year = 2020,
                // 149 Characters
                Description = @"Lorem ipsum dolor sit amet, consectetuer adipiscing elit.
                                Aenean commodo ligula eget dolor. Aenean massa. Cum sociis
                                natoque penatibus et magnis dis.",
                Country = "United States",
                Category = GateCategory.ARTS_AND_ENTERTAINMENT
            };


            var gbd = mapper.Map<GateBriefDto>(gate1);
            Assert.IsType<GateBriefDto>(gbd);
        }

        [Fact]
        public void Test_ShortDescriptionIs150LengthMax()
        {
            var gate2 = new Gate()
            {
                Id = 2,
                Name = "TestGate2",
                Url = "aosidnf.com",
                Year = 1999,
                // 200 Characters
                Description = @"Lorem ipsum dolor sit amet, consectetuer adipiscing elit.
                                Aenean commodo ligula eget dolor. Aenean massa. Cum sociis
                                natoque penatibus et magnis dis parturient montes, nascetur
                                ridiculus mus. Donec qu",
                Country = "United States",
                Category = GateCategory.OTHER
            };

            var gbd = mapper.Map<GateBriefDto>(gate2);
            Assert.Equal(150, gbd.ShortDescription.Length);
        }
    }
}
