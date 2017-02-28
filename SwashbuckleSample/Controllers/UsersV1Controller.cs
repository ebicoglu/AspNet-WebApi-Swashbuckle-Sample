using System;
using System.Net;
using System.Web.Http;
using SwashbuckleSample.Models;
using SwashbuckleSample.Repositories;

namespace SwashbuckleSample.Controllers
{
    /// <summary>
    /// CRUD operations on user model. This is the v1 of the api
    /// </summary>
    [Route("api/v1/users")]
    public class UsersV1Controller : ApiController
    {
        private readonly UserRepository _userRepository;

        /// <summary>
        /// Crud operations for users
        /// </summary>
        public UsersV1Controller()
        {
            _userRepository = new UserRepository();
        }


        /// <summary xml:lang="en-US">
        ///Wellcome message
        /// </summary>
        /// <summary xml:lang="tr">
        ///Hoşgeldiniz 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Get()
        {
            return "Wellcome to my WebAPI - V1";
        }

        /// <summary>
        /// Gets a user by id.
        /// </summary>
        /// <remarks>Id is integer and must be greater than zero!</remarks>
        /// <param name="id">Id of the user</param>
        /// <returns>User object</returns>
        [HttpGet] 
        [Route("api/v1/users/{id}")]
        public virtual User Get(int id)
        {
            return _userRepository.Find(id);
        }

        /// <summary>
        /// Creates new user.
        /// </summary>
        /// <param name="newUser">New user to be created</param>
        [HttpPost]
        public IHttpActionResult Post([FromBody]User newUser)
        {
            _userRepository.Add(newUser);
            return Ok();
        }

        /// <summary>
        /// Updates user.
        /// </summary>
        /// <param name="id">id of user</param>
        /// <param name="user">user to be updated</param>
        /// <returns>200 HTPP Ok with the message "Successfully updated."</returns>
        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] User user)
        {
            //validation-1
            if (user == null || id <= 0)
            {
                return Content(HttpStatusCode.BadRequest, "User cannot be null and id must be greater than zero!");
            }

            //validation-2
            var userOld = _userRepository.Find(id);
            if (userOld == null)
            {
                return Content(HttpStatusCode.NotFound, "User does not exist!");
            }

            userOld.Email = user.Email;
            userOld.Name = user.Name;

            _userRepository.Update(userOld);
            return Content(HttpStatusCode.OK, "Successfully updated.");
        }


        /// <summary>
        /// Deletes an existing user
        /// </summary>
        /// <param name="id">User to be deleted</param>
        /// <returns>Http-200 OK if success.</returns>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var todo = _userRepository.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _userRepository.Remove(id);
            return Content(HttpStatusCode.OK, "Successfully deleted.");
        }


    }
}