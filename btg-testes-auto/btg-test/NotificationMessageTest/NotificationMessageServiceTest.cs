﻿using btg_testes_auto.Discount;
using btg_testes_auto.NotificationMessage;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test.NotificationMessageTest
{
    public class NotificationMessageServiceTest
    {
        private readonly IMessageService _mockMessageService;
        private readonly NotificationMessageService _sut;

        public NotificationMessageServiceTest()
        {
            _mockMessageService = Substitute.For<IMessageService>();
            _sut = new NotificationMessageService(_mockMessageService);
        }

        [Fact]
        public void NotifyUsers_AllMessageSend_ReturnTrue()
        {
            Notification notification = new Notification() { Message = "test", UserId = "1"};
            List<Notification> notifications = new() { notification, notification };

            _mockMessageService.SendMessage("1", "test")
                .Returns(true);

            bool result = _sut.NotifyUsers(notifications);

            result.Should().BeTrue();
            _mockMessageService.Received(2).SendMessage("1", "test");
        }

        [Fact]
        public void NotifyUsers_MessageNotSent_ReturnFalse()
        {
            Notification notification1 = new Notification() { Message = "test", UserId = "1" };
            Notification notification2 = new Notification() { Message = "test", UserId = "2" };
            List<Notification> notifications = new() { notification1, notification2, notification1 };

            _mockMessageService.SendMessage("1", "test")
                .Returns(true);
            _mockMessageService.SendMessage("2", "test")
                .Returns(false);

            bool result = _sut.NotifyUsers(notifications);

            result.Should().BeFalse();
            _mockMessageService.Received(1).SendMessage("1", "test");
            _mockMessageService.Received(1).SendMessage("2", "test");
        }
    }
}
