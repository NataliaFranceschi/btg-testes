using btg_testes_auto.Notification;
using btg_testes_auto.NotificationMessage;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test.NotificationEmailTest
{
    public class NotificationServiceTest
    {
        private readonly IEmailService _mockEmailService;
        private readonly NotificationService _sut;

        public NotificationServiceTest()
        {
            _mockEmailService = Substitute.For<IEmailService>();
            _sut = new NotificationService(_mockEmailService);
        }

        [Fact]
        public void SendNotification_EmptyMessage_ReturnFalse()
        {
            bool result = _sut.SendNotification("recipient", "");

            result.Equals(false);
            _mockEmailService.Received(0).SendEmail("recipient", "Notification", "");
        }

        [Fact]
        public void SendNotification_MessageNull_ReturnFalse()
        {
            bool result = _sut.SendNotification("recipient", null);

            result.Equals(false);
            _mockEmailService.Received(0).SendEmail("recipient", "Notification", null);
        }

        [Fact]
        public void SendNotification_ValidParamters_ReturnTrue()
        {
            _mockEmailService.SendEmail("recipient", "Notification", "message")
                .Returns(true);

            bool result = _sut.SendNotification("recipient", "message");

            result.Equals(true);
            _mockEmailService.Received(1).SendEmail("recipient", "Notification", "message");
        }

        [Fact]
        public void SendNotification_ThrowError_ReturnFalse()
        {
            _mockEmailService.SendEmail(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>())
                .Throws(new Exception());

            bool result = _sut.SendNotification("recipient", "message");

            result.Equals(false);
            _mockEmailService.Received(1).SendEmail("recipient", "Notification", "message");

        }


    }
}
