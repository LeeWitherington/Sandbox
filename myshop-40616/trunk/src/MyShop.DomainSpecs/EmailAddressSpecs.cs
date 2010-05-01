using System;
using MyShop.Domain;
using MyShop.DomainSpecs.SpecFramework;
using NUnit.Framework;

namespace MyShop.DomainSpecs
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class Constructing_EmailAddress_with_a_illigal_formatted_value : ValueObjectTestFixture<EmailAddress>
    {
        protected override EmailAddress When()
        {
            const string illigalFormattedValue = "xxx";
            return new EmailAddress(illigalFormattedValue);
        }

        [Then]
        public void Then_a_InvalidEmailAddressException_should_be_thrown()
        {
            CaughtException.WillBeOfType<InvalidEmailAddressException>();
        }

        [Test]
        public void EmailAddress_should_be_equal_by_value()
        {
            var a = new EmailAddress("pjvandesande@born2code.net");
            var b = new EmailAddress("pjvandesande@born2code.net");

            Assert.AreEqual(a, b);

            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(b.Equals(a));

            Assert.IsTrue(a == b);
            Assert.IsTrue(b == a);
        }
    }

    public class When_a_valid_email_address_is_created : ValueObjectTestFixture<EmailAddress>
    {
        protected override EmailAddress When()
        {
            const string value = "pj@born2code.net";
            return new EmailAddress(value);
        }

        [Then]
        public void Then_it_should_be_equal_to_another_instance_with_the_same_value()
        {
            var otherInstance = new EmailAddress("pj@born2code.net");
            ValueObject.Equals(otherInstance).WillBe(true);
            (ValueObject == otherInstance).WillBe(true);
        }

        [Then]
        public void Then_it_should_have_the_same_value_as_specified_at_construct()
        {
            ValueObject.Value.WillBe("pj@born2code.net");
        }
    }
    // ReSharper restore InconsistentNaming
}
