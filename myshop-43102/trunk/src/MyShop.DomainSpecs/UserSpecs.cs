using System;
using MyShop.Domain.Security;
using MyShop.DomainSpecs.SpecFramework;
using MyShop.Events.UserEvents;
using System.Collections.Generic;
using MyShop.Events;
using System.Linq;

namespace MyShop.DomainSpecs
{
    // TODO: Change spec
    //[Specification]
    //public class When_creating_a_new_user : AggregateRootTestFixture<User>
    //{
    //    protected override void When()
    //    {
    //        AggregateRoot = new User("username", "password", "pj@born2code.net");
    //    }

    //    [Then]
    //    public void Then_only_one_event_should_have_been_published()
    //    {
    //        PublishedEvents.CountIs(1);
    //    }

    //    [Then]
    //    public void Then_a_NewUserCreated_event_should_have_been_published_with_the_same_values_as_the_constructor()
    //    {
    //        PublishedEvents.Number(1).WillBeOfType<NewUserCreated>();
    //        PublishedEvents.Number(1).WillBe(new NewUserCreated(AggregateRoot.Id, "username", "password", "pj@born2code.net"));
    //    }
    //}

    [Specification]
    public class When_building_a_user_from_history : AggregateRootTestFixture<User>
    {
        protected override IEnumerable<HistoricalEvent> Given()
        {
            var userId = Guid.NewGuid();

            yield return new HistoricalEvent(DateTime.Now, new NewUserCreated(userId, "username", "password", "pj@born2code.net"));
            yield return new HistoricalEvent(DateTime.Now, new RoleAssignedToUser("myrole", userId));
        }

        protected override void When()
        {
            // Nothing todo.
        }

        [Then]
        public void Then_there_should_be_no_published_events()
        {
            PublishedEvents.CountIs(0);
        }
    }

    [Specification]
    public class When_assigning_a_empty_rolename : AggregateRootTestFixture<User>
    {
        protected override void When()
        {
            AggregateRoot.AssignRoleToUser(String.Empty);
        }

        [Then]
        public void Then_a_ArgumentNullException_should_been_thrown()
        {
            CaughtException.WillBeOfType<ArgumentNullException>();
        }
    }

    [Specification]
    public class When_assigning_a_null_rolename : AggregateRootTestFixture<User>
    {
        protected override void When()
        {
            AggregateRoot.AssignRoleToUser(null);
        }

        [Then]
        public void Then_a_ArgumentNullException_should_been_thrown()
        {
            CaughtException.WillBeOfType<ArgumentNullException>();
        }
    }

    [Specification]
    public class When_assigning_a_role_to_user : AggregateRootTestFixture<User>
    {
        protected override void When()
        {
            AggregateRoot.AssignRoleToUser("myrole");
        }

        [Then]
        public void Then_a_RoleAssignedToUser_event_should_have_been_published()
        {
            PublishedEvents.Last().WillBeOfType<RoleAssignedToUser>();
        }

        [Then]
        public void Then_the_RoleAssignedToUser_event_should_have_to_correct_user_id()
        {
            PublishedEvents.Last<RoleAssignedToUser>().UserId.WillBe(AggregateRoot.Id);
        }

        [Then]
        public void Then_the_RoleAssignedToUser_event_should_have_the_same_values_as_given()
        {
            PublishedEvents.Last<RoleAssignedToUser>().RoleName.WillBe("myrole");
        }
    }

}
