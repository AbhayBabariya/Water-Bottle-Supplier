<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.master" AutoEventWireup="true" CodeFile="DistributorAddEdit.aspx.cs" Inherits="AdminPanel_Distributor_DistributorAddEdit" %>

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
            <asp:Label runat="server" ID="lblMessage" EnableViewState="False" CssClass="text-dark alert-success" />
        </div>
        <!--begin::Form-->
        <div class="kt-portlet__body">
            <div class="form-group row">
                <label for="txtDistributorName" class="col-sm-6 col-form-label">Branch</label>
                <asp:DropDownList runat="server" ID="ddlBranchID" CssClass="dropdown bootstrap-select form-control kt- kt-selectpicker" placeholder="Select Branch" data-live-search="true">
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="rfvBranch" ControlToValidate="ddlBranchID" Display="Dynamic" ErrorMessage="Select Branch" ForeColor="Red" ValidationGroup="Distributor" />
            </div>
            <div class="form-group row">
                <div class="col-lg-6">
                    <label for="txtDistributorName" class="col-sm-6 col-form-label">Distributor Name</label>
                    <div class="kt-input-icon">
                        <asp:TextBox runat="server" ID="txtDistributorName" CssClass="form-control" placeholder="Enter Distributor Name" />
                        <span class="kt-input-icon__icon kt-input-icon__icon--right"><span><i class="la la-user"></i></span></span>
                        <asp:RequiredFieldValidator runat="server" ID="rfvDistributorName" ControlToValidate="txtDistributorName" Display="Dynamic" ErrorMessage="Enter Distributor Name" ForeColor="Red" ValidationGroup="Distributor" />
                    </div>
                </div>
                <div class="col-lg-6">
                    <label for="txtDistributorName" class="col-sm-6 col-form-label">Mobile No</label>
                    <div class="kt-input-icon">
                        <asp:TextBox runat="server" ID="txtMobileNo" CssClass="form-control" MaxLength="10" aria-describedby="basic-addon1" placeholder="Enter Mobile No" />
                        <span class="kt-input-icon__icon kt-input-icon__icon--right"><span><i class="la la-phone"></i></span></span>
                        <asp:RequiredFieldValidator runat="server" ID="rfvMobileNo" ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Enter Mobile No" ForeColor="Red" ValidationGroup="Distributor" />
                    </div>
                </div>
            </div>

            <div class="form-group row">
                <div class="col-lg-6">
                    <label for="txtDistributorName" class="col-sm-6 col-form-label">Vehicle Type</label>
                    <div class="kt-input-icon">
                        <asp:TextBox runat="server" ID="txtVehicleType" CssClass="form-control" placeholder="Enter Vehicle Type" />
                        <span class="kt-input-icon__icon kt-input-icon__icon--right"><span><i class="la la-truck"></i></span></span>
                        <asp:RequiredFieldValidator runat="server" ID="rfvVehicleType" ControlToValidate="txtVehicleType" Display="Dynamic" ErrorMessage="Enter Vehicale Type" ForeColor="Red" ValidationGroup="Distributor" />
                    </div>
                </div>
                <div class="col-lg-6">
                    <label for="txtDistributorName" class="col-sm-6 col-form-label">Vehicle No</label>
                    <div class="kt-input-icon">
                        <asp:TextBox runat="server" ID="txtVehicleNo" CssClass="form-control" placeholder="Enter Mobile No" />
                        <span class="kt-input-icon__icon kt-input-icon__icon--right"><span><i class="la la-pencil-square"></i></span></span>
                        <asp:RequiredFieldValidator runat="server" ID="rfvVehicleNo" ControlToValidate="txtVehicleNo" Display="Dynamic" ErrorMessage="Enter Vehical No" ForeColor="Red" ValidationGroup="Distributor" />
                    </div>
                </div>
            </div>

            <div class="form-group row">
                <div class="col-sm-10"></div>
                <div class="col-sm-2 pull-right">
                    <asp:Button runat="server" ID="btnSave" Text="Save" ValidationGroup="Distributor" CssClass="btn btn-primary pull-right" OnClick="btnSave_Click" />&nbsp;
                <asp:HyperLink runat="server" ID="hlCancel" Text="Cancel" NavigateUrl="~/AdminPanel/Distributor/DistributorList.aspx" CssClass="btn btn-danger" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

