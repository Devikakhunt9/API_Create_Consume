using API.BAL;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region // GET: api/<UserController>
        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            User_BALBase bal = new User_BALBase();
            List<UserModel> users = bal.PR_SelectAll_User();
            Dictionary<string, dynamic> res = new Dictionary<string, dynamic>();
            if (users != null && users.Count > 0)
            {
                res.Add("status", true);
                res.Add("msg", "data found");
                res.Add("data", users);
                return Ok(res);
            }
            else
            {
                res.Add("status", false);
                res.Add("msg", "data not found");
                res.Add("data", null);
                return NotFound(res);
            }
        }
        #endregion


        #region // GET api/<UserController>/5
        // GET api/<UserController>/5
        [HttpGet("{UserID}")]
        public IActionResult Get(int UserID)
        {
            User_BALBase bal = new User_BALBase();
            UserModel users = bal.PR_SelectBYID_USer(UserID);
            Dictionary<string, dynamic> res = new Dictionary<string, dynamic>();
            if (users.UserId != 0)
            {
                res.Add("status", true);
                res.Add("msg", "data found");
                res.Add("data", users);
                return Ok(res);
            }
            else
            {
                res.Add("status", false);
                res.Add("msg", "data not found");
                res.Add("data", null);
                return NotFound(res);
            }

        }
        #endregion


        #region  // POST api/<UserController>
        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromForm] UserModel form)
        {
            User_BALBase bal = new User_BALBase();
            bool msg = bal.PR_INSERT_USER(form);
            Dictionary<string, dynamic> res = new Dictionary<string, dynamic>();
            if (msg)
            {
                res.Add("status", true);
                res.Add("msg", "data inserteted successsfully");
                return Ok(res);
            }
            else
            {
                res.Add("status", false);
                res.Add("msg", "data not found");
                res.Add("data", null);
                return NotFound(res);
            }

        }
        #endregion


        #region // PUT api/<UserController>/5
        // PUT api/<UserController>/5
        [HttpPut("{UserID}")]
        public IActionResult Put(int UserID, [FromForm] UserModel form)
        {
            User_BALBase bal = new User_BALBase();
            bool msg = bal.PR_Update_BY_ID(UserID, form);
            Dictionary<string, dynamic> res = new Dictionary<string, dynamic>();
            if (msg)
            {
                res.Add("status", true);
                res.Add("msg", "data Updated successsfully");
                return Ok(res);
            }
            else
            {
                res.Add("status", false);
                res.Add("msg", "data not found");
                return NotFound(res);
            }

        }
        #endregion


        #region // DELETE api/<UserController>/5
        // DELETE api/<UserController>/5
        [HttpDelete("{UserID}")]
        public IActionResult Delete(int UserID)
        {
            User_BALBase bal = new User_BALBase();
            bool msg = bal.PR_DeleteBY_UserID(UserID);
            Dictionary<string, dynamic> res = new Dictionary<string, dynamic>();
            if (msg)
            {
                res.Add("status", true);
                res.Add("msg", "data deleted successfully");
                return Ok(res);
            }
            else
            {
                res.Add("status", false);
                res.Add("msg", "data not found");
                return NotFound(res);
            }
        }
        #endregion
    }
}
