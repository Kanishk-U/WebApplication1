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

namespace EmployeeForm.Employee
{
    
    public partial class Default : System.Web.UI.Page
    {
        #region new object declaration
        List<clsEmployee> col = new List<clsEmployee>();
    
        #endregion collecting list from session
        //########################################################################




        #region On page load checks
        /// <summary>
        /// Page on load functionality
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                Bind();
                
            }
            
            SuccessMessage();
            
        }
        #endregion
        //########################################################################




        #region Add item button
        /// <summary>
        /// Add button redirects to Edit page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Add_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveUrl("Employee-Edit.aspx"));
        }
        #endregion
        //########################################################################





        #region Success Message
        /// <summary>
        /// Success message on add,update and delete with timer property
        /// </summary>
        protected void SuccessMessage()
        {
            bool flag = false;
            if (Request.QueryString["msg"] != null)
            {
                flag = true;
                pnlMessage.Visible = flag;
                string Message = Request.QueryString["msg"];
                switch (Message)
                {
                    case "ADD":
                        litMessage.Text = "Employee added successfully";
                        pnlMessage.Attributes.Add("class", "alert alert-success");
                        PropertyInfo isread = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                        // make collection editable
                        isread.SetValue(this.Request.QueryString, false, null);
                        // remove
                        this.Request.QueryString.Remove("msg");
                        break;
                    case "UPDATE":
                        litMessage.Text = "Employee updated successfully";
                        pnlMessage.Attributes.Add("class", "alert alert-success");
                        PropertyInfo read = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                        // make collection editable
                        read.SetValue(this.Request.QueryString, false, null);
                        // remove
                        this.Request.QueryString.Remove("msg");
                        break;
                    case "DELETE":
                        litMessage.Text = "Employee deleted successfully";
                        pnlMessage.Attributes.Add("class", "alert alert-danger");
                        PropertyInfo readOnly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                        // make collection editable
                        readOnly.SetValue(this.Request.QueryString, false, null);
                        // remove
                        this.Request.QueryString.Remove("msg");
                        break;

                }
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
            }
            else
            {
                pnlMessage.Visible = flag;
            }
        }
        #endregion
        //########################################################################




        #region search button 
        /// <summary>
        /// Search button functionality
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void search_btn_Click(object sender, EventArgs e)
        {
            lvEmployee.Items.Clear();
            string S_word = txtsearch.Text.Trim();
            lvEmployee.DataSource = clsEmployee.CustomPagination(1, lvDataPager.PageSize,"NAME","1",S_word);
            lvEmployee.DataBind();

            ListViewHDN.DataSource = clsEmployee.GetClsEmployees(S_word);
            ListViewHDN.DataBind();

        }
        #endregion                                                                       
        //########################################################################


        #region Paging functionality navigation on single click
        /// <summary>
        /// For smooth navigations in pages
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lvEmployee_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            //set current page startindex, max rows and rebind to false
            lvDataPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            int pageIndex;


            pageIndex = (lvDataPager.StartRowIndex / lvDataPager.MaximumRows) + 1;
            Response.Redirect(Page.ResolveUrl(String.Format("Default.aspx?p={0}&s={1}&e={2}&o={3}&sr={4}&mr={5}", pageIndex, lvDataPager.PageSize, "ASC", 1, e.StartRowIndex, e.MaximumRows))) ;
            
            
        }
        #endregion
        //########################################################################


        
        #region Sorting
        /// <summary>
        /// sorting functionality
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lvEmployee_Sorting(object sender, ListViewSortEventArgs e)

        {
            int pageIndex;
            string Expression = Request.QueryString["e"];
            string Order = Request.QueryString["o"];
            //Bind(ref col);

            switch (e.SortExpression)
            {
                case "NAME":
                    if (Expression != null && Expression == e.SortExpression && Order != "2" ) 
                    {                      
                        pageIndex = (lvDataPager.StartRowIndex / lvDataPager.MaximumRows) + 1;
                        
                        Response.Redirect(Page.ResolveUrl(String.Format("Default.aspx?p={0}&s={1}&e={2}&o={3}", pageIndex, lvDataPager.PageSize, "NAME", 2)));
                    }
                    else
                    {                       
                        pageIndex = (lvDataPager.StartRowIndex / lvDataPager.MaximumRows) + 1;
                        
                        Response.Redirect(Page.ResolveUrl(String.Format("Default.aspx?p={0}&s={1}&e={2}&o={3}", pageIndex, lvDataPager.PageSize, "NAME", 1)));
                    }
                    break;
                case "EMAIL":
                    if (Expression != null && Expression == e.SortExpression && Order != "2")
                    {
                        pageIndex = (lvDataPager.StartRowIndex / lvDataPager.MaximumRows) + 1;
                        
                        Response.Redirect(Page.ResolveUrl(String.Format("Default.aspx?p={0}&s={1}&e={2}&o={3}", pageIndex, lvDataPager.PageSize, "EMAIL", 2)));
                    }
                    else
                    {
                        pageIndex = (lvDataPager.StartRowIndex / lvDataPager.MaximumRows) + 1;
                        
                        Response.Redirect(Page.ResolveUrl(String.Format("Default.aspx?p={0}&s={1}&e={2}&o={3}", pageIndex, lvDataPager.PageSize, "EMAIL", 1)));
                    }
                    break;
                case "DOB":
                    if (Expression != null && Expression == e.SortExpression && Order != "2")
                    {
                        pageIndex = (lvDataPager.StartRowIndex / lvDataPager.MaximumRows) + 1;
                        
                        Response.Redirect(Page.ResolveUrl(String.Format("Default.aspx?p={0}&s={1}&e={2}&o={3}", pageIndex, lvDataPager.PageSize, "DOB", 2)));
                    }
                    else
                    {
                        pageIndex = (lvDataPager.StartRowIndex / lvDataPager.MaximumRows) + 1;
                        
                        Response.Redirect(Page.ResolveUrl(String.Format("Default.aspx?p={0}&s={1}&e={2}&o={3}", pageIndex, lvDataPager.PageSize, "DOB", 1)));
                    }
                    break;
                case "CONTACT":
                    if (Expression != null && Expression == e.SortExpression && Order != "2")
                    {
                        pageIndex = (lvDataPager.StartRowIndex / lvDataPager.MaximumRows) + 1;
                        
                        Response.Redirect(Page.ResolveUrl(String.Format("Default.aspx?p={0}&s={1}&e={2}&o={3}", pageIndex, lvDataPager.PageSize, "CONTACT", 2)));
                    }
                    else
                    {
                        pageIndex = (lvDataPager.StartRowIndex / lvDataPager.MaximumRows) + 1;
                        
                        Response.Redirect(Page.ResolveUrl(String.Format("Default.aspx?p={0}&s={1}&e={2}&o={3}", pageIndex, lvDataPager.PageSize, "CONTACT", 1)));
                    }
                    break;
                case "GENDER":
                    if (Expression != null && Expression == e.SortExpression && Order != "2")
                    {
                        pageIndex = (lvDataPager.StartRowIndex / lvDataPager.MaximumRows) + 1;
                        
                        Response.Redirect(Page.ResolveUrl(String.Format("Default.aspx?p={0}&s={1}&e={2}&o={3}", pageIndex, lvDataPager.PageSize, "GENDER", 2)));
                    }
                    else
                    {
                        pageIndex = (lvDataPager.StartRowIndex / lvDataPager.MaximumRows) + 1;
                        
                        Response.Redirect(Page.ResolveUrl(String.Format("Default.aspx?p={0}&s={1}&e={2}&o={3}", pageIndex, lvDataPager.PageSize, "GENDER", 1)));
                    }
                    break;
                case "PROGRAM":
                    if (Expression != null && Expression == e.SortExpression && Order != "2" ) 
                    {                       
                        pageIndex = (lvDataPager.StartRowIndex / lvDataPager.MaximumRows) + 1;
                        

                        Response.Redirect(Page.ResolveUrl(String.Format("Default.aspx?p={0}&s={1}&e={2}&o={3}", pageIndex, lvDataPager.PageSize, "PROGRAM", 2)));
                    }
                    else
                    {                       
                        pageIndex = (lvDataPager.StartRowIndex / lvDataPager.MaximumRows) + 1;
                        
                        Response.Redirect(Page.ResolveUrl(String.Format("Default.aspx?p={0}&s={1}&e={2}&o={3}", pageIndex, lvDataPager.PageSize, "PROGRAM", 1)));

                    }
                    break;
            }
            
            
        }
        #endregion
        //########################################################################



        #region Visibility of paging
        /// <summary>
        /// No paging to be visible if page size is 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lvEmployee_DataBound(object sender, EventArgs e)
        {
            lvDataPager.Visible = (lvDataPager.PageSize < lvDataPager.TotalRowCount);
            
        }
        #endregion
        //########################################################################



        #region Binding listview
        /// <summary>
        /// Method to bind data source for listview
        /// </summary>
        /// <param name="EmpDetails"></param>
        private void Bind()
        {

            int PageIndex;
            Int32.TryParse(Request.QueryString["p"], out PageIndex);
            string Expression = Request.QueryString["e"];
            string SortOrder = Request.QueryString["o"];
            int StartRow;
            Int32.TryParse(Request.QueryString["sr"], out StartRow);
            int MaxRow;
            Int32.TryParse(Request.QueryString["mr"], out MaxRow);

            if (PageIndex == 0)
            {
                PageIndex = 1;
            }

            lvDataPager.SetPageProperties(StartRow, lvDataPager.MaximumRows , false);

            lvEmployee.DataSource = clsEmployee.CustomPagination(PageIndex, lvDataPager.PageSize, Expression, SortOrder);
            lvEmployee.DataBind();

            ListViewHDN.DataSource = clsEmployee.GetClsEmployees();
            ListViewHDN.DataBind();


        }
        #endregion
        //########################################################################


        #region Edit and Delete functionality
        /// <summary>
        /// Employee to be edited and deleted through query string
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lvEmployee_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ID")
            {
                Response.Redirect("Employee-Edit.aspx?ID=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "DEL")
            {
                int EmployeeId;
                Int32.TryParse((string)e.CommandArgument, out EmployeeId);
                //Bind(ref col);
                clsEmployee emp = clsEmployee.GetEmployeeDetails(EmployeeId);
               
                                    
                    emp.DeleteEmployee( emp);
                    Bind();
                    Response.Redirect(Page.ResolveUrl("Default.aspx?msg=" + "DELETE"));
                    

            }
        }
        #endregion
        //########################################################################


        #region Commented code
        //Int32.TryParse(Request.QueryString["p"], out PageIndex);
        //        PropertyInfo readOnly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
        //// make collection editable
        //readOnly.SetValue(this.Request.QueryString, false, null);
        //        // remove
        //        this.Request.QueryString.Remove("p");
        //        this.Request.QueryString.Remove("s");
        //        this.Request.QueryString.Remove("e");
        //        this.Request.QueryString.Remove("o");
        #endregion

    }
}
