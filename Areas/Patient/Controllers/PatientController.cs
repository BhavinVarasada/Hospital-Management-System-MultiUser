using Hospital_Management_System.Areas.BloodGroup.Models;
using Hospital_Management_System.Areas.Doctor.Models;
using Hospital_Management_System.Areas.Patient.Models;
using Hospital_Management_System.BAL;
using Hospital_Management_System.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Hospital_Management_System.Areas.Patient.Controllers
{
    [CheckAccess]
    [Area("Patient")]
    [Route("Patient/[controller]/[action]")]
    public class PatientController : Controller
    {
        string MyConnectionString = DALHelper.MyConnectionString;

        public IActionResult Back()
        {
            return RedirectToAction("Index");
        }

        #region SelectAll
        public IActionResult Index()
        {
            Patient_DAL dalPatient = new Patient_DAL();
            DataTable dtPatient = dalPatient.PR_Patient_SelectAll();
            return View("PatientList", dtPatient);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int PatientID)
        {
            Patient_DAL dalPatient = new Patient_DAL();
            DataTable dtPatient = dalPatient.PR_Patient_DeleteByPK(PatientID);
            return RedirectToAction("Index");
        }
        #endregion

        #region Insert

        [HttpPost]
        public IActionResult Save(PatientModel modelPatient)
        {
            Patient_DAL dalPatient = new Patient_DAL();

            if (modelPatient.PatientID == null)
            {
                DataTable PatientInsertdt = dalPatient.PR_Patient_Insert(modelPatient);
            }
            else
            {
                DataTable PatientUpdatedt = dalPatient.PR_Patient_UpdateByPK(modelPatient);
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region Add
        public IActionResult Add(int? PatientID)
        {
            #region BloodGroup Dropdown

            DataTable dtBloodGroupSelect = new DataTable();
            SqlConnection conn1 = new SqlConnection(MyConnectionString);
            conn1.Open();

            SqlCommand cmdBloodGroupDropDown = conn1.CreateCommand();
            cmdBloodGroupDropDown.CommandType = CommandType.StoredProcedure;
            cmdBloodGroupDropDown.CommandText = "PR_BloodGroup_SelectForDropDown";
            SqlDataReader sdrBloodgroupDropDown = cmdBloodGroupDropDown.ExecuteReader();
            dtBloodGroupSelect.Load(sdrBloodgroupDropDown);
            conn1.Close();

            List<BloodGroup_DropDownModel> BloodGroupDropDownlist = new List<BloodGroup_DropDownModel>();
            foreach (DataRow dr in dtBloodGroupSelect.Rows)
            {
                BloodGroup_DropDownModel vlstBloodGroup = new BloodGroup_DropDownModel();
                vlstBloodGroup.BloodGroupID = Convert.ToInt32(dr["BloodGroupID"]);
                vlstBloodGroup.BloodGroupName = dr["BloodGroupName"].ToString();
                BloodGroupDropDownlist.Add(vlstBloodGroup);
            }
            ViewBag.BloodGroupList = BloodGroupDropDownlist;

            #endregion

            if (PatientID != null)
            {
                Patient_DAL dalPatient = new Patient_DAL();
                DataTable PatientSelectdt = dalPatient.PR_Patient_SelectByPK((int)PatientID);

                PatientModel modelPatient = new PatientModel();
                foreach (DataRow dr in PatientSelectdt.Rows)
                {
                    modelPatient.PatientName = dr["PatientName"].ToString();
                    modelPatient.DateOfBirth = (DateTime)dr["DateOfBirth"];
                    modelPatient.Gender = dr["Gender"].ToString();
                    modelPatient.BloodGroupID = Convert.ToInt32(dr["BloodGroupID"]);
                    modelPatient.MobileNumber = dr["MobileNumber"].ToString();
                    modelPatient.Address = dr["Address"].ToString();
                    modelPatient.CreationDate = (DateTime)dr["CreationDate"];
                    modelPatient.ModificationDate = (DateTime)dr["ModificationDate"];
                }
                return View("PatientAddEdit", modelPatient);
            }
            return View("PatientAddEdit");
        }

        #endregion
    }
}
