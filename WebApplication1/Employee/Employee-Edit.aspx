<%@ Page Language="C#" AutoEventWireup="true" enableSessionState="true" CodeBehind="Employee-Edit.aspx.cs"  MasterPageFile="~/Employee/EmployeeMaster.Master" Inherits="EmployeeForm.Employee.Employee_Edit" %>

<%@ Register Src="~/UserControl/reportingEmployee.ascx" TagPrefix="UC" TagName="ListviewControl" %>



            <asp:Content ID="ContentEmployeeEdit" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="server"> 
                <div class="row">
                    <div class="col-lg-12">
                        <section class="panel shadow-lg p-3 mb-5 bg-white rounded">
                            <header class="hdn-panel">
                                <div class="col-md-12 mb-5 col-md-offset-4">
                                    <h1>Employee Registration</h1>
                                </div>

                            </header>
                            <!-- Validation Summary  -->
                            <asp:ValidationSummary ID="vSummary" class="alert alert-danger" ShowSummary="true" ValidationGroup="valEmployee" runat="server" ForeColor="Red" />
                            <asp:RequiredFieldValidator ID="rvFirstName" runat="server" ControlToValidate="txtFirstName" ValidationGroup="valEmployee" ErrorMessage="Please enter user first name" Display="None" ForeColor="Red" />
                            <asp:RequiredFieldValidator ID="rvLName" runat="server" ControlToValidate="txtLastName" ValidationGroup="valEmployee" ErrorMessage="Please enter user last name" Display="None" ForeColor="Red" />
                            <asp:RequiredFieldValidator ID="rvFather" runat="server" ControlToValidate="txtFather" ValidationGroup="valEmployee" ErrorMessage="Please enter father's name" Display="None" ForeColor="Red" />
                            <asp:RequiredFieldValidator ID="rvEmail" runat="server" ControlToValidate="txtEmail" ValidationGroup="valEmployee" ErrorMessage="please enter email address" Display="None" ForeColor="Red" />
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ValidationGroup="valEmployee"
                                ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                Display="None" ErrorMessage="Invalid email address" />
                            <asp:CustomValidator runat="server" ID="cvEmail" ControlToValidate="txtEmail" ValidationGroup="valEmployee" ErrorMessage="Email already exists" Display="None" OnServerValidate="cusCustom_ServerValidate"  />
                            <%--<asp:RequiredFieldValidator ID="rvReporting" runat="server" ControlToValidate="ddlReporting" ValidationGroup="valEmployee" ErrorMessage="Please enter whom to report" Display="None" ForeColor="Red" />--%>
                            <asp:RequiredFieldValidator ID="rvDOB" runat="server" ControlToValidate="txtdob" ValidationGroup="valEmployee" ErrorMessage="Please enter date of birth" Display="None" ForeColor="Red" />
                            <asp:RequiredFieldValidator ID="rvRegion" runat="server" ControlToValidate="ddlRegion" ValidationGroup="valEmployee" ErrorMessage="Please enter a region" Display="None" ForeColor="Red" />
                            <asp:RequiredFieldValidator ID="rvAddress" runat="server" ControlToValidate="txtAddress" ValidationGroup="valEmployee" ErrorMessage="Please enter address details" Display="None" ForeColor="Red" />
                            <asp:RequiredFieldValidator ID="rvGender" runat="server" ControlToValidate="txtGender" ValidationGroup="valEmployee" ErrorMessage="Please enter gender specification" Display="None" ForeColor="Red" />
                            <asp:RequiredFieldValidator ID="rvCell" runat="server" ControlToValidate="txtCell" ValidationGroup="valEmployee" ErrorMessage="Please enter contact information" Display="None" ForeColor="Red" />
                            <asp:RegularExpressionValidator ID="valrcell" runat="server" ControlToValidate="txtCell" ValidationGroup="valEmployee" ErrorMessage="Enter only numeric password and length must be between 7 to 10 characters" Display="None" ForeColor="Red" ValidationExpression="^[0-9]{7,10}$">
                            </asp:RegularExpressionValidator>
                            <asp:HiddenField ID="hdnID" runat="server" />
                            
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-4 col-lg-12  col-md-offset-1">
                                        <!-- Employee Name -->
                                        <div class="form-group row">
                                            <asp:Label runat="server" CssClass="col-lg-3" ID="lblEmpName"><b>Employee Name :</b><span style="color:red">*</span></asp:Label>
                                            <div class="col-lg-3 mb-2">
                                                <asp:TextBox runat="server" required="required" ValidationGroup="valEmployee" Enabled="True" ID="txtFirstName" MaxLength="20" class="form-control input-sm" placeholder="First Name" />
                                            </div>
                                            <div class="col-lg-3 mb-2">
                                                <asp:TextBox runat="server" Enabled="True" ID="txtMiddleName" MaxLength="20" class="form-control input-sm" placeholder="Middle Name" />
                                            </div>
                                            <div class="col-lg-3 mb-2">
                                                <asp:TextBox runat="server" required="required" ValidationGroup="valEmployee" Enabled="True" ID="txtLastName" MaxLength="20" class="form-control input-sm" placeholder="Last Name" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-lg-12 my-2 col-md-offset-1">
                                        <!-- Employee Father Name -->
                                        <div class="form-group row">
                                            <asp:Label runat="server" CssClass="col-lg-3" ID="lblFather"><b>Father Name :</b><span style="color:red">*</span></asp:Label>
                                            <div class="col-lg-6">
                                                <asp:TextBox runat="server" required="required" ValidationGroup="valEmployee" MaxLength="20" Enabled="True" ID="txtFather" class="form-control input-sm" placeholder="Father Name" />
                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-4 col-lg-12 my-2 col-md-offset-1">
                                        <!-- Employee Email -->
                                        <div class="form-group row">
                                            <asp:Label runat="server" CssClass="col-lg-3" ID="lblEmail"><b>Email :</b><span style="color:red">*</span></asp:Label>
                                            <div class="col-lg-6">
                                                <asp:TextBox runat="server" required="required" ValidationGroup="valEmployee" MaxLength="20" Enabled="True" ID="txtEmail" class="form-control input-sm" placeholder="Email Address" />
                                            </div>

                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-4 col-lg-12 my-2 col-md-offset-1">
                                        <!-- Date of birth -->
                                        <div class="form-group row">

                                            <asp:Label runat="server" CssClass="col-lg-3" ID="lbldob"><b>DOB :</b><span style="color:red">*</span></asp:Label>

                                            <div class="col-lg-6">
                                                <asp:TextBox runat="server" required="required" ValidationGroup="valEmployee" MaxLength="20"  TextMode="Date"  Enabled="True" ID="txtdob" class="form-control input-sm" placeholder="DOB " />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-lg-12 my-2 col-md-offset-1">
                                        <div class="form-group row">
                                            <!-- Program -->
                                            <asp:Label runat="server" CssClass="col-lg-3" ID="lblProgram"><b>Program :</b></asp:Label>

                                            <div class="col-lg-6">
                                                <asp:TextBox runat="server" required="required" ValidationGroup="valEmployee" MaxLength="20" Enabled="True" ID="txtProgram" class="form-control input-sm" placeholder="Program" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4 col-lg-12 my-2 col-md-offset-1">
                                        <div class="form-group row">
                                            <!-- Region -->
                                            <asp:Label runat="server" CssClass="col-lg-3" ID="lblRegion"><b>Region :</b><span style="color:red">*</span></asp:Label>

                                            <div class="col-lg-6">
                                                <asp:DropDownList ID="ddlRegion" ValidationGroup="valEmployee" CssClass="form-control input-sm w-auto" runat="server">
                                                    <asp:ListItem Value="">--Select Region--</asp:ListItem>
                                                    <asp:ListItem Text="Pakistan" />
                                                    <asp:ListItem Text="Iran" />
                                                    <asp:ListItem Text="Iraq" />
                                                    <asp:ListItem Text="Turkey" />
                                                    <asp:ListItem Text="India" />
                                                    <asp:ListItem Text="China" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-lg-12 mt-2 col-md-offset-1">
                                        <div class="form-group row">
                                            <!-- Address -->
                                            <asp:Label runat="server" CssClass="col-lg-3" ID="lblAddress"><b>Address :</b><span style="color:red">*</span></asp:Label>

                                            <div class="col-lg-6 mb-2">
                                                <asp:TextBox runat="server" required="required" ValidationGroup="valEmployee" Enabled="True" ID="txtAddress" class="form-control input-sm" placeholder=" Address line 1" />
                                            </div>
                                            <div class="col-lg-6 mt-2 mb-2 offset-lg-3">
                                                <asp:TextBox runat="server" Enabled="True" ID="txtAddress1" class="form-control input-sm" placeholder=" Address line 2" />
                                            </div>
                                            <div class="col-md-4 col-lg-12 col-md-offset-1">
                                                <!-- City state zip -->
                                                <div class="form-group row">
                                                    <div class="col-lg-3"></div>
                                                    <div class="col-lg-3">
                                                        <asp:TextBox runat="server" Enabled="True" ID="txtCity" MaxLength="20" class="my-2 form-control input-sm" placeholder="City" />
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <asp:TextBox runat="server" Enabled="True" ID="txtState" MaxLength="20" class="my-2 form-control input-sm" placeholder="State" />
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <asp:TextBox runat="server" Enabled="True" ID="txtZIP" MaxLength="20" class="my-2 form-control input-sm" placeholder="ZIP" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-4 col-lg-12 my-2 col-md-offset-1">
                                        <div class="form-group row">
                                            <!-- Contact Details -->
                                            <asp:Label runat="server" CssClass="col-lg-3" ID="lblCell"><b>Cell No :</b><span style="color:red">*</span></asp:Label>

                                            <div class="col-lg-6">
                                                <asp:TextBox runat="server" required="required" ValidationGroup="valEmployee" TextMode="Number" Enabled="True" ID="txtCell" MaxLength="20" class="form-control input-sm" placeholder="Cell Number " />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-lg-12 my-2 col-md-offset-1">
                                        <div class="form-group row">
                                            <!-- Gender -->
                                            <asp:Label runat="server" CssClass="col-lg-3" ID="lblGender"><b>Gender :</b><span style="color:red">*</span></asp:Label>

                                            <div class="col-lg-6">
                                                <asp:RadioButtonList CssClass="form-group col-lg-6 " RepeatColumns="4" RepeatDirection="Horizontal" ID="txtGender" ValidationGroup="valEmployee" runat="server">
                                                    <asp:ListItem Text="Male" />
                                                    <asp:ListItem Text="Female" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-lg-12 my-2 col-md-offset-1">
                                        <div class="form-group row">
                                            <!-- Reporting -->
                                            <asp:Label runat="server" CssClass="col-lg-3" ID="lblReporting"><b>Reporting to :</b></asp:Label>

                                            <div class="col-lg-6">
                                                <asp:DropDownList ID="ddlReporting" ValidationGroup="valEmployee" CssClass="form-control input-sm w-auto" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                     <div class="col-md-4 col-lg-12 my-2 col-md-offset-1">
                                        <div class="form-group row">
                                            <!-- Reporting -->
                                            <asp:Label runat="server" CssClass="col-lg-3" ID="lblFileUpload"><b>Add attachment :</b></asp:Label>

                                            <div class="col-lg-6">
                                                <asp:FileUpload ID="FileUpload" runat="server" />
                                                <asp:LinkButton ID="lnkDownload" runat="server" text=""  OnClick="DownloadFile"
                                                    CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                    <UC:ListviewControl runat="server" ID="ListviewControl" />

                                    <div class="row">
                                        <hr />
                                    <div class="col-md-12 col-md-offset-1">
                                        <div class="form-group">
                                            <!-- Buttons -->
                                            <asp:Button Text="Save" ID="btnsave" CssClass="btn btn-primary btn-lg" ValidationGroup="valEmployee" CausesValidation="true" Width="130px" runat="server" OnClick="btnsave_Click" />
                                            <asp:LinkButton ID="lnkCancel" OnClick="btnCancel_Click" CausesValidation="False" UseSubmitBehavior="false" Text="Cancel" runat="server" />
                                           
                                        </div>
                                    </div>

                                </div>

                            </div>
                        </section>

                    </div>
                </div>


                
                </asp:Content>
            
