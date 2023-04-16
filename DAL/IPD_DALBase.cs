using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Hospital_Management_System.Areas.IPD.Models;
using Hospital_Management_System.BAL;

namespace Hospital_Management_System.DAL
{
    public class IPD_DALBase : DALHelper
    {
        #region PR_IPD_SelectAll
        public DataTable PR_IPD_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_IPD_SelectAll");
                sqlDB.AddInParameter(dbCMD, "UserID", DbType.Int32, CV.UserID());

                DataTable dtIPD = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dtIPD.Load(dr);
                }
                return dtIPD;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region PR_IPD_DeleteByPK
        public DataTable PR_IPD_DeleteByPK(int IPDID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_IPD_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "IPDID", SqlDbType.Int, IPDID);
                sqlDB.AddInParameter(dbCMD, "UserID", DbType.Int32, CV.UserID());

                DataTable dtIPD = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dtIPD.Load(dr);
                }
                return dtIPD;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region PR_IPD_Insert
        public DataTable PR_IPD_Insert(IPDModel modelIPD)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_IPD_Insert");

                sqlDB.AddInParameter(dbCMD, "UserID", DbType.Int32, CV.UserID());
                sqlDB.AddInParameter(dbCMD, "PatientID", SqlDbType.Int, modelIPD.PatientID);
                sqlDB.AddInParameter(dbCMD, "DoctorID", SqlDbType.Int, modelIPD.DoctorID);
                sqlDB.AddInParameter(dbCMD, "RoomID", SqlDbType.Int, modelIPD.RoomID);
                sqlDB.AddInParameter(dbCMD, "BuildingID", SqlDbType.Int, modelIPD.BuildingID);
                sqlDB.AddInParameter(dbCMD, "Problem", SqlDbType.NVarChar, modelIPD.Problem);
                sqlDB.AddInParameter(dbCMD, "CreationDate", SqlDbType.DateTime, DBNull.Value);
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.DateTime, DBNull.Value);
                //sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.NVarChar, CV.UserID());

                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region PR_IPD_SelectByPK
        public DataTable PR_IPD_SelectByPK(int IPDID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_IPD_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "IPDID", SqlDbType.Int, IPDID);
                sqlDB.AddInParameter(dbCMD, "UserID", DbType.Int32, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion

        #region PR_IPD_UpdateByPK
        public DataTable PR_IPD_UpdateByPK(IPDModel modelIPD)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_IPD_UpdateByPK");

                sqlDB.AddInParameter(dbCMD, "UserID", DbType.Int32, CV.UserID());
                sqlDB.AddInParameter(dbCMD, "IPDID", SqlDbType.Int, modelIPD.IPDID);
                sqlDB.AddInParameter(dbCMD, "PatientID", SqlDbType.Int, modelIPD.PatientID);
                sqlDB.AddInParameter(dbCMD, "DoctorID", SqlDbType.Int, modelIPD.DoctorID);
                sqlDB.AddInParameter(dbCMD, "RoomID", SqlDbType.Int, modelIPD.RoomID);
                sqlDB.AddInParameter(dbCMD, "BuildingID", SqlDbType.Int, modelIPD.BuildingID);
                sqlDB.AddInParameter(dbCMD, "Problem", SqlDbType.NVarChar, modelIPD.Problem);
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.DateTime, DBNull.Value);

                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);

                }
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion


    }
}
