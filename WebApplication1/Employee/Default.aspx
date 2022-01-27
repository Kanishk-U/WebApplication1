<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmployeeForm.Employee.Default" MasterPageFile="~/Employee/EmployeeMaster.Master" %>


<asp:Content ID="ContentDefault" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="server">
    <script type="text/javascript">
        function HideLabel() {
            var seconds = 3;
            setTimeout(function () {
                document.getElementById("<%=pnlMessage.ClientID %>").style.display = "none";
            }, seconds * 1000);
        };
    </script>
    <div>
        <asp:Panel ID="pnlMessage" runat="server">
            <asp:Literal ID="litMessage" runat="server"></asp:Literal>
        </asp:Panel>
    </div>
    <asp:HiddenField ID="hdnExpression" runat="server" />
    <div class="row header-wrapper mb-2">
    </div>
    <%-- Search button --%>
    <div class="row">

        <div class="col-lg-2">
            <asp:TextBox ID="txtsearch" CssClass="form-control" Width="180px" MaxLength="10" placeholder="Keyword search" runat="server" />
        </div>
        <div class="col-lg-10 px-0">
            <asp:Button ID="btnSearch" CssClass="btn btn-primary btn-sm col-lg-1 mb-2" runat="server" Text="Search" OnClick="search_btn_Click" />
            <asp:Button ID="btnAdd" runat="server" Text="Add" Class="btn btn-primary btn-lg col-lg-1 add-btn" Width="130px" OnClick="Add_Click" Style="margin-left: 78%" />
        </div>


    </div>
    <asp:UpdatePanel ID="upListView" runat="server">
        <ContentTemplate>
            <div id="lvWrapper" class="mb-3">
                <asp:ListView ID="lvEmployee" OnItemCommand="lvEmployee_ItemCommand" OnSorting="lvEmployee_Sorting" runat="server">
                    <%-- Row header --%>

                    <LayoutTemplate>
                        <div class="row bg-secondary text-white  text-uppercase text-center p-2 mt-3 hdrList">
                            <div class="col-lg-1" runat="server"></div>
                            <div class="col-lg-1" runat="server">
                                <asp:LinkButton ID="lbName" CommandArgument="NAME" CommandName="Sort" Text="Name" CssClass="text-decoration-none" runat="server">Name <i class="fas fa-solid fa-sort"></i></asp:LinkButton>


                            </div>
                            <div class="col-lg-3" runat="server">
                                <asp:LinkButton ID="lbEmail" CommandArgument="EMAIL" CommandName="Sort" Text="Email" CssClass="text-decoration-none" runat="server">Email <i class="fas fa-solid fa-sort"></i></asp:LinkButton>
                            </div>
                            <div class="col-lg-1" runat="server">
                                <asp:LinkButton ID="lbDOB" CommandArgument="DOB" CommandName="Sort" Text="DOB" CssClass="text-decoration-none" runat="server">DOB <i class="fas fa-solid fa-sort"></i></asp:LinkButton>
                            </div>

                            <div class="col-lg-2" runat="server">
                                <asp:LinkButton ID="lbContact" CommandArgument="CONTACT" CommandName="Sort" Text="Contact" CssClass="text-decoration-none" runat="server">Contact <i class="fas fa-solid fa-sort"></i></asp:LinkButton>
                            </div>
                            <div class="col-lg-2 p-0" runat="server">
                                <asp:LinkButton ID="lbGender" CommandArgument="GENDER" CommandName="Sort" Text="Gender" CssClass="text-decoration-none" runat="server">Gender <i class="fas fa-solid fa-sort"></i></asp:LinkButton>
                            </div>
                            <div class="col-lg-2 p-0" runat="server">
                                <asp:LinkButton ID="lbProgram" CommandArgument="PROGRAM" CommandName="Sort" Text="Program" CssClass="text-decoration-none" runat="server">Program <i class="fas fa-solid fa-sort"></i></asp:LinkButton>
                            </div>
                            
                        </div>
                        <tr class="row" runat="server" id="itemPlaceholder" />

                    </LayoutTemplate>
                    <%-- Employees row --%>
                    <ItemTemplate>
                        <div class="row my-2 border border-dark bg-white text-center" runat="server">
                            <div class="col-lg-1" runat="server">


                                <div class="dropdown">
                                    <button class="btn btn-sm bg-success text-white dropdown-toggle" type="button" id="ddAction" data-bs-toggle="dropdown" aria-expanded="false">
                                        Action
                                    </button>
                                    <ul class="dropdown-menu p-0 b=0 bg-transparent border-0" aria-labelledby="dropdownMenuButton1">
                                        <li>
                                            <asp:Button ID="btnEdit" CommandArgument='<%# Eval("Id") %>' CommandName="ID" UseSubmitBehavior="False" runat="server" Text="Edit" CssClass="w-75 w3-bar-item bg-primary btn btn-sm text-white" /></li>
                                        <li>
                                            <asp:Button ID="btnDelete" CommandArgument='<%# Eval("Id") %>' UseSubmitBehavior="true" CommandName="DEL" runat="server" Text="Delete" CssClass="w-75 w3-bar-item bg-danger btn btn-sm text-white" /></li>

                                    </ul>
                                </div>
                            </div>
                            <div class="col-lg-1 pt-1" runat="server">
                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>
                            </div>
                            <div class="col-lg-3 pt-1" runat="server">
                                <asp:Label ID="lblFname" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                            </div>
                            <div class="col-lg-1 pt-1" runat="server">
                                <asp:Label ID="lblDOB" runat="server" Text='<%# Eval("DOB") %>'></asp:Label>
                            </div>

                            <div class="col-lg-2 pt-1" runat="server">
                                <asp:Label ID="lblContact" runat="server" Text='<%# Eval("Contact") %>'></asp:Label>
                            </div>
                            <div class="col-lg-2 pt-1" runat="server">
                                <asp:Label ID="lblGender" runat="server" Text='<%# Eval("Gender") %>'></asp:Label>
                            </div>
                            <div class="col-lg-2 px-0 pt-1" runat="server">
                                <asp:Label ID="lblProgram" runat="server" Text='<%# Eval("Program") %>'></asp:Label>
                            </div>
                            


                        </div>
                    </ItemTemplate>

                    <%-- Empty Data  --%>
                    <EmptyDataTemplate>
                        <div class="row bg-secondary text-white text-uppercase text-center p-2 mt-3 hdrList">
                            <div class="col-lg-1" runat="server"></div>
                            <div class="col-lg-1" runat="server">
                                <asp:LinkButton ID="lbName" CommandArgument="NAME" CssClass="text-decoration-none" CommandName="Sort" Text="Name" runat="server" />
                            </div>
                            <div class="col-lg-3" runat="server">
                                <asp:LinkButton ID="lbEmail" CommandArgument="EMAIL" CssClass="text-decoration-none" CommandName="Sort" Text="Email" runat="server" />
                            </div>
                            <div class="col-lg-1" runat="server">
                                <asp:LinkButton ID="lbDOB" CommandArgument="DOB" CssClass="text-decoration-none" CommandName="Sort" Text="DOB" runat="server" />
                            </div>

                            <div class="col-lg-2" runat="server">
                                <asp:LinkButton ID="lbContact" CommandArgument="CONTACT" CssClass="text-decoration-none" CommandName="Sort" Text="Contact" runat="server" />
                            </div>
                            <div class="col-lg-2" runat="server">
                                <asp:LinkButton ID="lbGender" CommandArgument="GENDER" CssClass="text-decoration-none" CommandName="Sort" Text="Gender" runat="server" />
                            </div>
                            <div class="col-lg-2 p-0" runat="server">
                                <asp:LinkButton ID="lbProgram" CommandArgument="PROGRAM" CssClass="text-decoration-none" CommandName="Sort" Text="Program" runat="server" />
                            </div>
                            
                        </div>
                        <div class="row my-2 border border-dark text-center" runat="server">

                            <h2 class="text-danger">No data available at the moment</h2>

                        </div>
                    </EmptyDataTemplate>

                </asp:ListView>
            </div>
        </ContentTemplate>
        <Triggers>
                  <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
               </Triggers>
    </asp:UpdatePanel>

    <%--Hidden listview--%>
    <asp:ListView ID="ListViewHDN" OnPagePropertiesChanging="lvEmployee_PagePropertiesChanging" Visible="false" OnDataBound="lvEmployee_DataBound" runat="server">
        <%-- Row header --%>

        <LayoutTemplate>
            <div class="row bg-secondary text-white  text-uppercase text-center p-2 mt-3 hdrList">
                <div class="col-lg-1" runat="server"></div>

            </div>
            <tr class="row" runat="server" id="itemPlaceholder" />

        </LayoutTemplate>
        <%-- Employees row --%>
        <ItemTemplate>
            <div class="row my-2 border border-dark bg-white text-center" runat="server">
                <div class="col-lg-1" runat="server"><%# Eval("Id") %> </div>
            </div>
        </ItemTemplate>

        <%-- Empty Data  --%>
    </asp:ListView>






    <%-- Pagination --%>
    <asp:DataPager ID="lvDataPager" runat="server" PagedControlID="ListViewHDN" PageSize="3">
        <Fields>
            <asp:NumericPagerField ButtonType="Link" NumericButtonCssClass="datapagerStyle" CurrentPageLabelCssClass="current_page" NextPreviousButtonCssClass="next_button" />

        </Fields>
    </asp:DataPager>







</asp:Content>
