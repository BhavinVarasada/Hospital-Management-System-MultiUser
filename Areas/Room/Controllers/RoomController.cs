using Hospital_Management_System.Areas.Department.Models;
using Hospital_Management_System.Areas.Building.Models;
using Hospital_Management_System.Areas.Room.Models;
using Hospital_Management_System.Areas.Room.Models;
using Hospital_Management_System.Areas.RoomType.Models;
using Hospital_Management_System.Areas.Speciality.Models;
using Hospital_Management_System.BAL;
using Hospital_Management_System.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Hospital_Management_System.Areas.Room.Controllers
{
    [CheckAccess]
    [Area("Room")]
    [Route("Room/[controller]/[action]")]
    public class RoomController : Controller
    {
        string MyConnectionString = DALHelper.MyConnectionString;

        public IActionResult Back()
        {
            return RedirectToAction("Index");
        }
        #region SelectAll
        public IActionResult Index()
        {
            Room_DAL dalRoom = new Room_DAL();
            DataTable dtRoom = dalRoom.PR_Room_SelectAll();
            return View("RoomList", dtRoom);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int RoomID)
        {
            Room_DAL dalRoom = new Room_DAL();
            DataTable dtRoom = dalRoom.PR_Room_DeleteByPK(RoomID);
            return RedirectToAction("Index");
        }
        #endregion

        #region Insert

        [HttpPost]
        public IActionResult Save(RoomModel modelRoom)
        {
            Room_DAL dalRoom = new Room_DAL();

            if (modelRoom.RoomID == null)
            {
                DataTable RoomInsertdt = dalRoom.PR_Room_Insert(modelRoom);
            }
            else
            {
                DataTable RoomUpdatedt = dalRoom.PR_Room_UpdateByPK(modelRoom);
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Add
        public IActionResult Add(int? RoomID)
        {
            #region RoomType Dropdown

            DataTable dtRoomTypeSelect = new DataTable();
            SqlConnection conn1 = new SqlConnection(MyConnectionString);
            conn1.Open();

            SqlCommand cmdRoomTypeDropDown = conn1.CreateCommand();
            cmdRoomTypeDropDown.CommandType = CommandType.StoredProcedure;
            cmdRoomTypeDropDown.CommandText = "PR_RoomType_SelectForDropDown";
            SqlDataReader sdrRoomTypeDropDown = cmdRoomTypeDropDown.ExecuteReader();
            dtRoomTypeSelect.Load(sdrRoomTypeDropDown);
            conn1.Close();

            List<RoomType_DropDownModel> RoomTypeDropDownlist = new List<RoomType_DropDownModel>();
            foreach (DataRow dr in dtRoomTypeSelect.Rows)
            {
                RoomType_DropDownModel vlstRoomType = new RoomType_DropDownModel();
                vlstRoomType.RoomTypeID = Convert.ToInt32(dr["RoomTypeID"]);
                vlstRoomType.RoomTypeName = dr["RoomTypeName"].ToString();
                RoomTypeDropDownlist.Add(vlstRoomType);
            }
            ViewBag.RoomTypeList = RoomTypeDropDownlist;

            #endregion

            #region Building Dropdown

            DataTable dtBuildingSelect = new DataTable();
            SqlConnection conn2 = new SqlConnection(MyConnectionString);
            conn2.Open();

            SqlCommand cmdBuildingDropDown = conn2.CreateCommand();
            cmdBuildingDropDown.CommandType = CommandType.StoredProcedure;
            cmdBuildingDropDown.CommandText = "PR_Building_SelectForDropDown";
            SqlDataReader sdrBuildingDropDown = cmdBuildingDropDown.ExecuteReader();
            dtBuildingSelect.Load(sdrBuildingDropDown);
            conn2.Close();

            List<Building_DropDownModel> BuildingDropDownlist = new List<Building_DropDownModel>();
            foreach (DataRow dr in dtBuildingSelect.Rows)
            {
                Building_DropDownModel vlstBuilding = new Building_DropDownModel();
                vlstBuilding.BuildingID = Convert.ToInt32(dr["BuildingID"]);
                vlstBuilding.BuildingNumber = dr["BuildingNumber"].ToString();
                BuildingDropDownlist.Add(vlstBuilding);
            }
            ViewBag.BuildingList = BuildingDropDownlist;

            #endregion

            if (RoomID != null)
            {
                Room_DAL dalRoom = new Room_DAL();
                DataTable RoomSelectdt = dalRoom.PR_Room_SelectByPK((int)RoomID);

                RoomModel modelRoom = new RoomModel();
                foreach (DataRow dr in RoomSelectdt.Rows)
                {
                    modelRoom.RoomTypeID = Convert.ToInt32(dr["RoomTypeID"]);
                    modelRoom.RoomRate = Convert.ToDecimal(dr["RoomRate"]);
                    modelRoom.RoomNumber = dr["RoomNumber"].ToString();
                    modelRoom.BuildingID = Convert.ToInt32(dr["BuildingID"]);                  
                    modelRoom.BedNumber = dr["BedNumber"].ToString();                                  
                    modelRoom.IsAvailable = (bool)dr["IsAvailable"];
                    modelRoom.CreationDate = (DateTime)dr["CreationDate"];
                    modelRoom.ModificationDate = (DateTime)dr["ModificationDate"];
                }
                return View("RoomAddEdit", modelRoom);
            }
            return View("RoomAddEdit");
        }
        #endregion
    }
}
