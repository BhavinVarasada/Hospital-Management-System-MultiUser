using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Hospital_Management_System.Areas.Doctor.Models;
using Hospital_Management_System.BAL;

namespace Hospital_Management_System.DAL
{
    public class Doctor_DALBase : DALHelper
    {
        #region PR_Doctor_SelectAll
        public DataTable PR_Doctor_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Doctor_SelectAll");
                sqlDB.AddInParameter(dbCMD, "UserID", DbType.Int32, CV.UserID());

                DataTable dtDoctor = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dtDoctor.Load(dr);
                }
                return dtDoctor;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region PR_Doctor_DeleteByPK
        public DataTable PR_Doctor_DeleteByPK(int DoctorID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Doctor_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "DoctorID", SqlDbType.Int, DoctorID);
                sqlDB.AddInParameter(dbCMD, "UserID", DbType.Int32, CV.UserID());

                DataTable dtDoctor = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dtDoctor.Load(dr);
                }
                return dtDoctor;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region PR_Doctor_Insert
        public DataTable PR_Doctor_Insert(DoctorModel modelDoctor)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Doctor_Insert");

                sqlDB.AddInParameter(dbCMD, "UserID", DbType.Int32, CV.UserID());
                sqlDB.AddInParameter(dbCMD, "DoctorName", SqlDbType.NVarChar, modelDoctor.DoctorName);
                sqlDB.AddInParameter(dbCMD, "DepartmentID", SqlDbType.Int, modelDoctor.DepartmentID);
                sqlDB.AddInParameter(dbCMD, "DesignationID", SqlDbType.Int, modelDoctor.DesignationID);
                sqlDB.AddInParameter(dbCMD, "MobileNumber", SqlDbType.NVarChar, modelDoctor.MobileNumber);
                sqlDB.AddInParameter(dbCMD, "Gender", SqlDbType.NVarChar, modelDoctor.Gender);
                sqlDB.AddInParameter(dbCMD, "SpecialityID", SqlDbType.Int, modelDoctor.SpecialityID);
                sqlDB.AddInParameter(dbCMD, "Education", SqlDbType.NVarChar, modelDoctor.Education);
                if (modelDoctor.IsAvailable == true)
                {
                    modelDoctor.IsAvailable = true;
                }
                else
                {
                    modelDoctor.IsAvailable = false;
                }

                sqlDB.AddInParameter(dbCMD, "IsAvailable", SqlDbType.Bit, modelDoctor.IsAvailable);
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

        #region PR_Doctor_SelectByPK
        public DataTable PR_Doctor_SelectByPK(int DoctorID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Doctor_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "DoctorID", SqlDbType.Int, DoctorID);
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

        #region PR_Doctor_UpdateByPK
        public DataTable PR_Doctor_UpdateByPK(DoctorModel modelDoctor)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Doctor_UpdateByPK");

                sqlDB.AddInParameter(dbCMD, "UserID", DbType.Int32, CV.UserID());
                sqlDB.AddInParameter(dbCMD, "DoctorID", SqlDbType.Int, modelDoctor.DoctorID);
                sqlDB.AddInParameter(dbCMD, "DoctorName", SqlDbType.NVarChar, modelDoctor.DoctorName);
                sqlDB.AddInParameter(dbCMD, "DepartmentID", SqlDbType.Int, modelDoctor.DepartmentID);
                sqlDB.AddInParameter(dbCMD, "DesignationID", SqlDbType.Int, modelDoctor.DesignationID);
                sqlDB.AddInParameter(dbCMD, "MobileNumber", SqlDbType.NVarChar, modelDoctor.MobileNumber);
                sqlDB.AddInParameter(dbCMD, "Gender", SqlDbType.NVarChar, modelDoctor.Gender);
                sqlDB.AddInParameter(dbCMD, "SpecialityID", SqlDbType.Int, modelDoctor.SpecialityID);
                sqlDB.AddInParameter(dbCMD, "Education", SqlDbType.NVarChar, modelDoctor.Education);
                sqlDB.AddInParameter(dbCMD, "IsAvailable", SqlDbType.Bit, modelDoctor.IsAvailable);
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
