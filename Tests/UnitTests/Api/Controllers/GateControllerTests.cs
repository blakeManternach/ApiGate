using ApiGate.Api.Controllers;
using ApiGate.Application.Gates.Queries.GetGates;
using ApiGate.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests.UnitTests.Api.Controllers
{
    public class GateControllerTests
    {
        // This test doesn't really do anything...just practicing unit testing.
        [Fact]
        public async Task GateControllerReturns()
        {
            var mockMediatr = new Mock<IMediator>();
            mockMediatr.Setup(m => m.Send(It.IsAny<GetGatesQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<GateBriefDto> { });

            var controller = new GateController(mockMediatr.Object);

            var result = await controller.GetGates();

            Assert.IsAssignableFrom<ActionResult<List<GateBriefDto>>>(result);
        }
    }
}
