<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="LogIn" %>

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
                <div class="col-md-12">
                    <h1>
                        <asp:Label runat="server" ID="lblPageHeader" />Water Bottle Supplier
                        <br />
                    </h1>
                    <asp:Label runat="server" ID="lblMessage" EnableViewState="false" /><br />
                </div>
            </div>
            <hr />
            <div class="form-group row">
                <label for="lblUserName" class="col-sm-2 col-from-label" style="font-weight: bold">UserName</label>
                <div class="col-sm-4">
                    <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" placeholder="Enter UserName" />
                    <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName" Display="Dynamic" ForeColor="Red" ErrorMessage="Enter UserName" ValidationGroup="User"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group row">
                <label for="lblPassword" class="col-sm-2 col-from-label" style="font-weight: bold">Password</label>
                <div class="col-sm-4">
                    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" placeholder="Enter Password" />
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ForeColor="Red" ErrorMessage="Enter Password" ValidationGroup="User"></asp:RequiredFieldValidator>
                </div>
            </div>
            <br />
            <div class="form-group row">
                <div class="col-sm-4">
                    <div class="col-sm-8 pull-right">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnLogin" Text="Login" ValidationGroup="User" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
                        <asp:Button runat="server" ID="hlClear" Text="Clear" ValidationGroup="User" CssClass="btn btn-danger" />
                        &nbsp;&nbsp;
                    </div>
                </div>
            </div>
            <br />
            <div>
                <label for="lblMessage" class="col-sm-6 col-from-label" style="font-weight: bold">
                    No have a account ? 
                        <asp:HyperLink runat="server" ID="hlSignUp" Text="Sign Up" NavigateUrl="~/SignUp.aspx" />
                </label>
            </div>
        </div>
    </form>
</body>
</html>
