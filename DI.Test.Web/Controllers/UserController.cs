using DI.Test.Web.DataAccessLayer.User;
using DI.Test.Web.Models;
using DI.Test.Web.Models.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DI.Test.Web.Controllers
{
    [Route("api/v1/users")]
    public class UserController : Controller
    {     
        private readonly IUserRepository<UserViewModel> _users;

        public UserController(IUserRepository<UserViewModel> repository)
        {
            _users = repository;
        }

        [HttpGet]
        public PagedList<UserViewModel> GetAll(QueryOptions options)
        {
            return _users.GetAll(options);
        }
        
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetById(string id)
        {
            bool resVerified = Common.IntPositiveTryParse(id, out int idParamVerified);
            if (!resVerified)
            {
                ModelState.SetIntPositiveValidationError(key: "IdParam", name: "id");
            }

            if (ModelState.IsValid)
            {
                return _users.Find(idParamVerified, out UserViewModel item)
                    ? ResponseHelper.Success(new ResponseSuccess(item).GetJson)
                    : ResponseHelper.Error(new ResponseError("IdParam", id).GetJson, HttpStatusCode.NotFound);
            }
            else
            {
                string responseObject = new ResponseErrorList(ModelState.GetResponseError()).GetJson;
                return ResponseHelper.Error(responseObject);
            }
        }
    }
}
