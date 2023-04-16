using Hospital_Management_System.Areas.Department.Models;
using Hospital_Management_System.Areas.Designation.Models;
using Hospital_Management_System.Areas.Doctor.Models;
using Hospital_Management_System.Areas.Speciality.Models;
using Hospital_Management_System.BAL;
using Hospital_Management_System.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Hospital_Management_System.Areas.Doctor.Controllers
{
    [CheckAccess]
    [Area("Doctor")]
    [Route("Doctor/[controller]/[action]")]
    public class DoctorController : Controller
    {
        string MyConnectionString = DALHelper.MyConnectionString;

        public IActionResult Back()
        {
            return RedirectToAction("Index");
        }

        #region SelectAll
        public IActionResult Index()
        {
            Doctor_DAL dalDoctor = new Doctor_DAL();
            DataTable dtDoctor = dalDoctor.PR_Doctor_SelectAll();
            return View("DoctorList", dtDoctor);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int DoctorID)
        {
            Doctor_DAL dalDoctor = new Doctor_DAL();
            DataTable dtDoctor = dalDoctor.PR_Doctor_DeleteByPK(DoctorID);
            return RedirectToAction("Index");
        }
        #endregion

        #region Insert

        [HttpPost]
        public IActionResult Save(DoctorModel modelDoctor)
        {
            Doctor_DAL dalDoctor = new Doctor_DAL();

            if (modelDoctor.DoctorID == null)
            {
                DataTable DoctorInsertdt = dalDoctor.PR_Doctor_Insert(modelDoctor);
            }
            else
            {
                DataTable DoctorUpdatedt = dalDoctor.PR_Doctor_UpdateByPK(modelDoctor);
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region Add
        public IActionResult Add(int? DoctorID)
        {
            #region Department Dropdown

            DataTable dtDepartmentSelect = new DataTable();
            SqlConnection conn1 = new SqlConnection(MyConnectionString);
            conn1.Open();

            SqlCommand cmdDepartmentDropDown = conn1.CreateCommand();
            cmdDepartmentDropDown.CommandType = CommandType.StoredProcedure;
            cmdDepartmentDropDown.CommandText = "PR_Department_SelectForDropDown";
            SqlDataReader sdrDepartmentDropDown = cmdDepartmentDropDown.ExecuteReader();
            dtDepartmentSelect.Load(sdrDepartmentDropDown);
            conn1.Close();

            List<Department_DropDownModel> DepartmentDropDownlist = new List<Department_DropDownModel>();
            foreach (DataRow dr in dtDepartmentSelect.Rows)
            {
                Department_DropDownModel vlstDepartment = new Department_DropDownModel();
                vlstDepartment.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);
                vlstDepartment.DepartmentName = dr["DepartmentName"].ToString();
                DepartmentDropDownlist.Add(vlstDepartment);
            }
            ViewBag.DepartmentList = DepartmentDropDownlist;

            #endregion

            #region Designation Dropdown

            DataTable dtDesignationSelect = new DataTable();
            SqlConnection conn2 = new SqlConnection(MyConnectionString);
            conn2.Open();

            SqlCommand cmdDesignationDropDown = conn2.CreateCommand();
            cmdDesignationDropDown.CommandType = CommandType.StoredProcedure;
            cmdDesignationDropDown.CommandText = "PR_Designation_SelectForDropDown";
            SqlDataReader sdrDesignationDropDown = cmdDesignationDropDown.ExecuteReader();
            dtDesignationSelect.Load(sdrDesignationDropDown);
            conn2.Close();

            List<Designation_DropDownModel> DesignationDropDownlist = new List<Designation_DropDownModel>();
            foreach (DataRow dr in dtDesignationSelect.Rows)
            {
                Designation_DropDownModel vlstDesignation = new Designation_DropDownModel();
                vlstDesignation.DesignationID = Convert.ToInt32(dr["DesignationID"]);
                vlstDesignation.DesignationName = dr["DesignationName"].ToString();
                DesignationDropDownlist.Add(vlstDesignation);
            }
            ViewBag.DesignationList = DesignationDropDownlist;

            #endregion

            #region Speciality Dropdown

            DataTable dtSpecialitySelect = new DataTable();
            SqlConnection conn3 = new SqlConnection(MyConnectionString);
            conn3.Open();

            SqlCommand cmdSpecialityDropDown = conn3.CreateCommand();
            cmdSpecialityDropDown.CommandType = CommandType.StoredProcedure;
            cmdSpecialityDropDown.CommandText = "PR_Speciality_SelectForDropDown";
            SqlDataReader sdrSpecialityDropDown = cmdSpecialityDropDown.ExecuteReader();
            dtSpecialitySelect.Load(sdrSpecialityDropDown);
            conn3.Close();

            List<Speciality_DropDownModel> SpecialityDropDownlist = new List<Speciality_DropDownModel>();
            foreach (DataRow dr in dtSpecialitySelect.Rows)
            {
                Speciality_DropDownModel vlstSpeciality = new Speciality_DropDownModel();
                vlstSpeciality.SpecialityID = Convert.ToInt32(dr["SpecialityID"]);
                vlstSpeciality.SpecialityName = dr["SpecialityName"].ToString();
                SpecialityDropDownlist.Add(vlstSpeciality);
            }
            ViewBag.SpecialityList = SpecialityDropDownlist;

            #endregion


            if (DoctorID != null)
            {
                Doctor_DAL dalDoctor = new Doctor_DAL();
                DataTable DoctorSelectdt = dalDoctor.PR_Doctor_SelectByPK((int)DoctorID);

                DoctorModel modelDoctor = new DoctorModel();
                foreach (DataRow dr in DoctorSelectdt.Rows)
                {
                    modelDoctor.DoctorName = dr["DoctorName"].ToString();
                    modelDoctor.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);
                    modelDoctor.DesignationID = Convert.ToInt32(dr["DesignationID"]);
                    modelDoctor.MobileNumber = dr["MobileNumber"].ToString();
                    modelDoctor.Gender = dr["Gender"].ToString();
                    modelDoctor.SpecialityID = Convert.ToInt32(dr["SpecialityID"]);
                    modelDoctor.Education = dr["Education"].ToString();
                    modelDoctor.IsAvailable = (bool)dr["IsAvailable"];
                    modelDoctor.CreationDate = (DateTime)dr["CreationDate"];
                    modelDoctor.ModificationDate = (DateTime)dr["ModificationDate"];
                }
                return View("DoctorAddEdit", modelDoctor);
            }
            return View("DoctorAddEdit");
        }

        #endregion

    }
}
