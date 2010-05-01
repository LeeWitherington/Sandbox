using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyShop.DomainSpecs.SpecFramework;
using MyShop.Domain;

namespace MyShop.DomainSpecs
{
    public class When_a_valid_image_is_created : ValueObjectTestFixture<Image>
    {
        protected override Image When()
        {
            return new Image("image.jpg", new byte[] { 0x01, 0x02, 0x03, 0x04 });
        }

        [Then]
        public void Then_it_should_be_equal_to_another_instance_with_the_same_value()
        {
            var otherInstance = new Image("image.jpg", new byte[] {0x01, 0x02, 0x03, 0x04});
            ValueObject.Equals(otherInstance).WillBe(true);
            (ValueObject == otherInstance).WillBe(true);
        }
    }
}
