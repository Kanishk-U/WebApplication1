using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeCommon.Employee;

namespace WebApplication1.UserControl
{
    public partial class ListviewControl : System.Web.UI.UserControl
    {
        #region new object declaration
        List<clsEmployee> col = new List<clsEmployee>();
        public int EmployeeId { get; set; }

        #endregion collecting list from session


        #region On page load
        /// <summary>
        /// Page loadof Listview user control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                col = clsEmployee.ReportingToEmployee(EmployeeId);
                lvEmployee.DataSource = col;
                lvEmployee.DataBind();
            }
            
        }
        #endregion



        #region Edit employee
        /// <summary>
        /// Edit button command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lvEmployee_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ID")
            {
                Response.Redirect(Page.ResolveUrl("Employee-Edit.aspx?ID=" + e.CommandArgument.ToString()));
            }
        }
        #endregion
    }
}