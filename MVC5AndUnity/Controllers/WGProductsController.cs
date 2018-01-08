using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TwoTierMVCReview.DAL;
using TwoTierMVCReview.DAL.Repositories;

namespace MVC5AndUnity.Controllers
{
    public class WGProductsController : Controller
    {
        //we want to use our repository!
        //private ZMoviesEntities db = new ZMoviesEntities();

        //first version using dependent, tightly coupled code
        //private readonly WGProductRepository _repo;

        //second version using loosely coupled code with 
        //constructor injection
        private readonly IWGProductRepository _repo;

        //by making this into a parameter that accepts any datatype
        //implementing the IWGProductRepository, we have achieved
        //Dependency Injection with loosely coupled code.
        //Now we can use Unity to inject our dependency automatically
        public WGProductsController(IWGProductRepository injectedRepo)
        {
            //for version 2 make this into a parameter
            _repo = injectedRepo;
        }


        // GET: WGProducts
        public ActionResult Index()
        {
            //var wGProducts = db.WGProducts.Include(w => w.WGCategory).Include(w => w.WGProductStatus).Include(w => w.WGVendor);
            var wGProducts = _repo.GetAll();
            return View(wGProducts.ToList());
        }

        // GET: WGProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //WGProduct wGProduct = db.WGProducts.Find(id);
            WGProduct wGProduct = _repo.Find(id);
            if (wGProduct == null)
            {
                return HttpNotFound();
            }
            return View(wGProduct);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
