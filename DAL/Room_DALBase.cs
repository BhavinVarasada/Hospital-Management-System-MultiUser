using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Hospital_Management_System.BAL;
using Hospital_Management_System.Areas.Room.Models;
using Hospital_Management_System.Areas.Room.Models;

namespace Hospital_Management_System.DAL
{
    public class Room_DALBase : DALHelper
    {
        #region PR_Room_SelectAll
        public DataTable PR_Room_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Room_SelectAll");
                sqlDB.AddInParameter(dbCMD, "UserID", DbType.Int32, CV.UserID());

                DataTable dtRoom = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dtRoom.Load(dr);
                }
                return dtRoom;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region PR_Room_DeleteByPK
        public DataTable PR_Room_DeleteByPK(int RoomID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Room_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "RoomID", SqlDbType.Int, RoomID);
                sqlDB.AddInParameter(dbCMD, "UserID", DbType.Int32, CV.UserID());

                DataTable dtRoom = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dtRoom.Load(dr);
                }
                return dtRoom;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region PR_Room_Insert
        public DataTable PR_Room_Insert(RoomModel modelRoom)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Room_Insert");

                sqlDB.AddInParameter(dbCMD, "UserID", DbType.Int32, CV.UserID());
                sqlDB.AddInParameter(dbCMD, "RoomTypeID", SqlDbType.Int, modelRoom.RoomTypeID);
                sqlDB.AddInParameter(dbCMD, "RoomRate", SqlDbType.Decimal, modelRoom.RoomRate);
                sqlDB.AddInParameter(dbCMD, "RoomNumber", SqlDbType.NVarChar, modelRoom.RoomNumber);
                sqlDB.AddInParameter(dbCMD, "BuildingID", SqlDbType.Int, modelRoom.BuildingID);
                sqlDB.AddInParameter(dbCMD, "BedNumber", SqlDbType.NVarChar, modelRoom.BedNumber);
                if (modelRoom.IsAvailable == true)
                {
                    modelRoom.IsAvailable = true;
                }
                else
                {
                    modelRoom.IsAvailable = false;
                }
                sqlDB.AddInParameter(dbCMD, "IsAvailable", SqlDbType.Bit, modelRoom.IsAvailable);
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

        #region PR_Room_SelectByPK
        public DataTable PR_Room_SelectByPK(int RoomID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Room_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "RoomID", SqlDbType.Int, RoomID);
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

        #region PR_Room_UpdateByPK
        public DataTable PR_Room_UpdateByPK(RoomModel modelRoom)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(MyConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Room_UpdateByPK");

                sqlDB.AddInParameter(dbCMD, "UserID", DbType.Int32, CV.UserID());
                sqlDB.AddInParameter(dbCMD, "RoomID", SqlDbType.Int, modelRoom.RoomID);
                sqlDB.AddInParameter(dbCMD, "RoomTypeID", SqlDbType.Int, modelRoom.RoomTypeID);
                sqlDB.AddInParameter(dbCMD, "RoomRate", SqlDbType.Decimal, modelRoom.RoomRate);
                sqlDB.AddInParameter(dbCMD, "RoomNumber", SqlDbType.NVarChar, modelRoom.RoomNumber);
                sqlDB.AddInParameter(dbCMD, "BuildingID", SqlDbType.Int, modelRoom.BuildingID);
                sqlDB.AddInParameter(dbCMD, "BedNumber", SqlDbType.NVarChar, modelRoom.BedNumber);
                sqlDB.AddInParameter(dbCMD, "IsAvailable", SqlDbType.Bit, modelRoom.IsAvailable);
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
