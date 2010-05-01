using System;
using MyShop.Bus.CommandBus;
using MyShop.CommandHandlers.AutoMapping;
using MyShop.Commands.ProductCommands;
using MyShop.Commands.ShoppingCartCommands;
using MyShop.Commands.UserCommands;
using MyShop.Commands.VisitorCommands;

namespace MyShop.CommandHandlers
{
    public class MyShopCommandHandlerRegister
    {
        public void RegisterHandlers(ICommandBus bus)
        {
            bus.RegisterHandler(new AutoMappingCommandHandler<AddNewProduct>());
            bus.RegisterHandler(new AutoMappingCommandHandler<AddProductToShoppingCart>());
            bus.RegisterHandler(new AutoMappingCommandHandler<ChangeProductImage>());
            bus.RegisterHandler(new AutoMappingCommandHandler<RemoveProductFromShoppingCart>());
            bus.RegisterHandler(new AutoMappingCommandHandler<UpdateGeneralProductInformation>());
            bus.RegisterHandler(new AutoMappingCommandHandler<UpdateUnitPriceOfProduct>());
            bus.RegisterHandler(new AutoMappingCommandHandler<UpdateUnitsInStockOfProduct>());
            bus.RegisterHandler(new AutoMappingCommandHandler<ChangeProductItemQuantityInShoppingCart>());
            bus.RegisterHandler(new AutoMappingCommandHandler<AssignRoleToUser>());
            bus.RegisterHandler(new AutoMappingCommandHandler<RemoveRoleFromUser>());
            bus.RegisterHandler(new AutoMappingCommandHandler<AddNewVisitor>());
            bus.RegisterHandler(new AutoMappingCommandHandler<RegisterVisit>());
            bus.RegisterHandler(new AutoMappingCommandHandler<CreateShoppingCartForVisitor>());
            bus.RegisterHandler(new AutoMappingCommandHandler<RegisterNewUser>());
        }
    }
}
