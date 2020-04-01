<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.master" AutoEventWireup="true" CodeFile="OccasionallyOrderAddEdit.aspx.cs" Inherits="AdminPanel_OccasionallyOrder_OccasionallyOrderAddEdit" %>

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
                <div class="col-md-4">
                    <label for="txtOrderDate" class="col-sm-6 col-form-label">Order Date</label>
                    <div class="kt-input-icon input-group date">
                        <asp:TextBox runat="server" ID="txtOrderDate" TextMode="Date" CssClass="form-control" placeholder="Enter OrderDate" />
                        <div class="input-group-append">
                            <span class="input-group-text"><i class="la la-calendar-check-o"></i></span>
                        </div>
                    </div>
                    <asp:RequiredFieldValidator runat="server" ID="rfvReturnDate" ControlToValidate="txtOrderDate" Display="Dynamic" ErrorMessage="Enter Return Date" ForeColor="Red" ValidationGroup="Customer" />
                </div>
                <div class="col-md-4">
                    <label for="txtCustomerName" class="col-sm-6 col-form-label">Customer Name</label>
                    <div class="kt-input-icon">
                        <asp:TextBox runat="server" ID="txtCustomerName" CssClass="form-control" placeholder="Enter Customer Name" />
                        <span class="kt-input-icon__icon kt-input-icon__icon--right"><span><i class="la la-user"></i></span></span>
                        <asp:RequiredFieldValidator runat="server" ID="rfvCustomerName" ControlToValidate="txtCustomerName" Display="Dynamic" ErrorMessage="Enter Customer Name" ForeColor="Red" ValidationGroup="Customer" />
                    </div>
                </div>
                <div class="col-md-4">
                    <label for="txtCustomerName" class="col-sm-6 col-form-label">Mobile No</label>
                    <div class="kt-input-icon">
                        <asp:TextBox runat="server" ID="txtMobileNo" CssClass="form-control" MaxLength="10" aria-describedby="basic-addon1" placeholder="Enter Mobile No" />
                        <span class="kt-input-icon__icon kt-input-icon__icon--right"><span><i class="la la-phone"></i></span></span>
                        <asp:RequiredFieldValidator runat="server" ID="rfvMobileNo" ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Enter Mobile No" ForeColor="Red" ValidationGroup="Customer" />
                    </div>
                </div>
            </div>
            <div class="form-group row">
                <label for="txtCustomerName" class="col-sm-6 col-form-label">Address</label>
                <div class="kt-input-icon">
                    <asp:TextBox runat="server" ID="txtCustomerAddress" CssClass="form-control" placeholder="Enter CustomerAddress" />
                    <span class="kt-input-icon__icon kt-input-icon__icon--right"><span><i class="la la-map-marker"></i></span></span>
                    <asp:RequiredFieldValidator runat="server" ID="rfvCustomerAddress" ControlToValidate="txtCustomerAddress" Display="Dynamic" ErrorMessage="Enter CustomerAddress" ForeColor="Red" ValidationGroup="Customer" />
                </div>
            </div>
            <div class="form-group row">
                <div class="col-md-4">
                    <label for="txtCityName" class="col-sm-6 col-form-label">Branch Name</label>
                    <div>
                        <asp:DropDownList runat="server" ID="ddlBranchID" CssClass="dropdown bootstrap-select form-control kt- kt-selectpicker" AutoPostBack="true" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" placeholder="Select Distributor" data-live-search="true"></asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="rfvBranchName" ControlToValidate="ddlBranchID" Display="Dynamic" ErrorMessage="Select Branch" ForeColor="Red" ValidationGroup="Customer" />
                    </div>
                </div>
                <div class="col-md-4">
                    <label for="txtCityName" class="col-sm-6 col-form-label">Distributor Name</label>
                    <div>
                        <asp:DropDownList runat="server" ID="ddlDistributorID" CssClass="dropdown bootstrap-select form-control kt- kt-selectpicker" placeholder="Select Distributor" data-live-search="true"></asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="rfvDistributor" ControlToValidate="ddlDistributorID" Display="Dynamic" ErrorMessage="Select Distributor" ForeColor="Red" ValidationGroup="Customer" />
                    </div>
                </div>
                <div class="col-md-4">
                    <label for="txtCustomerName" class="col-sm-6 col-form-label">Prodduct</label>
                    <div>
                        <asp:DropDownList runat="server" ID="ddlProductID" CssClass="dropdown bootstrap-select form-control kt- kt-selectpicker" placeholder="Select Water In Liter" AutoPostBack="true" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged" data-live-search="true"></asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="rfvProduct" ControlToValidate="ddlProductID" Display="Dynamic" ErrorMessage="Select Product" ForeColor="Red" ValidationGroup="Customer" />
                    </div>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-md-3">
                    <label for="txtCustomerName" class="col-sm-6 col-form-label">Quantity</label>
                    <div class="kt-input-icon">
                        <asp:TextBox runat="server" ID="txtQuantity" CssClass="form-control" AutoPostBack="true" onkeyup="Total(This,txtPriceOfOneBottle,txtTotalPrice)" onkeyPress="return isNumberKey(event)" OnTextChanged="txtQuantity_TextChanged" placeholder="Enter Quantity" />
                        <span class="kt-input-icon__icon kt-input-icon__icon--right"><span><i class="la la-list-ul"></i></span></span>
                        <asp:RequiredFieldValidator runat="server" ID="rfvQuantity" ControlToValidate="txtQuantity" Display="Dynamic" ErrorMessage="Enter Quantity" ForeColor="Red" ValidationGroup="Customer" />
                    </div>
                </div>
                <div class="col-md-3">
                    <label for="txtCustomerName" class="col-sm-6 col-form-label">Amount</label>
                    <div class="kt-input-icon">
                        <asp:TextBox runat="server" ID="txtAmount" CssClass="form-control" AutoPostBack="true" onkeyup="Total(This,txtQuantity,txtTotalPrice)" onkeyPress="return isNumberKey(event)" OnTextChanged="txtBottleAmount_TextChanged" placeholder="Enter Bottle Amount" EnableTheming="False" />
                        <span class="kt-input-icon__icon kt-input-icon__icon--right"><span><i class="la la-rupee"></i></span></span>
                        <asp:RequiredFieldValidator runat="server" ID="rfvAmount" ControlToValidate="txtAmount" Display="Dynamic" ErrorMessage="Enter Bottle Amount" />
                    </div>
                </div>
                <div class="col-md-3">
                    <label for="txtCustomerName" class="col-sm-6 col-form-label">Total Amount</label>
                    <div class="kt-input-icon">
                        <asp:TextBox runat="server" ID="txtTotalAmount" CssClass="form-control" AutoPostBack="true" ReadOnly="True" placeholder="Enter TotalAmount" />
                        <span class="kt-input-icon__icon kt-input-icon__icon--right"><span><i class="la la-rupee"></i></span></span>
                        <asp:RequiredFieldValidator runat="server" ID="rfvTotalAmount" ControlToValidate="txtTotalAmount" Display="Dynamic" ErrorMessage="Enter Total Amount" />
                    </div>
                </div>
                <div class="col-md-3">
                    <label for="txtBottleIn" class="col-sm-6 col-form-label">Bottle In</label>
                    <div class="kt-input-icon">
                        <asp:TextBox runat="server" ID="txtBottleIn" CssClass="form-control" placeholder="Enter Bottle In" />
                        <span class="kt-input-icon__icon kt-input-icon__icon--right"><span><i class="la la-caret-square-o-left"></i></span></span>
                    </div>
                </div>
            </div>

            <div class="form-group row">
                <div class="form-check">
                    <asp:CheckBox ID="ckbStatus" runat="server" />
                    <label class="form-check-label" for="ckbStatus">Advance Payment</label>
                </div>
            </div>

            <div class="form-group row">
                <div class="col-sm-10"></div>
                <div class="col-sm-2 pull-right">
                    <asp:Button runat="server" ID="btnSave" Text="Save" ValidationGroup="Customer" CssClass="btn btn-primary pull-right" OnClick="btnSave_Click" />&nbsp;
                <asp:HyperLink runat="server" ID="hlCancel" Text="Cancel" NavigateUrl="~/AdminPanel/OccasionallyOrder/OccasionallyOrderList.aspx" CssClass="btn btn-danger" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

