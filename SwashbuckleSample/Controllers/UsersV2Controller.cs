using System;
using System.Web.Http;
using SwashbuckleSample.Models;
using SwashbuckleSample.Repositories;

namespace SwashbuckleSample.Controllers
{
    /// <summary>
    /// CRUD operations on user model. This is the v2 of the api
    /// </summary>
    [Route("api/v2/users")]
    public class UsersV2Controller : UsersV1Controller
    {
        private readonly UserRepository _userRepository;

        /// <summary>
        /// Crud operations for users
        /// </summary>
        public UsersV2Controller()
        {
            _userRepository = new UserRepository();
        }

        /// <summary>
        /// This method is deprecated, please use GetUserNew instead. In the next version this will be removed!
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v2/users/{id}")]
        [Obsolete]
        public override User Get(int id)
        {
            return _userRepository.Find(id);
        }


        [HttpGet]
        [Route("api/v2/users/getusernew/{id}")]
        public User GetUserNew(int id)
        {
            return _userRepository.Find(id);
        }
    }
}