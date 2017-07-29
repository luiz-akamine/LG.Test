using LG.Test.Domain.Entities;
using LG.Test.Domain.Interfaces.Applications;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LG.Test.API.Controllers
{
    [RoutePrefix("api/stock")]
    public class StockController : BaseController<Stock>
    {
        private readonly IStockApplication _stockApplication;

        public StockController(IDBApplicationBase<Stock> baseApplication, IStockApplication stockApplication) : base(baseApplication)
        {
            _stockApplication = stockApplication;
        }

        [AcceptVerbs("POST")]
        public HttpResponseMessage IncStock([FromBody]Product product)
        {
            try
            {                
                return Request.CreateResponse(HttpStatusCode.OK, _stockApplication.IncStock(product));
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

        [AcceptVerbs("POST")]
        public HttpResponseMessage DecStock(Product product)
        {
            try
            {                
                return Request.CreateResponse(HttpStatusCode.OK, _stockApplication.DecStock(product));
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
