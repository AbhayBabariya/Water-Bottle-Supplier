<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.master" AutoEventWireup="true" CodeFile="BranchAddEdit.aspx.cs" Inherits="Admin_Panel_Branch_BranchAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- begin:: Content -->
    <%--<div class="kt-container  kt-container--fluid  kt-grid__item kt-grid__item--fluid">
        <div class="row">
            <div class="col-md-12">
                <!--begin::Portlet-->--%>
    <div class="kt-portlet">
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
                <asp:Label runat="server" ID="lblMessage" EnableViewState="False" CssClass="text-dark alert-success" ForeColor="Black" />
            </div>
            <!--begin::Form-->
            <div class="kt-portlet__body">
                <div class="form-group row">
                    <div class="col-lg-6">
                        <label for="txtBranchName" class="col-sm-6 col-form-label">Branch Name</label>
                        <div class="kt-input-icon">
                            <asp:TextBox runat="server" ID="txtBranchName" CssClass="form-control" placeholder="Enter Branch Name" />
                            <span class="kt-input-icon__icon kt-input-icon__icon--right"><span><i class="la la-random"></i></span></span>
                            <asp:RequiredFieldValidator runat="server" ID="rfvBranchName" ControlToValidate="txtBranchName" Display="Dynamic" ErrorMessage="Enter Branch Name" ForeColor="Red" ValidationGroup="Branch" />
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <label for="txtBranchName" class="col-sm-6 col-form-label">Mobile No</label>
                        <div class="kt-input-icon">
                            <asp:TextBox runat="server" ID="txtMobileNo" CssClass="form-control" MaxLength="10" aria-describedby="basic-addon1" placeholder="Enter Mobile No" />
                            <span class="kt-input-icon__icon kt-input-icon__icon--right"><span><i class="la la-phone"></i></span></span>
                            <asp:RequiredFieldValidator runat="server" ID="rfvMobileNo" ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Enter Mobile No" ForeColor="Red" ValidationGroup="Branch" />
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-md-12">
                        <label for="txtBranchName" class="col-sm-6 col-form-label">Branch Address</label>
                        <div class="kt-input-icon">
                            <asp:TextBox runat="server" ID="txtBranchAddress" CssClass="form-control" placeholder="Enter Branch Address" />
                            <span class="kt-input-icon__icon kt-input-icon__icon--right"><span><i class="la la-map-marker"></i></span></span>
                            <asp:RequiredFieldValidator runat="server" ID="rfvBranchAddress" ControlToValidate="txtBranchAddress" Display="Dynamic" ErrorMessage="Enter Branch Address" ForeColor="Red" ValidationGroup="Branch" />
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-lg-6">
                        <label for="txtBranchName" class="col-sm-6 col-form-label">Manager Name</label>
                        <div class="kt-input-icon">
                            <asp:TextBox runat="server" ID="txtManagerName" CssClass="form-control" placeholder="Enter Branch Name" />
                            <span class="kt-input-icon__icon kt-input-icon__icon--right"><span><i class="la la-user"></i></span></span>
                            <asp:RequiredFieldValidator runat="server" ID="rfvManagerName" ControlToValidate="txtManagerName" Display="Dynamic" ErrorMessage="Enter Manager Name" ForeColor="Red" ValidationGroup="Branch" />
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <label for="txtBranchName" class="col-sm-6 col-form-label">Manager Mobile No</label>
                        <div class="kt-input-icon">
                            <asp:TextBox runat="server" ID="txtManagerMobileNo" CssClass="form-control" MaxLength="10" placeholder="Enter Mobile No" />
                            <span class="kt-input-icon__icon kt-input-icon__icon--right"><span><i class="la la-phone"></i></span></span>
                            <asp:RequiredFieldValidator runat="server" ID="rfvManagerMobileNo" ControlToValidate="txtManagerMobileNo" Display="Dynamic" ErrorMessage="Enter Manager Mobile No" ForeColor="Red" ValidationGroup="Branch" />
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-10"></div>
                    <div class="col-sm-2 pull-right">
                        <asp:Button runat="server" ID="btnSave" Text="Save" ValidationGroup="BranchManager" CssClass="btn btn-primary pull-right" OnClick="btnSave_Click" />&nbsp;
                <asp:HyperLink runat="server" ID="hlCancel" Text="Cancel" NavigateUrl="~/AdminPanel/Branch/BranchList.aspx" CssClass="btn btn-danger" />
                    </div>
                </div>
                <!--end::Form-->
            </div>
        </div>
    </div>
    <!--end::Portlet-->
</asp:Content>

