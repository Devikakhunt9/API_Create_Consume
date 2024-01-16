using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using API.Models;
using API.DAL;


namespace API.DAL
{
    public class User_DALBase : DAL_Helpers
    {
        #region SelectAllUser
        public List<UserModel> PR_SelectAll_User()
        {
            SqlDatabase sqlDatabase = new SqlDatabase(Conn);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_ALL_USER");
            List<UserModel> userModels = new List<UserModel>();
            using(IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    UserModel um = new UserModel();
                    um.UserId = Convert.ToInt32(dr["UserID"].ToString());
                    um.UserName = dr["UserName"].ToString();
                    um.UserEmail = dr["UserEmail"].ToString();
                    um.UserContact = dr["UserContact"].ToString();
                    userModels.Add( um );
                }
            }
            return userModels;
        }
        #endregion


        #region SelectByIDUSer
        public UserModel PR_SelectBYID_USer(int USerID)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(Conn);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_BY_PK_USER");
            sqlDatabase.AddInParameter(dbCommand, "@UserID", SqlDbType.Int, USerID);
            UserModel um = new UserModel();
            using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    um.UserId = Convert.ToInt32(dr["UserID"].ToString());
                    um.UserName = dr["UserName"].ToString();
                    um.UserEmail = dr["UserEmail"].ToString();
                    um.UserContact = dr["UserContact"].ToString();
                }     
            }
            return um;
        }

        #endregion


        #region InsertUser
        public bool PR_INSERT_USER(UserModel form)
        {
            SqlDatabase sqlDatabase= new SqlDatabase(Conn);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_INSERT_USER");
            sqlDatabase.AddInParameter(dbCommand, "@UserName", SqlDbType.Text, form.UserName);
            sqlDatabase.AddInParameter(dbCommand, "@UserEmail",SqlDbType.VarChar, form.UserEmail );
            sqlDatabase.AddInParameter(dbCommand, "@UserContact", SqlDbType.VarChar,form.UserContact );
            sqlDatabase.ExecuteNonQuery(dbCommand);
            return true ;
        }
        #endregion

        #region UpdateUSer
        public bool PR_Update_BY_ID(int USerID,UserModel form)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(Conn);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Update_BY_ID");
            sqlDatabase.AddInParameter(dbCommand, "@UserID", SqlDbType.Int, USerID);
            if(USerID != 0)
            {
                sqlDatabase.AddInParameter(dbCommand, "@UserName", SqlDbType.VarChar, form.UserName);
                sqlDatabase.AddInParameter(dbCommand, "@UserEmail", SqlDbType.VarChar, form.UserEmail);
                sqlDatabase.AddInParameter(dbCommand, "@UserContact", SqlDbType.VarChar, form.UserContact);
                sqlDatabase.ExecuteNonQuery(dbCommand);
                return true;
            }
            else
            {
                return false ;
            }
            
        }
        #endregion

        #region DeleteBYUSerID
        public bool PR_DeleteBY_UserID(int UserID)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(Conn);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_DeleteBY_UserID");
            sqlDatabase.AddInParameter(dbCommand, "@UserID", SqlDbType.Int, UserID);
            sqlDatabase.ExecuteNonQuery(dbCommand);
            return true;
        }
        #endregion
    }
}
