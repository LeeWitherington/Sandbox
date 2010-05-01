﻿using System;
using System.Collections.Generic;
using System.Linq;
using Fohjin.DDD.CommandHandlers;
using Fohjin.DDD.Commands;
using Fohjin.DDD.Domain.Account;
using Fohjin.DDD.Events.Account;
using Fohjin.DDD.EventStore;

namespace Test.Fohjin.DDD.Scenarios.Withdrawing_cash
{
    public class When_withdrawing_cash : CommandTestFixture<WithdrawlCashCommand, WithdrawlCashCommandHandler, ActiveAccount>
    {
        protected override IEnumerable<IDomainEvent> Given()
        {
            yield return PrepareDomainEvent.Set(new AccountOpenedEvent(Guid.NewGuid(), Guid.NewGuid(), "AccountName", "1234567890")).ToVersion(1);
            yield return PrepareDomainEvent.Set(new CashDepositedEvent(20, 20)).ToVersion(1);
        }

        protected override WithdrawlCashCommand When()
        {
            return new WithdrawlCashCommand(Guid.NewGuid(), 5);
        }

        [Then]
        public void Then_a_cash_withdrawn_event_will_be_published()
        {
            PublishedEvents.Last().WillBeOfType<CashWithdrawnEvent>();
        }

        [Then]
        public void Then_the_published_event_will_contain_the_amount_and_new_account_balance()
        {
            PublishedEvents.Last<CashWithdrawnEvent>().Balance.WillBe(15);
            PublishedEvents.Last<CashWithdrawnEvent>().Amount.WillBe(5);
        }
    }
}