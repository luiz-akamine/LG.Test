using LG.Test.Domain.Entities;
using LG.Test.Domain.Interfaces.Applications;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LG.Test.API.Controllers
{
    public class BaseController<TEntity> : ApiController where TEntity : EntityBase
    {
        private readonly IDBApplicationBase<TEntity> _applicationBase;

        public BaseController(IDBApplicationBase<TEntity> baseApplication)
        {
            _applicationBase = baseApplication;
        }


        // APIs

        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _applicationBase.GetAll().ToList());
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var obj = _applicationBase.Get(_ => _.Id == id);

                if (obj == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, obj);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public HttpResponseMessage Post(TEntity obj)
        {
            try
            {
                _applicationBase.Add(obj);
                return Request.CreateResponse(HttpStatusCode.Created, obj.Id);
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

        public HttpResponseMessage Put(TEntity obj)
        {
            try
            {
                _applicationBase.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ArgumentNullException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
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
