using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Hospital_Management_System.Areas.Appointment.Models;
using Hospital_Management_System.BAL;

namespace Hospital_Management_System.DAL
{
    public class Appointment_DALBase : DALHelper
    {
        #region PR_Appointment_SelectAll
        public DataTable PR_Appointment_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Appointment_SelectAll");
                sqlDB.AddInParameter(dbCMD, "UserID", DbType.Int32, CV.UserID());

                DataTable dtAppointment = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dtAppointment.Load(dr);
                }
                return dtAppointment;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region PR_Appointment_DeleteByPK
        public DataTable PR_Appointment_DeleteByPK(int AppointmentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Appointment_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "AppointmentID", SqlDbType.Int, AppointmentID);
                sqlDB.AddInParameter(dbCMD, "UserID", DbType.Int32, CV.UserID());

                DataTable dtAppointment = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dtAppointment.Load(dr);
                }
                return dtAppointment;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region PR_Appointment_Insert
        public DataTable PR_Appointment_Insert(AppointmentModel modelAppointment)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Appointment_Insert");

                sqlDB.AddInParameter(dbCMD, "UserID", DbType.Int32, CV.UserID());
                sqlDB.AddInParameter(dbCMD, "PatientID", SqlDbType.Int, modelAppointment.PatientID);
                sqlDB.AddInParameter(dbCMD, "AppointmentDate", SqlDbType.DateTime, modelAppointment.AppointmentDate);
                sqlDB.AddInParameter(dbCMD, "AppointmentTime", SqlDbType.DateTime, modelAppointment.AppointmentTime);
                sqlDB.AddInParameter(dbCMD, "DoctorID", SqlDbType.Int, modelAppointment.DoctorID);
                sqlDB.AddInParameter(dbCMD, "Problem", SqlDbType.NVarChar, modelAppointment.Problem);
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

        #region PR_Appointment_SelectByPK
        public DataTable PR_Appointment_SelectByPK(int AppointmentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Appointment_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "AppointmentID", SqlDbType.Int, AppointmentID);
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

        #region PR_Appointment_UpdateByPK
        public DataTable PR_Appointment_UpdateByPK(AppointmentModel modelAppointment)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Appointment_UpdateByPK");

                sqlDB.AddInParameter(dbCMD, "UserID", DbType.Int32, CV.UserID());
                sqlDB.AddInParameter(dbCMD, "AppointmentID", SqlDbType.Int, modelAppointment.AppointmentID);
                sqlDB.AddInParameter(dbCMD, "PatientID", SqlDbType.Int, modelAppointment.PatientID);
                sqlDB.AddInParameter(dbCMD, "AppointmentDate", SqlDbType.DateTime, modelAppointment.AppointmentDate);
                sqlDB.AddInParameter(dbCMD, "AppointmentTime", SqlDbType.DateTime, modelAppointment.AppointmentTime);
                sqlDB.AddInParameter(dbCMD, "DoctorID", SqlDbType.Int, modelAppointment.DoctorID);
                sqlDB.AddInParameter(dbCMD, "Problem", SqlDbType.NVarChar, modelAppointment.Problem);
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
