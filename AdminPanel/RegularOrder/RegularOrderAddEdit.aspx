<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.master" AutoEventWireup="true" CodeFile="RegularOrderAddEdit.aspx.cs" Inherits="AdminPanel_RegularOrder_RegularOrderAddEdit" %>

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
                <div class="col-md-9">
                    <label for="txtRegularOrder" class="col-sm-2 col-form-label">Customer Name</label>
                    <asp:DropDownList runat="server" ID="ddlCustomerID" CssClass="dropdown bootstrap-select form-control kt- kt-selectpicker" placeholder="Select Customer" AutoPostBack="true" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged" data-live-search="true"></asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ID="rfvCustomer" ControlToValidate="ddlCustomerID" Display="Dynamic" ErrorMessage="Select Customer" ForeColor="Red" ValidationGroup="RegularOrder" />
                </div>
                <div class="col-md-3">
                    <label for="txtRegularOrder" class="col-sm-6 col-form-label">Order Date</label>
                    <div class="kt-input-icon input-group date input-group-append">
                        <asp:TextBox runat="server" ID="txtOrderDate" TextMode="Date" CssClass="form-control" placeholder="Enter OrderDate" />
                        <span class="input-group-text"><i class="la la-calendar-check-o"></i></span>
                    </div>
                    <asp:RequiredFieldValidator runat="server" ID="rfvReturnDate" ControlToValidate="txtOrderDate" Display="Dynamic" ErrorMessage="Enter Return Date" ForeColor="Red" ValidationGroup="RegularOrder" />
                </div>
            </div>
            <div class="form-group row">
                <div class="col-md-4">
                    <label for="txtRegularOrder" class="col-sm-6 col-form-label">Branch Name</label>
                    <div>
                        <asp:DropDownList runat="server" ID="ddlBranchID" CssClass="dropdown bootstrap-select form-control kt- kt-selectpicker" AutoPostBack="true" placeholder="Select Branch" data-live-search="true">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="rfvBranchName" ControlToValidate="ddlBranchID" Display="Dynamic" ErrorMessage="Select Branch" ForeColor="Red" ValidationGroup="Customer" />
                    </div>
                </div>
                <div class="col-md-4">
                    <label for="txtRegularOrder" class="col-sm-6 col-form-label">Distributor Name</label>
                    <div>
                        <asp:DropDownList runat="server" ID="ddlDistributorID" CssClass="dropdown bootstrap-select form-control kt- kt-selectpicker" AutoPostBack="true" placeholder="Select Distributor" data-live-search="true">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="rfvDistributor" ControlToValidate="ddlDistributorID" Display="Dynamic" ErrorMessage="Select Distributor" ForeColor="Red" ValidationGroup="Customer" />
                    </div>
                </div>
                <div class="col-md-4">
                    <label for="txtRegularOrder" class="col-sm-6 col-form-label">Product</label>
                    <div>
                        <asp:DropDownList runat="server" ID="ddlProductID" CssClass="dropdown bootstrap-select form-control kt- kt-selectpicker" AutoPostBack="true" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged" placeholder="Select Product" data-live-search="true">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="rfvProduct" ControlToValidate="ddlProductID" Display="Dynamic" ErrorMessage="Select Product" ForeColor="Red" ValidationGroup="RegularOrder" />
                    </div>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-md-3">
                    <label for="txtRegularOrder" class="col-sm-6 col-form-label">Quantity</label>
                    <div class="kt-input-icon">
                        <asp:TextBox runat="server" ID="txtQuantity" CssClass="form-control" AutoPostBack="true" onkeyup="Total(This,txtPriceOfOneBottle,txtTotalPrice)" onkeyPress="return isNumberKey(event)" OnTextChanged="txtQuantity_TextChanged" placeholder="Enter Quantity" />
                        <span class="kt-input-icon__icon kt-input-icon__icon--right"><span><i class="la la-list-ul"></i></span></span>
                        <asp:RequiredFieldValidator runat="server" ID="rfvQuantity" ControlToValidate="txtQuantity" Display="Dynamic" ErrorMessage="Enter Quantity" ForeColor="Red" ValidationGroup="RegularOrder" />
                    </div>
                </div>
                <div class="col-md-3">
                    <label for="txtRegularOrder" class="col-sm-6 col-form-label">Amount</label>
                    <div class="kt-input-icon">
                        <asp:TextBox runat="server" ID="txtAmount" CssClass="form-control" AutoPostBack="true" onkeyup="Total(This,txtQuantity,txtTotalPrice)" onkeyPress="return isNumberKey(event)" OnTextChanged="txtBottleAmount_TextChanged" placeholder="Enter Amount" />
                        <span class="kt-input-icon__icon kt-input-icon__icon--right"><span><i class="la la-rupee"></i></span></span>
                        <asp:RequiredFieldValidator runat="server" ID="rfvAmount" ControlToValidate="txtAmount" Display="Dynamic" ErrorMessage="Enter Amount" ForeColor="Red" ValidationGroup="RegularOrder" />
                    </div>
                </div>
                <div class="col-md-3">
                    <label for="txtRegularOrder" class="col-sm-6 col-form-label">Total Amount</label>
                    <div class="kt-input-icon">
                        <asp:TextBox runat="server" ID="txtTotalAmount" CssClass="form-control" AutoPostBack="true" placeholder="Enter Total Amount" />
                        <span class="kt-input-icon__icon kt-input-icon__icon--right"><span><i class="la la-rupee"></i></span></span>
                        <asp:RequiredFieldValidator runat="server" ID="rfvTotalAmount" ControlToValidate="txtTotalAmount" Display="Dynamic" ErrorMessage="Enter Total Amount" ForeColor="Red" ValidationGroup="RegularOrder" />
                    </div>
                </div>
                <div class="col-md-3">
                    <label for="txtRegularOrder" class="col-sm-6 col-form-label">Bottle In</label>
                    <div class="kt-input-icon">
                        <asp:TextBox runat="server" ID="txtBottleIn" CssClass="form-control" placeholder="Enter Bottle" />
                        <span class="kt-input-icon__icon kt-input-icon__icon--right"><span><i class="la la-caret-square-o-left"></i></span></span>
                        <asp:RequiredFieldValidator runat="server" ID="rfvBottleIn" ControlToValidate="txtBottleIn" Display="Dynamic" ErrorMessage="Enter Bottle In" ForeColor="Red" ValidationGroup="RegularOrder" />
                    </div>
                </div>
            </div>

            <div class="form-group row">
                <div class="col-sm-10"></div>
                <div class="col-sm-2 pull-right">
                    <asp:Button runat="server" ID="btnSave" Text="Save" ValidationGroup="RegularOrder" CssClass="btn btn-primary pull-right" OnClick="btnSave_Click" />&nbsp;
                <asp:HyperLink runat="server" ID="hlCancel" Text="Cancel" NavigateUrl="~/AdminPanel/RegularOrder/RegularOrderList.aspx" CssClass="btn btn-danger" />
                </div>
            </div>
        </div>

    </div>
</asp:Content>

