using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Hospital_Management_System.BAL;
using Hospital_Management_System.Areas.Doctor.Models;
using Hospital_Management_System.Areas.Patient.Models;

namespace Hospital_Management_System.DAL
{
    public class Patient_DALBase : DALHelper
    {
        #region PR_Patient_SelectAll
        public DataTable PR_Patient_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Patient_SelectAll");
                sqlDB.AddInParameter(dbCMD, "UserID", DbType.Int32, CV.UserID());

                DataTable dtPatient = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dtPatient.Load(dr);
                }
                return dtPatient;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region PR_Patient_DeleteByPK
        public DataTable PR_Patient_DeleteByPK(int PatientID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Patient_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "PatientID", SqlDbType.Int, PatientID);
                sqlDB.AddInParameter(dbCMD, "UserID", DbType.Int32, CV.UserID());

                DataTable dtPatient = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dtPatient.Load(dr);
                }
                return dtPatient;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region PR_Patient_Insert
        public DataTable PR_Patient_Insert(PatientModel modelPatient)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Patient_Insert");

                sqlDB.AddInParameter(dbCMD, "UserID", DbType.Int32, CV.UserID());
                sqlDB.AddInParameter(dbCMD, "PatientName", SqlDbType.NVarChar, modelPatient.PatientName);
                sqlDB.AddInParameter(dbCMD, "DateOfBirth", SqlDbType.DateTime, modelPatient.DateOfBirth);
                sqlDB.AddInParameter(dbCMD, "Gender", SqlDbType.NVarChar, modelPatient.Gender);
                sqlDB.AddInParameter(dbCMD, "MobileNumber", SqlDbType.NVarChar, modelPatient.MobileNumber);
                sqlDB.AddInParameter(dbCMD, "BloodGroupID", SqlDbType.Int, modelPatient.BloodGroupID);
                sqlDB.AddInParameter(dbCMD, "Address", SqlDbType.NVarChar, modelPatient.Address);               
                sqlDB.AddInParameter(dbCMD, "CreationDate", SqlDbType.DateTime, DBNull.Value);
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

        #region PR_Patient_SelectByPK
        public DataTable PR_Patient_SelectByPK(int PatientID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Patient_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "PatientID", SqlDbType.Int, PatientID);
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

        #region PR_Patient_UpdateByPK
        public DataTable PR_Patient_UpdateByPK(PatientModel modelPatient)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Patient_UpdateByPK");

                sqlDB.AddInParameter(dbCMD, "UserID", DbType.Int32, CV.UserID());
                sqlDB.AddInParameter(dbCMD, "PatientID", SqlDbType.Int, modelPatient.PatientID);
                sqlDB.AddInParameter(dbCMD, "PatientName", SqlDbType.NVarChar, modelPatient.PatientName);
                sqlDB.AddInParameter(dbCMD, "DateOfBirth", SqlDbType.DateTime, modelPatient.DateOfBirth);
                sqlDB.AddInParameter(dbCMD, "Gender", SqlDbType.NVarChar, modelPatient.Gender);
                sqlDB.AddInParameter(dbCMD, "MobileNumber", SqlDbType.NVarChar, modelPatient.MobileNumber);
                sqlDB.AddInParameter(dbCMD, "BloodGroupID", SqlDbType.Int, modelPatient.BloodGroupID);
                sqlDB.AddInParameter(dbCMD, "Address", SqlDbType.NVarChar, modelPatient.Address);  
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
