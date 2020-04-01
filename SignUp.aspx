<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="~/Content/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/assets/css/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="~/Content/assets/js/bootstrap.min.js"></script>
</head>
<body class="img-responsive" style="background-image: url(Content/assets/media/bg/3.jpeg)">
    <form id="form1" runat="server">
        <div class="container" style="padding-top: 10px;">
            <div class="row">
                <div class="col-md-12" style="text-align: center; font-style: italic">
                    <h1>
                        <asp:Label runat="server" ID="lblPageHeader" />Water Bottle Supplier
                        <br />
                    </h1>
                    <asp:Label runat="server" ID="lblMessage" EnableViewState="false" /><br />
                </div>
            </div>
            <hr />
            <div>
                <h2>
                    <asp:Label runat="server" ID="lblSignUp" />Sign Up
                </h2>
            </div>
            <asp:Label runat="server" ID="lblError" EnableViewState="false"></asp:Label>
            <br />
            <br />
            <div class="">
                <div class="form-group row">
                    <div class="col-sm-4">
                        <label for="lblUserName" style="font-weight: bold">UserName</label>
                        <div>
                            <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" placeholder="Enter UserName" />
                            <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName" Display="Dynamic" ForeColor="Red" ErrorMessage="Enter UserName" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-md-4">
                        <label for="lblMobileNo" style="font-weight: bold">Mobile No</label>
                        <div>
                            <asp:TextBox runat="server" ID="txtMobileNo" CssClass="form-control" placeholder="Enter Password" />
                            <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ControlToValidate="txtMobileNo" Display="Dynamic" ForeColor="Red" ErrorMessage="Enter Mobile No" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-4">
                        <label for="lblEmailId" style="font-weight: bold">Email Id</label>
                        <div>
                            <asp:TextBox runat="server" ID="txtEmailId" CssClass="form-control" placeholder="Enter Email Id" />
                            <asp:RequiredFieldValidator ID="rfvEmailId" runat="server" ControlToValidate="txtEmailId" Display="Dynamic" ForeColor="Red" ErrorMessage="Enter Email Id" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-md-4">
                        <label for="lblPassword" style="font-weight: bold">Password</label>
                        <div>
                            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" placeholder="Enter Password" />
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ForeColor="Red" ErrorMessage="Enter Password" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-4">
                        <div class="pull-right">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button runat="server" ID="btnLogin" Text="Sign Up" ValidationGroup="SignUp" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
                            <asp:Button runat="server" ID="hlClear" Text="Clear" ValidationGroup="SignUp" CssClass="btn btn-danger" />
                        </div>
                    </div>
                </div>
                <div>
                    <label for="lblMessage" style="font-weight: bold">
                        Already have a account ? 
                        <asp:HyperLink runat="server" ID="hlSignin" Text="Sign In" NavigateUrl="~/Login.aspx" ForeColor="Red" />
                    </label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
