using LG.Test.Domain.DTO;
using LG.Test.Domain.Entities;
using LG.Test.Domain.Interfaces.Applications;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LG.Test.API.Controllers
{
    public class StockMovController : BaseController<StockMov>
    {
        private readonly IStockMovApplication _stockMovApplication;

        public StockMovController(IDBApplicationBase<StockMov> baseApplication, IStockMovApplication stockMovApplication) : base(baseApplication)
        {
            _stockMovApplication = stockMovApplication;
        }

        [AcceptVerbs("POST")]
        public HttpResponseMessage RequestOrder([FromBody]CartDTO cart)
        {
            try
            {
                _stockMovApplication.RequestOrder(cart);
                return Request.CreateResponse(HttpStatusCode.OK);
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
