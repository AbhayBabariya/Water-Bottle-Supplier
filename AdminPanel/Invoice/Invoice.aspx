<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.master" AutoEventWireup="true" CodeFile="Invoice.aspx.cs" Inherits="AdminPanel_Invoice_Invoice" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="kt-container  kt-container--fluid  kt-grid__item kt-grid__item--fluid">
        <div class="kt-portlet kt-portlet--mobile">
            <div class="kt-portlet__head kt-portlet__head--lg">
                <div class="kt-portlet__head-label">
                    <span class="kt-portlet__head-icon">
                        <i class="kt-font-brand flaticon2-line-chart"></i>
                    </span>
                    <h3 class="kt-portlet__head-title">Invoice
                    </h3>
                </div>
            </div>
            <asp:Label runat="server" ID="lblMessage" CssClass="text-dark alert-danger" EnableViewState="false" />

            <div class="kt-portlet__body">
                <!--begin: Search Form -->
                <div class="kt-form kt-form--label-right kt-margin-t-20 kt-margin-b-10">
                    <div class="row align-items-center">
                        <div class="col-md-12 order-2 order-xl-1">
                            <div class="row align-items-center">
                                <div class="col-md-3 kt-margin-b-20-tablet-and-mobile">
                                    <asp:TextBox runat="server" ID="txtfromdate" TextMode="Date" CssClass="form-control generalSearch" placeholder="From Date"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvfromdate" ControlToValidate="txtfromdate" Display="Dynamic" ErrorMessage="Enter Frome Date" ForeColor="Red" ValidationGroup="RegularOrder" />
                                </div>
                                <div class="col-md-3 kt-margin-b-20-tablet-and-mobile">
                                    <asp:TextBox runat="server" ID="txttodate" TextMode="Date" CssClass="form-control generalSearch" placeholder="Search"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvtodate" ControlToValidate="txttodate" Display="Dynamic" ErrorMessage="Enter To Date" ForeColor="Red" ValidationGroup="RegularOrder" />
                                </div>
                                <div class="col-md-3 kt-margin-b-20-tablet-and-mobile">
                                    <div>
                                        <asp:DropDownList runat="server" ID="ddlCustomerID" CssClass="dropdown bootstrap-select form-control kt- kt-selectpicker" placeholder="Select Customer" data-live-search="true"></asp:DropDownList>
                                        <asp:RequiredFieldValidator runat="server" ID="rfvCustomer" ControlToValidate="ddlCustomerID" Display="Dynamic" ErrorMessage="Select Customer" ForeColor="Red" ValidationGroup="RegularOrder" />
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <asp:Button runat="server" ID="btnShow" Text="Show" CssClass="btn btn-primary btn-sm d-sm-inline-block" OnClick="btnShow_Click" ValidationGroup="RegularOrder"/>
                                    <asp:Button runat="server" ID="btnClear" Text="Clear" CssClass="btn btn-danger btn-sm d-sm-inline-block" OnClick="btnClear_Click" />
                                </div>
                            </div>
                            <br />
                            <div>
                                <asp:ScriptManager ID="smInvoice" runat="server"></asp:ScriptManager>
                                <rsweb:ReportViewer ID="rvInvoice" runat="server" Width="100%"></rsweb:ReportViewer>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--end: Search Form -->

        </div>
    </div>
</asp:Content>

