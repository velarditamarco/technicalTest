using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TechTest.Implementation;
using TechTest.Models;

namespace TechTest.Controllers
{
    public class UsersController : ApiController
    {
        private IUsersLogic _data = new UsersLogic();


        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_data.Get());
        }

        [HttpGet]    
        public IHttpActionResult GetById([FromUri] Guid id)
        {
            return Ok(_data.GetUserByID(id));
        }

        [HttpPost]
        public IHttpActionResult Post(UsersViewModel newUser)
        {
            _data.CreateUser(newUser);
            return Ok("User Created");
        }

        [HttpPut]
        public IHttpActionResult Put(Guid id, UsersViewModel user)
        {
            _data.UpdateUser(id, user);

            return Ok("User Updated");
        }

        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            _data.DeleteUser(id);

            return Ok("User Deleted");
        }


    }
}