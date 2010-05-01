using System;
using MyShop.Commands.ProductCommands;
using MyShop.Commands.ShoppingCartCommands;
using MyShop.Commands.UserCommands;
using MyShop.Commands.VisitorCommands;
using Ncqrs.Commands;
using Ncqrs.CommandProcessing;

namespace MyShop.CommandHandlers
{
    public class MyShopCommandHandlerRegister : SimpleCommandHandlerRegister
    {
        // TODO: We neeeeed the handlers!
        //public MyShopCommandHandlerRegister()
        //{
        //    RegisterHandler<AddNewProduct>(new 


        //    bus.RegisterHandler(new AutoMappingCommandHandler<AddNewProduct>());
        //    bus.RegisterHandler(new AutoMappingCommandHandler<AddProductToShoppingCart>());
        //    bus.RegisterHandler(new AutoMappingCommandHandler<ChangeProductImage>());
        //    bus.RegisterHandler(new AutoMappingCommandHandler<RemoveProductFromShoppingCart>());
        //    bus.RegisterHandler(new AutoMappingCommandHandler<UpdateGeneralProductInformation>());
        //    bus.RegisterHandler(new AutoMappingCommandHandler<UpdateUnitPriceOfProduct>());
        //    bus.RegisterHandler(new AutoMappingCommandHandler<UpdateUnitsInStockOfProduct>());
        //    bus.RegisterHandler(new AutoMappingCommandHandler<ChangeProductItemQuantityInShoppingCart>());
        //    bus.RegisterHandler(new AutoMappingCommandHandler<AssignRoleToUser>());
        //    bus.RegisterHandler(new AutoMappingCommandHandler<RemoveRoleFromUser>());
        //    bus.RegisterHandler(new AutoMappingCommandHandler<AddNewVisitor>());
        //    bus.RegisterHandler(new AutoMappingCommandHandler<RegisterVisit>());
        //    bus.RegisterHandler(new AutoMappingCommandHandler<CreateShoppingCartForVisitor>());
        //    bus.RegisterHandler(new AutoMappingCommandHandler<RegisterNewUser>());
        //}

        //public void RegisterHandler<TCommand>(ICommandHandler handler) where TCommand : ICommand
        //{

        //}
    }
}
