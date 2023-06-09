﻿using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace Hospital_Management_System.DAL
{
    public class USER_DALBase : DALHelper
    {
        #region Method: dbo_PR_User_Master_SelectByPK
        public DataTable dbo_PR_User_Master_SelectByPK(int? UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_User_Master_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, UserID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method: dbo_PR_User_Master_SelectByUserNamePassword
        public DataTable dbo_PR_User_Master_SelectByUserNamePassword(string UserName, string Password)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_User_Master_SelectByUserNamePassword");
                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.VarChar, UserName);
                sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.VarChar, Password);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method: dbo_PR_User_Master_Insert
        public decimal? dbo_PR_User_Master_Insert(string UserName, string Password)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_User_Master_Insert");
                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.VarChar, UserName);
                sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.VarChar, Password);

                var vResult = sqlDB.ExecuteScalar(dbCMD);
                if (vResult == null)
                    return null;

                return (decimal)Convert.ChangeType(vResult, vResult.GetType());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
