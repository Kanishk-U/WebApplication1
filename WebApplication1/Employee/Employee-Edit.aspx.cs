using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using EmployeeCommon.Employee;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;

namespace EmployeeForm.Employee
{

    public partial class Employee_Edit : System.Web.UI.Page
    {
        #region object of list intialization
        private List<clsEmployee> emps = new List<clsEmployee>();
        public string filename = null;
        public string contentType = null;
        public int? filesize;
        public byte[] bytes;
        #endregion
        //########################################################################


        #region onLoad checks
        /// <summary>
        /// Page Load event method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DrowndownReport();
                //No future date
                txtdob.Attributes["max"] = DateTime.Now.ToString("yyyy-MM-dd");

                //Edit employee id
                UpdateEmployeeDetails();

            }


        }

        #region Updating employee
        /// <summary>
        /// On updating employee details
        /// </summary>
        private void UpdateEmployeeDetails()
        {
            int Employeeid;
            if (Int32.TryParse(Request.QueryString["ID"], out Employeeid))
            {
                btnsave.Text = "UPDATE";
                hdnID.Value = Employeeid.ToString().Trim();
                clsEmployee emp = clsEmployee.GetEmployeeDetails(Convert.ToInt32(hdnID.Value)); //Only returns employee with that ID


                ListviewControl.EmployeeId = Employeeid;
                //FileUpload.Visible = false;
                lnkDownload.Visible = true;

                lblFileUpload.Text = "<b>Update Attachment:</b>";

                

                txtFirstName.Text = emp.FirstName;
                txtMiddleName.Text = emp.MiddleName;
                txtLastName.Text = emp.LastName;
                txtFather.Text = emp.Father;
                txtEmail.Text = emp.Email;
                txtdob.Text = (string)emp.DOB;
                ddlRegion.SelectedValue = emp.Region;
                txtAddress.Text = emp.Address;
                txtAddress1.Text = emp.Address2;
                txtCity.Text = emp.City;
                txtState.Text = emp.State;
                txtZIP.Text = emp.ZIP;
                txtCell.Text = emp.Contact;
                txtGender.Text = emp.Gender;
                txtProgram.Text = emp.Program;
                ddlReporting.SelectedValue = emp.Reporting.ToString();
                lnkDownload.Text = emp.FileName;


            }
        }
        #endregion 


        #endregion
        //########################################################################




        #region Button Save and Update Details
        /// <summary>
        /// Onclicking Save button saves details to list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnsave_Click(object sender, EventArgs e)
        {
            Page.Validate("valEmployee");
            int ReportingID;
            Int32.TryParse(ddlReporting.SelectedValue, out ReportingID);

            if (Page.IsValid)
            {
                //Initialize file properties
                FileProperties();


                //Editing employee

                if (btnsave.Text == "UPDATE")
                {
                    clsEmployee emp = clsEmployee.GetEmployeeDetails(Convert.ToInt32(hdnID.Value)); //Only returns employee with that ID
                                                                                                   


                    emp.FirstName = txtFirstName.Text.Trim();
                    emp.MiddleName = txtMiddleName.Text.Trim();
                    emp.LastName = txtLastName.Text.Trim();
                    emp.Father = txtFather.Text.Trim();
                    emp.Email = txtEmail.Text.Trim();
                    emp.DOB = txtdob.Text.Trim();
                    emp.Region = ddlRegion.SelectedValue;
                    emp.Address = txtAddress.Text.Trim();
                    emp.Address2 = txtAddress1.Text.Trim();
                    emp.City = txtCity.Text.Trim();
                    emp.State = txtState.Text.Trim();
                    emp.ZIP = txtZIP.Text.Trim();
                    emp.Contact = txtCell.Text.Trim();
                    emp.Gender = txtGender.Text.Trim();
                    emp.Program = txtProgram.Text.Trim();
                    emp.Reporting = ReportingID;
                    if (FileUpload.HasFile)
                    {
                        filename = Path.GetFileName(FileUpload.PostedFile.FileName);
                        contentType = FileUpload.PostedFile.ContentType;
                        filesize = FileUpload.PostedFile.ContentLength;
                        using (Stream fs = FileUpload.PostedFile.InputStream)
                        {
                            using (BinaryReader br = new BinaryReader(fs))
                            {
                                bytes = br.ReadBytes((Int32)fs.Length);
                            }
                        }
                        emp.FileName = filename;
                        emp.FileMimeType = contentType;
                        emp.FileSize = filesize;
                        emp.FileData = bytes;
                    }
                    emp.UpdateEmployee(emp, "Update");
                    Response.Redirect("Default.aspx?msg=" + "UPDATE");
                    
                }
                else
                {

                    //Adding Employee
                    clsEmployee Employee = new clsEmployee
                    {

                        FirstName = txtFirstName.Text.Trim(),
                        LastName = txtLastName.Text.Trim(),
                        MiddleName = txtMiddleName.Text.Trim(),
                        Father = txtFather.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        DOB = txtdob.Text.Trim(),
                        Region = ddlRegion.SelectedValue,
                        Address = txtAddress.Text.Trim(),
                        Address2 = txtAddress1.Text.Trim(),
                        City = txtCity.Text.Trim(),
                        State = txtState.Text.Trim(),
                        ZIP = txtZIP.Text.Trim(),
                        Contact = txtCell.Text.Trim(),
                        Gender = txtGender.Text.Trim(),
                        Program = txtProgram.Text.Trim(),
                        Reporting = ReportingID,  
                        FileName = filename,
                        FileMimeType = contentType,
                        FileSize = filesize,
                        FileData = bytes
                    };
                    Employee.UpdateEmployee(Employee, "Insert");
                    Response.Redirect("Default.aspx?msg=" + "ADD");
                }

            }

        }


        /// <summary>
        /// Gets file data 
        /// </summary>
        private void FileProperties()
        {
            if (FileUpload.HasFile)
            {
                filename = Path.GetFileName(FileUpload.PostedFile.FileName);
                contentType = FileUpload.PostedFile.ContentType;
                filesize = FileUpload.PostedFile.ContentLength;
                using (Stream fs = FileUpload.PostedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        bytes = br.ReadBytes((Int32)fs.Length);
                    }
                }
            }
        }
        #endregion
        //########################################################################



        #region Download file
        /// <summary>
        /// Redirect to Handler page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DownloadFile(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveUrl("DownloadFile.ashx?EmpId=" + hdnID.Value));
        }
        #endregion
        //########################################################################



        #region Email Validation
        /// <summary>
        /// Email validation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cusCustom_ServerValidate(object sender, ServerValidateEventArgs e)
        {

            ///Collecting previously added details in Session list
            emps = clsEmployee.Fetch();
            int EmployeeId;
            Int32.TryParse(hdnID.Value.Trim(), out EmployeeId);


            foreach (clsEmployee emp in emps)
            {
                if (emp.Email.ToLower() == txtEmail.Text.Trim().ToLower() && string.IsNullOrWhiteSpace(hdnID.Value.Trim()))
                {
                    e.IsValid = false;
                    txtEmail.Focus();
                    cvEmail.ErrorMessage = "Email already exists";
                    break;
                }
                else if (emp.Email.ToLower() == txtEmail.Text.Trim().ToLower() && emp.Id != EmployeeId && string.IsNullOrWhiteSpace(hdnID.Value.Trim()))
                {
                    e.IsValid = false;
                    txtEmail.Focus();
                    cvEmail.ErrorMessage = "Email already exists";
                    break;
                }


            }
        }
        #endregion
        //########################################################################




        #region cancel button
        /// <summary>
        /// Cancel button redirects back to List of employees 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveUrl("Default.aspx"));
        }
        #endregion
        //########################################################################




        #region List initialization
        /// <summary>
        /// Method for binding list of objects
        /// </summary>
        /// <param name="EmpDetails"></param>
        //private List<clsEmployee> GetEmployees()
        //{
        //    List<clsEmployee> EmpDetails = new List<clsEmployee>();
        //    EmpDetails = clsEmployee.GetClsEmployees();
        //    return EmpDetails;
        //}
        #endregion
        //########################################################################



        #region Dropdown for Reporting employee
        ///
        /// For Dynamic report dropdown
        ///
        private void DrowndownReport()
        {
            int EmployeeId;
            if (Int32.TryParse(Request.QueryString["ID"], out EmployeeId))
            {
                emps = clsEmployee.GetReportingDropdown(EmployeeId);

            }
            else
            {
                ListviewControl.Visible = false;
                emps = clsEmployee.GetReportingDropdown(null);
            }

            foreach (clsEmployee emp in emps)
            {

                ddlReporting.Items.Add(new ListItem(emp.FirstName, emp.Id.ToString()));
            }


            ddlReporting.Items.Insert(0, new ListItem("--Report To--", ""));
            ddlReporting.SelectedIndex = 0;


        }
        #endregion
        //########################################################################
    }
}