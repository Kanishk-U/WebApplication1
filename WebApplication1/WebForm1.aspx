<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Basic Web Form</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
</head>
<body>
    
        <section id="main-content">
            <section class="wrapper justify-content-center" >
                <form id="form1" runat="server">
                <div class="row">
                    <div class="col-lg-12">
                        <section class="panel">
                            <header class="panel-heading">
                                <div class="col-md-4 col-md-offset-4">
                                    <h1>Employee Registration</h1>
                                </div>

                            </header>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-4 col-md-offset-1">
                                        <div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="EmpName"><b>Employee Name</b></asp:Label><br />
                                            <asp:TextBox runat="server" required="required" Enabled="True" name="BrandName" ID="EmpName" class="form-control input-sm" placeholder="Employee Name"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-4 col-md-offset-1">
                                        <div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="txtfname"><b>Father Name</b></asp:Label><br />
                                            <asp:TextBox runat="server" required="required" Enabled="True" name="BrandName" ID="txtfname" class="form-control input-sm" placeholder="Father Name"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-4 col-md-offset-1">
                                        <div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="txtdob"><b>DOB</b></asp:Label><br />
                                            <asp:TextBox runat="server" required="required" TextMode="Date" Enabled="True" name="BrandName" ID="txtdob" class="form-control input-sm" placeholder="DOB "></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-md-offset-1">
                                        <div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="txtprogram"><b>Program</b></asp:Label><br />
                                            <asp:TextBox runat="server" required="required" Enabled="True" name="BrandName" ID="txtprogram" class="form-control input-sm" placeholder="Program"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4 col-md-offset-1">
                                        <div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="ddlRegion"><b>Region</b></asp:Label><br />
                                            <asp:DropDownList ID="ddlRegion" CssClass="form-control input-sm" runat="server">
                                                <asp:ListItem Text="Pakistan" />
                                                <asp:ListItem Text="Iran" />
                                                <asp:ListItem Text="Iraq" />
                                                <asp:ListItem Text="Turkey" />
                                                <asp:ListItem Text="India" />
                                                <asp:ListItem Text="China" />
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-md-offset-1">
                                        <div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="txtaddress"><b>Address</b></asp:Label><br />
                                            <asp:TextBox runat="server" required="required" Enabled="True" name="BrandName" ID="txtaddress" class="form-control input-sm" placeholder=" Address "></asp:TextBox>

                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-4 col-md-offset-1">
                                        <div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="txtcell"><b>Cell No</b></asp:Label><br />
                                            <asp:TextBox runat="server" required="required" TextMode="Number" Enabled="True" name="BrandName" ID="txtcell" class="form-control input-sm" placeholder="Cell Number "></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-md-offset-1">
                                        <div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="txtgender"><b>Gender</b></asp:Label><br />
                                            <asp:RadioButtonList CssClass="form-group" ID="txtgender" runat="server">
                                                <asp:ListItem Text="Male" />
                                                <asp:ListItem Text="Female" />
                                            </asp:RadioButtonList>

                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-10 col-md-offset-1">
                                        <div class="form-group">
                                            <asp:Button Text="Save" ID="btnsave"  CssClass="btn btn-primary btn-lg"  Width="220px" runat="server" />
                                            <asp:Button Text="Update" ID="btnupdate"  CssClass="btn btn-primary btn-lg" Width="220px" runat="server" />
                                            <asp:Button Text="Delete" ID="btndlt"  CssClass="btn btn-danger btn-lg" Width="220px" runat="server" />
                                            <asp:Label Text="" ForeColor="Green" Font-Bold="true" ID="lblmessage" CssClass="label label-success" runat="server" />
                                        </div>
                                    </div>

                                </div>

                            </div>
                        </section>
                    </div>
                </div>
                </form>
                <br />  
                <br /> 
    <asp:Label ID="Label1" runat="server"></asp:Label>  
            </section>
        </section>

</body>
</html>