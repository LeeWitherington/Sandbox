using System;
using System.Collections.Generic;
using MyShop.Domain.Framework;
using MyShop.Events;
using MyShop.Events.ProductEvents;

namespace MyShop.Domain
{
    public class Product : AggregateRoot
    {
        #region Members

        private String _description;
        private Image _image;
        private String _name;
        private decimal _unitPrice;
        private int? _unitsInStock;

        #endregion

        #region Initialization

        public Product(String name, String description, Decimal unitPrice, int unitsInStock)
        {
            var e = new NewProductCreated(Guid.NewGuid(), name, description, unitPrice, unitsInStock);
            ApplyEvent(e);
        }

        public Product(IEnumerable<HistoricalEvent> history)
            : base(history)
        {
        }

        protected override void InitializeHandlers()
        {
            RegisterHandler<NewProductCreated>(NewProductCreatedEventHandler);
            RegisterHandler<ProductStockInformationUpdated>(ProductStockInformationUpdatedEventHandler);
            RegisterHandler<ProductUnitPriceChanged>(ProductUnitPriceChangedEventHandler);
            RegisterHandler<GeneralProductInformationUpdated>(GeneralProductInformationUpdatedEventHandler);
            RegisterHandler<ProductImageChanged>(ProductImageChangedEventHandler);
        }

        #endregion

        #region Command methods

        public void ChangeUnitPrice(Decimal unitPrice)
        {
            if(_unitsInStock > 0)
            {
                throw new InvalidOperationException("Cannot change unit price while there are still units in stock.");
            }

            var e = new ProductUnitPriceChanged(Id, unitPrice);
            ApplyEvent(e);
        }

        public void ChangeProductImage(String filename, Byte[] imageData)
        {
            var e = new ProductImageChanged(Id, filename, imageData);
            ApplyEvent(e);
        }

        public void UpdateGeneralInformation(String name, String description)
        {
            var e = new GeneralProductInformationUpdated(Id, name, description);
            ApplyEvent(e);
        }

        public void UpdateTheNumberOfUnitsInStock(int? unitsInStock)
        {
            var e = new ProductStockInformationUpdated(Id, unitsInStock);
            ApplyEvent(e);
        }

        #endregion

        #region Event Handlers

        private void NewProductCreatedEventHandler(NewProductCreated e)
        {
            // TODO: if(Version !- 0) throw new Illiga

            Id = e.ProductId;
            _name = e.Name;
            _description = e.Description;
            _unitPrice = e.UnitPrice;
            _unitsInStock = e.UnitsInStock;
        }

        private void ProductStockInformationUpdatedEventHandler(ProductStockInformationUpdated e)
        {
            //if(e.ProductId != Id) throw new InvalidEvent

            _unitsInStock = e.UnitsInStock;
        }

        private void ProductUnitPriceChangedEventHandler(ProductUnitPriceChanged e)
        {
            _unitPrice = e.UnitPrice;
        }

        private void GeneralProductInformationUpdatedEventHandler(GeneralProductInformationUpdated e)
        {
            _name = e.Name;
        }

        private void ProductImageChangedEventHandler(ProductImageChanged e)
        {
            _image = new Image(e.Filename, e.ImageData);
        }

        #endregion
    }
}