using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using damacanadb.Models;
namespace damacanadb.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            carts.Add(cart1);
            purchases.Add(purchase1);

            return View(products);
        }

        public static List<Product> products = new List<Product>(){
            new Product()
            {
                Id = 1,
                Name = "Erikli",
                Price = (decimal)9.50,
            },
            new Product()
            {
                Id = 2,
                Name = "Hayat",
                Price = (decimal)7.90,
            }
        };


        public static List<Product> cartproducts = new List<Product>() { };

        public static List<Cart> carts = new List<Cart>() { };

        public static List<Purchase> purchases = new List<Purchase>() { };

        Cart cart1 = new Cart()
        {
            Id = 0,
            UserId = 1,
            cartproducts = products,
        };

        Purchase purchase1 = new Purchase()
        {
            Id = 0,
            UserId = 1,
            TotalPrice = 0,
            purchaselist = products,
        };
        public ActionResult ProductList()
        {
            return View(products);
        }

        public ActionResult AddProduct()
        {
            Product product = new Product()
            {
                Name = "",
                Price = (decimal)0
            };
            return View(product);
        }

        [HttpPost]
        public ActionResult SaveProduct(Product product)
        {
            products.Add(product);
            return View(product);
        }

        public ActionResult AddToCart(string Name)
        {
            // TODO find product from this.products
            Product product = new Product(); // lıstenın ıcınde buldugumuz product


            // sepete ekleme işlemi
            foreach (var p in products)
            {
                if (p.Name == Name)
                {
                    product.Name = p.Name;
                    product.Price = p.Price;
                    product.Id = p.Id;
                    cartproducts.Add(p);
                    break;
                }
            }

            return View(product); //sepete eklenmistir goruntusu.
        }



        public ActionResult MyPurchase()
        {
            return View(purchases);

        }

        decimal Total;


        public ActionResult DeleteProduct(string Name)
        {
            foreach (Product p in products)
            {
                if (p.Name == Name)
                {
                    products.Remove(p);
                    break;
                }
            }
            return View();
        }

        public ActionResult DeleteInCart(string Name)
        {
            foreach (Product p in cartproducts)
            {
                if (p.Name == Name)
                {
                    cartproducts.Remove(p);
                    break;
                }
            }
            return View();
        }


        public ActionResult EditProduct(string Name)
        {
            Product product = new Product();
            foreach (Product p in products)
            {
                if (p.Name == Name)
                {
                    product.Name = p.Name;
                    product.Price = p.Price;
                    product.Id = p.Id;

                    products.Remove(p);
                    break;
                }
            }
            return View(product);
        }
        public ActionResult Editt(Product product)
        {
            products.Add(product);
            return View(product);
        }

        int i = 1;
        public ActionResult Buy()
        {
            Cart cart = new Cart();
            cart.TotalPrice = 0;
            cart.cartproducts = new List<Product>();
            cart.Id = i;
            cart.UserId = 1;
            Product product = new Product();
            foreach (Product p in cartproducts)
            {
                product.Id = p.Id;
                product.Name = p.Name;
                product.Price = p.Price;
                cart.cartproducts.Add(product);
                cart.TotalPrice += p.Price;
                i++;
            }
            return View(cart);
        }

        public ActionResult MyCart()
        {
            return View(cartproducts);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}