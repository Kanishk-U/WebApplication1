<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="reportingEmployee.ascx.cs" Inherits="WebApplication1.UserControl.ListviewControl" %>
<div id="lvWrapper" class="mb-3">
                <asp:ListView ID="lvEmployee" OnItemCommand="lvEmployee_ItemCommand"  runat="server">
                    <%-- Row header --%>

                    <LayoutTemplate>
                        <div class="row bg-secondary text-white  text-uppercase text-center p-2 mt-3 hdrList">
                            <div class="col-lg-1" runat="server"></div>
                            <div class="col-lg-1" runat="server">
                                <asp:LinkButton ID="lbName" CommandArgument="NAME" CommandName="Sort" Text="Name" CssClass="text-decoration-none" runat="server">Name </asp:LinkButton>


                            </div>
                            <div class="col-lg-3" runat="server">
                                <asp:LinkButton ID="lbEmail" CommandArgument="EMAIL" CommandName="Sort" Text="Email" CssClass="text-decoration-none" runat="server">Email </asp:LinkButton>
                            </div>
                            <div class="col-lg-2" runat="server">
                                <asp:LinkButton ID="lbDOB" CommandArgument="DOB" CommandName="Sort" Text="DOB" CssClass="text-decoration-none" runat="server">DOB </asp:LinkButton>
                            </div>

                            <div class="col-lg-2" runat="server">
                                <asp:LinkButton ID="lbContact" CommandArgument="CONTACT" CommandName="Sort" Text="Contact" CssClass="text-decoration-none" runat="server">Contact </asp:LinkButton>
                            </div>
                            <div class="col-lg-2 p-0" runat="server">
                                <asp:LinkButton ID="lbGender" CommandArgument="GENDER" CommandName="Sort" Text="Gender" CssClass="text-decoration-none" runat="server">Gender </asp:LinkButton>
                            </div>
                            <div class="col-lg-1 p-0" runat="server">
                                <asp:LinkButton ID="lbProgram" CommandArgument="PROGRAM" CommandName="Sort" Text="Program" CssClass="text-decoration-none" runat="server">Program </asp:LinkButton>
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
                                            <asp:Button ID="btnEdit" CommandArgument='<%# Eval("Id") %>' CommandName="ID"  runat="server" Text="Edit" CssClass="w-75 w3-bar-item bg-primary btn btn-sm text-white" /></li>
                                       
                                    </ul>
                                </div>
                            </div>
                            <div class="col-lg-1 pt-1" runat="server">
                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>
                            </div>
                            <div class="col-lg-3 pt-1" runat="server">
                                <asp:Label ID="lblFname" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                            </div>
                            <div class="col-lg-2 pt-1" runat="server">
                                <asp:Label ID="lblDOB" runat="server" Text='<%# Eval("DOB") %>'></asp:Label>
                            </div>

                            <div class="col-lg-2 pt-1" runat="server">
                                <asp:Label ID="lblContact" runat="server" Text='<%# Eval("Contact") %>'></asp:Label>
                            </div>
                            <div class="col-lg-2 pt-1" runat="server">
                                <asp:Label ID="lblGender" runat="server" Text='<%# Eval("Gender") %>'></asp:Label>
                            </div>
                            <div class="col-lg-1 px-0 pt-1" runat="server">
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
                            <div class="col-lg-2" runat="server">
                                <asp:LinkButton ID="lbDOB" CommandArgument="DOB" CssClass="text-decoration-none" CommandName="Sort" Text="DOB" runat="server" />
                            </div>

                            <div class="col-lg-2" runat="server">
                                <asp:LinkButton ID="lbContact" CommandArgument="CONTACT" CssClass="text-decoration-none" CommandName="Sort" Text="Contact" runat="server" />
                            </div>
                            <div class="col-lg-2" runat="server">
                                <asp:LinkButton ID="lbGender" CommandArgument="GENDER" CssClass="text-decoration-none" CommandName="Sort" Text="Gender" runat="server" />
                            </div>
                            <div class="col-lg-1 p-0" runat="server">
                                <asp:LinkButton ID="lbProgram" CommandArgument="PROGRAM" CssClass="text-decoration-none" CommandName="Sort" Text="Program" runat="server" />
                            </div>
                            
                        </div>
                        <div class="row my-2 border border-dark text-center" runat="server">

                            <h2 class="text-danger">No data available at the moment</h2>

                        </div>
                    </EmptyDataTemplate>

                </asp:ListView>
            </div>