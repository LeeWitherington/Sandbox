using System;
using System.Collections.Generic;
using System.Linq;
using MyShop.Events.ShoppingCartEvents;
using Ncqrs.Domain;
using Ncqrs.Eventing;
using Ncqrs.Eventing.Mapping;

namespace MyShop.Domain
{
    public class ShoppingCart : AggregateRoot
    {
        private readonly List<ShoppingCartItem> _items = new List<ShoppingCartItem>();
        private Guid _visitorId;

        public ShoppingCart(Guid visitorId)
        {
            var e = new NewShoppingCartCreated(visitorId, Id);
            ApplyEvent(e);
        }

        public ShoppingCart(IEnumerable<HistoricalEvent> history)
            : base(history)
        {
        }

        public void AddProduct(Guid productId, int quantity)
        {
            ShoppingCartItem item = _items.FirstOrDefault(i => i.ProductId == productId);

            if (item == null)
            {
                var e = new ProductAddedToShoppingCart(Id, productId, quantity);
                ApplyEvent(e);
            }
            else
            {
                int newQuantity = item.Quantity + quantity;
                ChangeProductQuanity(productId, newQuantity);
            }
        }

        public void ChangeProductQuanity(Guid productId, int newQuantity)
        {
            var e = new ProductQuantityInShoppingCartChanged(Id, productId, newQuantity);
            ApplyEvent(e);
        }

        public void RemoveProduct(Guid productId)
        {
            var e = new ProductRemovedFromShoppingCart(Id, productId);
            ApplyEvent(e);
        }

        [EventHandler]
        private void NewShoppingCartCreatedEventHandler(NewShoppingCartCreated e)
        {
            OverrideId(e.ShoppingCartId);
            _visitorId = e.VisitorId;
        }

        [EventHandler]
        private void ProductAddedToShoppingCartEventHandler(ProductAddedToShoppingCart e)
        {
            var item = new ShoppingCartItem(e.ProductId, e.Quantity);
            _items.Add(item);
        }

        [EventHandler]
        private void ProductQuantityInShoppingCartChangedEventHandler(ProductQuantityInShoppingCartChanged e)
        {
            ShoppingCartItem item = _items.Find(i => i.ProductId == e.ProductId);
            item.Quantity = e.NewQuantity;
        }

        [EventHandler]
        private void ProductRemovedFromShoppingCartEventHandler(ProductRemovedFromShoppingCart e)
        {
            _items.RemoveAll(i => i.ProductId == e.ProductId);
        }
    }
}