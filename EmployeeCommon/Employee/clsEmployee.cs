using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeCommon.Employee;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace EmployeeCommon.Employee
{
    public partial class clsEmployee
    {

        #region Properties declaration
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of employee
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Middle Name of Employee
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Last Name of Employee
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// father name of employee
        /// </summary>
        public string Father { get; set; }

        /// <summary>
        /// Region of employee
        /// </summary>
        public string Region { get; set; }


        /// <summary>
        /// Email of employee
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Date of birth of employee
        /// </summary>
        public string DOB { get; set; }

        /// <summary>
        /// Address of employee
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Address Line 2
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// State
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// State
        /// </summary>
        public string ZIP { get; set; }

        /// <summary>
        /// Phone number of employee
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// Gender of employee
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Department of employee
        /// </summary>
        public string Program { get; set; }


        /// <summary>
        /// Reporting to
        /// </summary>
        public int Reporting { get; set; }

        /// <summary>
        /// File Name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// File type
        /// </summary>
        public string FileMimeType { get; set; }

        /// <summary>
        /// File size
        /// </summary>
        public int? FileSize { get; set; }

        /// <summary>
        /// FileData
        /// </summary>
        public byte[] FileData { get; set; }


        public clsEmployee()
        {

        }
        #endregion
        //########################################################################



        #region Connection String
        private SqlConnection GetConnection()
        {
            var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["EmployeesDBConnectionString"].ConnectionString);

            //con.Open();
            return con;
        }

        #endregion
        //########################################################################



        #region Custom pagination
        /// <summary>
        /// For efficient pagination
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRows"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>

        public static List<clsEmployee> CustomPagination(int pageIndex, int pageSize, string Expression, string SortDirection, string KeyWord = "")
        {

            List<clsEmployee> listEmployees = new List<clsEmployee>();
            clsEmployee ob = new clsEmployee();
            int reporting;

            using (SqlConnection con = ob.GetConnection()) //new SqlConnection(connectionString)
            {
                SqlCommand cmd = new SqlCommand("employee_GetEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramStartIndex = new SqlParameter();
                paramStartIndex.ParameterName = "@PageNo";
                paramStartIndex.Value = pageIndex;
                cmd.Parameters.Add(paramStartIndex);

                SqlParameter paramMaximumRows = new SqlParameter();
                paramMaximumRows.ParameterName = "@PageSize";
                paramMaximumRows.Value = pageSize;
                cmd.Parameters.Add(paramMaximumRows);

                SqlParameter SortExpression = new SqlParameter();
                SortExpression.ParameterName = "@SortExpression";
                SortExpression.Value = Expression;
                cmd.Parameters.Add(SortExpression);


                SqlParameter SortOrder = new SqlParameter();
                SortOrder.ParameterName = "@SortOrder";
                SortOrder.Value = SortDirection;
                cmd.Parameters.Add(SortOrder);

                if (KeyWord != null)
                {
                    SqlParameter KeywordSearch = new SqlParameter();
                    KeywordSearch.ParameterName = "@KeywordSearch";
                    KeywordSearch.Value = KeyWord;
                    cmd.Parameters.Add(KeywordSearch);
                }


                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    clsEmployee emp = new clsEmployee();

                    emp.Id = Convert.ToInt32(rdr["Id"]);
                    emp.FirstName = rdr["FirstName"].ToString();
                    emp.LastName = rdr["LastName"].ToString();
                    emp.Father = rdr["Father"].ToString();
                    emp.Region = rdr["Region"].ToString();
                    emp.Email = rdr["Email"].ToString();
                    emp.DOB = rdr["DOB"].ToString();
                    emp.Address = rdr["Address"].ToString();
                    emp.Contact = rdr["Contact"].ToString();
                    emp.Gender = rdr["Gender"].ToString();
                    emp.Program = rdr["Program"].ToString();
                    emp.Reporting = int.TryParse(rdr["Reporting"].ToString(), out reporting) ? reporting : 0; //Convert.ToInt32(rdr["Reporting"]);
                    listEmployees.Add(emp);
                }

                rdr.Close();


            }

            return listEmployees;
        }
        #endregion
        //########################################################################


        #region Get employee details for Specific ID
        /// <summary>
        /// Get employee details for specific ID 
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <returns></returns>
        public static clsEmployee GetEmployeeDetails(int EmployeeID)
        {
            clsEmployee ob = new clsEmployee();
            List<clsEmployee> empList = new List<clsEmployee>();
            int filesize;
            int reporting;
            var bytes = new byte[] { };

            using (SqlConnection con = ob.GetConnection()) //new SqlConnection(connectionString)
            {
                SqlCommand cmd = new SqlCommand("employee_GetEmployeeDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@Id", EmployeeID));


                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    clsEmployee emp = new clsEmployee();

                    
                    emp.Id = Convert.ToInt32(dr["Id"]);
                    emp.FirstName = dr["FirstName"].ToString();
                    emp.MiddleName = dr["MiddleName"].ToString();
                    emp.LastName = dr["LastName"].ToString();
                    emp.Father = dr["Father"].ToString();
                    emp.Region = dr["Region"].ToString();
                    emp.Email = dr["Email"].ToString();
                    emp.DOB = dr["DOB"].ToString();
                    emp.Address = dr["Address"].ToString();
                    emp.Address2 = dr["Address2"].ToString();
                    emp.City = dr["City"].ToString();
                    emp.State = dr["State"].ToString();
                    emp.ZIP = dr["ZIP"].ToString();
                    emp.Contact = dr["Contact"].ToString();
                    emp.Gender = dr["Gender"].ToString();
                    emp.Program = dr["Program"].ToString();
                    emp.Reporting = int.TryParse(dr["Reporting"].ToString(), out reporting) ? reporting : 0;
                    emp.FileName = dr["FileName"].ToString();
                    emp.FileMimeType = dr["FileMimeType"].ToString();
                    emp.FileSize = int.TryParse(dr["FileSize"].ToString(), out filesize) ? filesize : 0; //Convert.ToInt32(dr["FileSize"].ToString()),
                    emp.FileData = System.Text.Encoding.UTF8.GetBytes(dr["FileData"].ToString()).Length > 0 ? bytes : null;
                    ob = emp;
                    //empList.Add(emp);
                }

                dr.Close();


            }

            return ob; //empList;
        }
        #endregion
        //########################################################################



        #region Fetch employee details from table
        /// <summary>
        /// returns list of employees from database for hidden listview
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static List<clsEmployee> GetClsEmployees(string key = "")
        {
            clsEmployee ob = new clsEmployee();
            List<clsEmployee> empList = new List<clsEmployee>();
            SqlConnection conn = ob.GetConnection();

            conn.Open();

            SqlCommand cmd = new SqlCommand("employee_GetEmployeeId", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (key != "")
            {
                cmd.Parameters.Add(new SqlParameter("@KeywordSearch", key));
            }

            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    empList = (from DataRow dr in dt.Rows
                               select new clsEmployee()
                               {
                                   Id = Convert.ToInt32(dr["Id"])
                               }).ToList();
                }
            }


            return empList;
        }

        #endregion
        //########################################################################



        #region Add and Edit employee
        /// <summary>
        /// On adding and deleting excecution with stored procedure
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="emp"></param>
        public void UpdateEmployee(clsEmployee emp, string action)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("employee_UpdateEmployee", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Stored procedure parameters
                    if (action == "Update")
                    {
                        cmd.Parameters.Add(new SqlParameter("@Id", emp.Id));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@Id", null));
                    }

                    cmd.Parameters.Add(new SqlParameter("@Name", emp.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@Mname", emp.MiddleName));
                    cmd.Parameters.Add(new SqlParameter("@Lname", emp.LastName));
                    cmd.Parameters.Add(new SqlParameter("@Email", emp.Email));
                    cmd.Parameters.Add(new SqlParameter("@Address", emp.Address));
                    cmd.Parameters.Add(new SqlParameter("@Address2", emp.Address2));
                    cmd.Parameters.Add(new SqlParameter("@City", emp.City));
                    cmd.Parameters.Add(new SqlParameter("@State", emp.State));
                    cmd.Parameters.Add(new SqlParameter("@ZIP", emp.ZIP));
                    cmd.Parameters.Add(new SqlParameter("@Father", emp.Father));
                    cmd.Parameters.Add(new SqlParameter("@Region", emp.Region));
                    cmd.Parameters.Add(new SqlParameter("@DOB", emp.DOB));
                    cmd.Parameters.Add(new SqlParameter("@Contact", emp.Contact));
                    cmd.Parameters.Add(new SqlParameter("@Gender", emp.Gender));
                    cmd.Parameters.Add(new SqlParameter("@Program", emp.Program));
                    cmd.Parameters.Add(new SqlParameter("@Reporting", emp.Reporting));
                    //Actions to be performed
                    cmd.Parameters.Add(new SqlParameter("@StatementType", action));
                    cmd.Parameters.Add(new SqlParameter("@FileName", FileName));
                    cmd.Parameters.Add(new SqlParameter("@FileMimeType", FileMimeType));
                    cmd.Parameters.Add(new SqlParameter("@FileSize", FileSize));
                    cmd.Parameters.Add(new SqlParameter("@FileData", FileData));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        //########################################################################



        #region Delete employee method
        /// <summary>
        /// Deletes the employee from the DataBase
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="emp"></param>
        public void DeleteEmployee(clsEmployee emp)
        {
            try
            {
                using (SqlConnection conn = GetConnection()) //new SqlConnection(connectionString)
                {
                    SqlCommand cmd = new SqlCommand("employee_DeleteEmployee", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Stored procedure parameters
                    cmd.Parameters.Add(new SqlParameter("@Id", emp.Id));


                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        //########################################################################
     



        #region Reporting employees
        /// <summary>
        /// Gets employees reporting to Specified ID Empmployee
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static List<clsEmployee> ReportingToEmployee(int ID)
        {

            List<clsEmployee> listEmployees = new List<clsEmployee>();
            clsEmployee ob = new clsEmployee();

            using (SqlConnection con = ob.GetConnection()) //new SqlConnection(connectionString)
            {
                SqlCommand cmd = new SqlCommand("employee_GetReportingEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@Id", ID));

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    clsEmployee emp = new clsEmployee();

                    emp.Id = Convert.ToInt32(rdr["Id"]);
                    emp.FirstName = rdr["FirstName"].ToString();
                    emp.Email = rdr["Email"].ToString();
                    emp.DOB = rdr["DOB"].ToString();
                    emp.Contact = rdr["Contact"].ToString();
                    emp.Gender = rdr["Gender"].ToString();
                    emp.Program = rdr["Program"].ToString();

                    listEmployees.Add(emp);
                }

                rdr.Close();

            }

            return listEmployees;
        }
        #endregion
        //########################################################################


        #region Download employee file
        /// <summary>
        /// Class method for getting file attatchment for the employee id
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <returns></returns>
        public static List<clsEmployee> DownloadFile(int EmployeeID)
        {
            clsEmployee ob = new clsEmployee();
            List<clsEmployee> empList = new List<clsEmployee>();
            SqlConnection conn = ob.GetConnection();

            conn.Open();

            SqlCommand cmd = new SqlCommand("employee_DownloadFileEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add(new SqlParameter("@Id", EmployeeID));


            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    empList = (from DataRow dr in dt.Rows
                               select new clsEmployee()
                               {
                                   FileName = dr["FileName"].ToString(),
                                   FileMimeType = dr["FileMimeType"].ToString(),
                                   FileData = (byte[])(dr["FileData"])
                               }).ToList();
                }
            }


            return empList;
        }
        #endregion
        //########################################################################




        #region Dropdown reporting
        /// <summary>
        /// Gets values and text for dropdown for add and edit page
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static List<clsEmployee> GetReportingDropdown(int? ID)
        {

            List<clsEmployee> listEmployees = new List<clsEmployee>();
            clsEmployee ob = new clsEmployee();

            using (SqlConnection con = ob.GetConnection()) //new SqlConnection(connectionString)
            {
                SqlCommand cmd = new SqlCommand("employee_GetReportingDDLEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@Id", ID));

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    clsEmployee emp = new clsEmployee();

                    emp.Id = Convert.ToInt32(rdr["Id"]);
                    emp.FirstName = rdr["FirstName"].ToString();

                    listEmployees.Add(emp);
                }

                rdr.Close();

            }

            return listEmployees;
        }
        #endregion
        //########################################################################




        #region Custom Validation
        /// <summary>
        /// Fetches all records from Database
        /// </summary>
        /// <returns></returns>
        public static List<clsEmployee> Fetch()
        {
            clsEmployee ob = new clsEmployee();
            List<clsEmployee> empList = new List<clsEmployee>();
            int reporting;
            using (SqlConnection con = ob.GetConnection()) //new SqlConnection(connectionString)
            {
                string selectSQL = "select * from EmployeesDB.dbo.dat_Employee;";
                SqlCommand cmd = new SqlCommand(selectSQL, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    //Fetch every row
                    while (dr.Read())
                    {
                        clsEmployee emp = new clsEmployee();

                        emp.Id = Convert.ToInt32(dr["Id"]);
                        emp.FirstName = dr["FirstName"].ToString();
                        emp.LastName = dr["LastName"].ToString();
                        emp.Father = dr["Father"].ToString();
                        emp.Region = dr["Region"].ToString();
                        emp.Email = dr["Email"].ToString();
                        emp.DOB = dr["DOB"].ToString();
                        emp.Address = dr["Address"].ToString();
                        emp.Contact = dr["Contact"].ToString();
                        emp.Gender = dr["Gender"].ToString();
                        emp.Program = dr["Program"].ToString();
                        emp.Reporting = int.TryParse(dr["Reporting"].ToString(), out reporting) ? reporting : 0;
                        empList.Add(emp);
                    }
                }
                con.Close();
            }
            return empList;
        }
        #endregion
        //########################################################################



        #region Dead block
        //string selectSQL = "select * from EmployeesDB.dbo.dat_Employee;";
        //SqlDataReader dr = cmd.ExecuteReader();

        //if (dr != null)
        //{
        //    //Fetch every row
        //    while (dr.Read())
        //    {
        //        clsEmployee emp = new clsEmployee();

        //        emp.Id = Convert.ToInt32(dr["Id"]);
        //        emp.FirstName = dr["FirstName"].ToString();
        //        emp.LastName = dr["LastName"].ToString();
        //        emp.Father = dr["Father"].ToString() ;
        //        emp.Region = dr["Region"].ToString();
        //        emp.Email = dr["Email"].ToString();
        //        emp.DOB = dr["DOB"].ToString();
        //        emp.Address = dr["Address"].ToString();
        //        emp.Contact = dr["Contact"].ToString();
        //        emp.Gender = dr["Gender"].ToString();
        //        emp.Program = dr["Program"].ToString();

        //        empList.Add(emp);
        //    }
        //}



        #region emp details
        //SqlConnection conn = ob.GetConnection();
        //int filesize;
        //var bytes = new byte[] { };

        //conn.Open();

        //SqlCommand cmd = new SqlCommand("employee_GetEmployeeDetail", conn);
        //cmd.CommandType = CommandType.StoredProcedure;


        //cmd.Parameters.Add(new SqlParameter("@Id", EmployeeID));


        //using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //{
        //    using (DataTable dt = new DataTable())
        //    {
        //        sda.Fill(dt);
        //        empList = (from DataRow dr in dt.Rows
        //                   select new clsEmployee()
        //                   {
        //                       Id = Convert.ToInt32(dr["Id"]),
        //                       FirstName = dr["FirstName"].ToString(),
        //                       MiddleName = dr["MiddleName"].ToString(),
        //                       LastName = dr["LastName"].ToString(),
        //                       Father = dr["Father"].ToString(),
        //                       Region = dr["Region"].ToString(),
        //                       Email = dr["Email"].ToString(),
        //                       DOB = dr["DOB"].ToString(),
        //                       Address = dr["Address"].ToString(),
        //                       Address2 = dr["Address2"].ToString(),
        //                       City = dr["City"].ToString(),
        //                       State = dr["State"].ToString(),
        //                       ZIP = dr["ZIP"].ToString(),
        //                       Contact = dr["Contact"].ToString(),
        //                       Gender = dr["Gender"].ToString(),
        //                       Program = dr["Program"].ToString(),
        //                       Reporting = (int)dr["Reporting"],
        //                       FileName = dr["FileName"].ToString(),
        //                       FileMimeType = dr["FileMimeType"].ToString(),
        //                       FileSize = int.TryParse(dr["FileSize"].ToString(), out filesize) ? filesize : 0, //Convert.ToInt32(dr["FileSize"].ToString()),
        //                       FileData = System.Text.Encoding.UTF8.GetBytes(dr["FileData"].ToString()).Length > 0 ? bytes : null
        //                   }).ToList();
        //    }



        #endregion

        #endregion
        //########################################################################
    }
}
