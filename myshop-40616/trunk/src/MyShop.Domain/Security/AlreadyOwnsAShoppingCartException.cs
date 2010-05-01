using System;

namespace MyShop.Domain.Security
{
    public class AlreadyOwnsAShoppingCartException : Exception
    {
        public Guid OwningShoppingCartId { get; private set; }

        public AlreadyOwnsAShoppingCartException(Guid owningShoppingCartId)
        {
            OwningShoppingCartId = owningShoppingCartId;
        }
    }
}
