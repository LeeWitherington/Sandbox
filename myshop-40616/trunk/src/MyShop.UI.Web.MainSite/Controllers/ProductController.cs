using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Commands;
using MyShop.Commands.ProductCommands;
using MyShop.ReadModel;
using MyShop.UI.Web.MainSite.Core;

namespace MyShop.UI.Web.MainSite.Controllers
{
    public class ProductController : MyShopController
    {
        public ActionResult List()
        {
            using (var context = new MyShopReadModelDataContext())
            {
                var result = context.Products.ToList();
                return View(result);
            }
        }

        [Authorize(Roles=MyShopRoles.Administrator)]
        public ActionResult Edit(Guid id)
        {
            using (var context = new MyShopReadModelDataContext())
            {
                var result = context.Products.FirstOrDefault(p => p.Id == id);

                if (result == null)
                {
                    return View("NotFound");
                }
                else
                {
                    return View(result);
                }
            }
        }

        [HttpPost]
        [Authorize(Roles = MyShopRoles.Administrator)]
        public ActionResult Edit(Product edited)
        {
            using (var context = new MyShopReadModelDataContext())
            {
                Product original = context.Products.FirstOrDefault(p => p.Id == edited.Id);

                if (original == null)
                {
                    return View("NotFound");
                }
                else
                {
                    var commands = new List<ICommand>(GetCommandsForEditedProduct(original, edited));

                    if (commands.Count > 0)
                    {
                        MyShopWebApplication.CommandBus.Publish(commands.ToArray());
                    }

                    return View(edited);
                }
            }
        }

        protected IEnumerable<ICommand> GetCommandsForEditedProduct(Product original, Product edited)
        {
            if (original.Name != edited.Name ||
                original.Description != edited.Description)
            {
                yield return new UpdateGeneralProductInformation(original.Id, edited.Name, edited.Description);
            }

            if (original.UnitPrice != edited.UnitPrice)
            {
                yield return new UpdateUnitPriceOfProduct(original.Id, edited.UnitPrice);
            }

            if (original.UnitsInStock != edited.UnitsInStock)
            {
                yield return new UpdateUnitsInStockOfProduct(original.Id, edited.UnitsInStock);
            }

            if (Request.Files.AllKeys.Contains("productImageFile"))
            {
                HttpPostedFileBase filePost = Request.Files["productImageFile"];

                if (String.IsNullOrEmpty(filePost.FileName) && filePost.ContentLength > 0)
                {
                    yield return new ChangeProductImage(edited.Id, filePost.FileName, filePost.InputStream);
                }
            }

            yield break;
        }

        public ActionResult Details(Guid id)
        {
            ActionResult result;

            using (var context = new MyShopReadModelDataContext())
            {
                Product product = context.Products.FirstOrDefault(p => p.Id == id);

                if (product == null)
                {
                    result = View("NotFound");
                }
                else
                {
                    result = View(product);
                }
            }

            return result;
        }

        [Authorize(Roles = MyShopRoles.Administrator)]
        public ActionResult Create()
        {
            var command = new AddNewProduct();
            return View(command);
        }

        [HttpPost]
        [Authorize(Roles = MyShopRoles.Administrator)]
        public ActionResult Create(AddNewProduct newProductCommand)
        {
            MyShopWebApplication.CommandBus.Publish(newProductCommand);
            return RedirectToAction("List", "Product");
        }
    }
}