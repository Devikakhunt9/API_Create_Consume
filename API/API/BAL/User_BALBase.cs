using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.DAL;

namespace API.BAL
    
{
    public class User_BALBase
    {
        public List<UserModel> PR_SelectAll_User()
        {
            User_DALBase user_DALBase = new User_DALBase();
            List<UserModel> userModels = user_DALBase.PR_SelectAll_User();   
            return userModels;
        }

        public UserModel PR_SelectBYID_USer(int UserID)
        {
            User_DALBase user_DalBase = new User_DALBase();
            UserModel userModels = user_DalBase.PR_SelectBYID_USer(UserID);
            return userModels;
        }

        public bool PR_INSERT_USER([FromBody] UserModel form)
        => new User_DALBase().PR_INSERT_USER(form);


        public bool PR_DeleteBY_UserID(int UserID)
        {
           
           User_DALBase user_DALBase=new User_DALBase();
            return user_DALBase.PR_DeleteBY_UserID(UserID);
             
        }
        public bool PR_Update_BY_ID(int UserID, [FromBody] UserModel form)
        =>new User_DALBase().PR_Update_BY_ID(UserID,form);
        


    }
}
