using Grpc.Core;
using Microsoft.Extensions.Logging;
using Moq;
using MyFirstGrpcService;
using MyFirstGrpcService.Services;

namespace Tests
{ 
    public class GreeterServiceTest
    {
        private readonly Mock<ILogger<GreeterService>> _loggerMock;
        private readonly GreeterService _service;


        public class GreeterServiceTests
        {
            private readonly Mock<ILogger<GreeterService>> _loggerMock;
            private readonly GreeterService _service;

            public GreeterServiceTests()
            {
                // Constructor with mock entities
                _loggerMock = new Mock<ILogger<GreeterService>>();
                _service = new GreeterService(_loggerMock.Object);
            }

            [Fact]
            public async Task SayHello_ReturnsExpectedMessage()
            {
                // given
                var request = new HelloRequest { Name = "John" };
                var context = new Mock<ServerCallContext>().Object;

                // when
                var response = await _service.SayHello(request, context);

                // then
                Assert.NotNull(response);
                Assert.Equal("Hello John", response.Message);
            }

            [Fact]
            public async Task SayHello_WithEmptyName_ReturnsHelloMessage()
            {
                // given
                var request = new HelloRequest { Name = "" };
                var context = new Mock<ServerCallContext>().Object;

                // when
                var response = await _service.SayHello(request, context);

                // then
                Assert.NotNull(response);
                Assert.Equal("Hello ", response.Message);
            }
        }
    }
}