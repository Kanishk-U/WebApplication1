using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using EmployeeCommon.Employee;

namespace WebApplication1.Employee
{
    /// <summary>
    /// Summary description for DownloadFile
    /// </summary>
    public class DownloadFile : IHttpHandler
    {

        #region
        /// <summary>
        /// Processing request frm Employ edit page for downloading attachment
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int Employeeid;
            var Request = HttpContext.Current.Request;
            var Response = HttpContext.Current.Response;
            if (Int32.TryParse(Request.QueryString["EmpId"], out Employeeid))
            {
                
               
                List<clsEmployee> employees = clsEmployee.DownloadFile(Employeeid);
                var emp = employees.First();
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = emp.FileMimeType; /*contentType;*/
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + emp.FileName /*fileName*/);
                Response.BinaryWrite(emp.FileData /*bytes*/);
                Response.Flush();
                Response.End();
            }
                
        }
        #endregion




        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


        #region DEAD BLOCK
        //byte[] bytes;
        //string fileName, contentType;
        //string constr = WebConfigurationManager.ConnectionStrings["EmployeesDBConnectionString"].ConnectionString;
        //using (SqlConnection con = new SqlConnection(constr))
        //{
        //    using (SqlCommand cmd = new SqlCommand())
        //    {
        //        cmd.CommandText = "select FileName, FileData, FileMimeType from dbo.dat_Employee  where Id=@Id";
        //        cmd.Parameters.AddWithValue("@Id", Employeeid);
        //        cmd.Connection = con;
        //        con.Open();
        //        using (SqlDataReader sdr = cmd.ExecuteReader())
        //        {
        //            sdr.Read();
        //            bytes = (byte[])sdr["FileData"];
        //            contentType = sdr["FileMimeType"].ToString();
        //            fileName = sdr["FileName"].ToString();
        //        }
        //        con.Close();
        //    }
        //}
        #endregion
    }
}