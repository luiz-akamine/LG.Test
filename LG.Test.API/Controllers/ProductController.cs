using LG.Test.Domain.DTO;
using LG.Test.Domain.Entities;
using LG.Test.Domain.Interfaces.Applications;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LG.Test.API.Controllers
{
    public class ProductController : BaseController<Product>
    {
        private readonly IProductApplication _productApplication;

        public ProductController(IDBApplicationBase<Product> baseApplication, IProductApplication productApplication) : base(baseApplication)
        {
            _productApplication = productApplication;
        }

        [AcceptVerbs("POST")]
        public HttpResponseMessage AddToCart([FromBody]CartDTO cart)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _productApplication.AddToCart(cart));
            }
            catch (ArgumentException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
