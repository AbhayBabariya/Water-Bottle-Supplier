<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.master" AutoEventWireup="true" CodeFile="CustomerAddEdit.aspx.cs" Inherits="AdminPanel_Customer_CustomerAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="kt-portlet">
        <div class="kt-portlet">
            <div class="kt-portlet__head kt-portlet__head--noborder  kt-ribbon  kt-ribbon--alert kt-ribbon--left">
                <div class="kt-ribbon__target" style="top: 12px; left: -2px; height: 40px; width: 300px">
                    <span class="kt-ribbon__inner"></span>
                    <asp:Label runat="server" ID="lblPageHeader" />
                </div>
            </div>
        </div>
        <div style="text-align: center">
            <asp:Label runat="server" ID="lblErrorMessage" EnableViewState="false" CssClass="text-dark alert-danger"></asp:Label>
            <asp:Label runat="server" ID="lblMessage" EnableViewState="false" CssClass="text-dark alert-success" />
        </div>
        <!--begin::Form-->
        <div class="kt-portlet__body">
            <div class="form-group row">
                <div class="col-lg-6">
                    <label for="txtCustomerName" class="col-sm-6 col-form-label">Customer Name</label>
                    <div class="kt-input-icon">
                        <asp:TextBox runat="server" ID="txtCustomerName" CssClass="form-control" placeholder="Enter Customer Name" />
                        <span class="kt-input-icon__icon kt-input-icon__icon--right"><span><i class="la la-user"></i></span></span>
                        <asp:RequiredFieldValidator runat="server" ID="rfvCustomerName" ControlToValidate="txtCustomerName" Display="Dynamic" ErrorMessage="Enter Customer Name" ForeColor="Red" ValidationGroup="Customer" />
                    </div>
                </div>
                <div class="col-lg-6">
                    <label for="txtCustomerName" class="col-sm-6 col-form-label">Mobile No</label>
                    <div class="kt-input-icon">
                        <asp:TextBox runat="server" ID="txtMobileNo" CssClass="form-control" MaxLength="10" aria-describedby="basic-addon1" placeholder="Enter Mobile No" />
                        <span class="kt-input-icon__icon kt-input-icon__icon--right"><span><i class="la la-phone"></i></span></span>
                        <asp:RequiredFieldValidator runat="server" ID="rfvMobileNo" ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Enter Mobile No" ForeColor="Red" ValidationGroup="Customer" />
                    </div>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-lg-12">
                    <label for="txtCustomerName" class="col-sm-6 col-form-label">Address</label>
                    <div class="kt-input-icon">
                        <asp:TextBox runat="server" ID="txtCustomerAddress" CssClass="form-control" Placeholder="Enter CustomerAddress" />
                        <span class="kt-input-icon__icon kt-input-icon__icon--right"><span><i class="la la-map-marker"></i></span></span>
                        <asp:RequiredFieldValidator runat="server" ID="rfvCustomerAddress" ControlToValidate="txtCustomerAddress" Display="Dynamic" ErrorMessage="Enter CustomerAddress" ForeColor="Red" ValidationGroup="Customer" />
                    </div>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-md-4">
                    <label for="txtBranchName" class="col-sm-6 col-form-label">Branch</label>
                    <div>
                        <asp:DropDownList runat="server" ID="ddlBranchID" CssClass="dropdown bootstrap-select form-control kt- kt-selectpicker" AutoPostBack="true" placeholder="Select Branch" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" data-live-search="true">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="rfvBranch" ControlToValidate="ddlBranchID" Display="Dynamic" ErrorMessage="Select Branch" ForeColor="Red" ValidationGroup="Customer" />
                    </div>
                </div>
                <div class="col-md-4">
                    <label for="txtCustomerName" class="col-sm-6 col-form-label">Distributor</label>
                    <div>
                        <asp:DropDownList runat="server" ID="ddlDistributorID" CssClass="dropdown bootstrap-select form-control kt- kt-selectpicker" placeholder="Select Product" AutoPostBack="true" data-live-search="true"></asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="rfvDistributor" ControlToValidate="ddlDistributorID" Display="Dynamic" ErrorMessage="Select Distributor" ForeColor="Red" ValidationGroup="Customer" />
                    </div>
                </div>
                <div class="col-md-4">
                    <label for="txtCustomerName" class="col-sm-6 col-form-label">Product</label>
                    <div>
                        <asp:DropDownList runat="server" ID="ddlProductID" CssClass="dropdown bootstrap-select form-control kt- kt-selectpicker" placeholder="Select Product" AutoPostBack="true" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged" data-live-search="true"></asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="rfvWaterInLiter" ControlToValidate="ddlProductID" Display="Dynamic" ErrorMessage="Select Product" ForeColor="Red" ValidationGroup="Customer" />
                    </div>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-lg-6">
                    <label for="txtCustomerName" class="col-sm-6 col-form-label">Quantity</label>
                    <div class="kt-input-icon">
                        <asp:TextBox runat="server" ID="txtQuantity" CssClass="form-control" AutoPostBack="true" placeholder="Enter Quantity" />
                        <span class="kt-input-icon__icon kt-input-icon__icon--right"><span><i class="la la-list-ul"></i></span></span>
                        <asp:RequiredFieldValidator runat="server" ID="rfvQuantity" ControlToValidate="txtQuantity" Display="Dynamic" ErrorMessage="Enter Quantity" ForeColor="Red" ValidationGroup="Customer" />
                    </div>
                </div>
                <div class="col-lg-6">
                    <label for="txtCustomerName" class="col-sm-6 col-form-label">Amount</label>
                    <div class="kt-input-icon">
                        <asp:TextBox runat="server" ID="txtAmount" CssClass="form-control" AutoPostBack="true" placeholder="Enter Amount" EnableTheming="False" EnableViewState="False" />
                        <span class="kt-input-icon__icon kt-input-icon__icon--right"><span><i class="la la-rupee"></i></span></span>
                        <asp:RequiredFieldValidator runat="server" ID="rfvAmount" ControlToValidate="txtAmount" Display="Dynamic" ErrorMessage="Enter Price Of One Bottle" ForeColor="Red" ValidationGroup="Customer" />
                    </div>
                </div>
            </div>

            <div class="form-group row">
                <div class="col-sm-10"></div>
                <div class="col-sm-2 pull-right">
                    <asp:Button runat="server" ID="btnSave" Text="Save" ValidationGroup="Customer" CssClass="btn btn-primary pull-right" OnClick="btnSave_Click" />&nbsp;
                <asp:HyperLink runat="server" ID="hlCancel" Text="Cancel" NavigateUrl="~/AdminPanel/Customer/CustomerList.aspx" CssClass="btn btn-danger" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

