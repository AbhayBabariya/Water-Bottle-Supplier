<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.master" AutoEventWireup="true" CodeFile="BranchList.aspx.cs" Inherits="Admin_Panel_Branch_BranchList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- begin:: Content -->
    <div class="kt-container  kt-container--fluid  kt-grid__item kt-grid__item--fluid">
        <div class="kt-portlet kt-portlet--mobile">
            <div class="kt-portlet__head kt-portlet__head--lg">
                <div class="kt-portlet__head-label">
                    <span class="kt-portlet__head-icon">
                        <i class="kt-font-brand flaticon2-line-chart"></i>
                    </span>
                    <h3 class="kt-portlet__head-title">List of Branch
                    </h3>
                    <asp:Label ID="lblUserSession" runat="server" CssClass="text-dark" Display="Dynamic" EnableViewState="false"></asp:Label>
                </div>

                <div class="kt-portlet__head-toolbar">
                    <div class="kt-portlet__head-wrapper">
                        <div class="dropdown dropdown-inline">
                            <asp:HyperLink ID="hlBranchAdd" runat="server" NavigateUrl="~/AdminPanel/Branch/BranchAddEdit.aspx" CssClass="btn btn-primary btn-icon-sm"><i class="flaticon2-plus"></i> Add New</asp:HyperLink>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Label runat="server" ID="lblMessage" CssClass="alert-danger" EnableViewState="false" />

            <br />
            <div class="kt-portlet__body kt-portlet__body--fit">
                <!--begin: Datatable -->
                <div class="kt-datatable" id="local_data"></div>
                <!--end: Datatable -->
            </div>

            <!-- end:: Content -->

            <!-- end:: Page -->






            <!-- begin::Quick Panel -->
            <div id="kt_quick_panel" class="kt-quick-panel">
                <a href="#" class="kt-quick-panel__close" id="kt_quick_panel_close_btn"><i class="flaticon2-delete"></i></a>

                <div class="kt-quick-panel__nav">
                    <ul class="nav nav-tabs nav-tabs-line nav-tabs-bold nav-tabs-line-3x nav-tabs-line-brand  kt-notification-item-padding-x" role="tablist">
                        <li class="nav-item active">
                            <%--<a class="nav-link active" data-toggle="tab" href="#kt_quick_panel_tab_notifications" role="tab">Notifications</a>--%>
                            <asp:HyperLink runat="server" ID="hlCancel" Text="Cancel" NavigateUrl="~/AdminPanel/Branch/BranchList.aspx" CssClass="nav-link active" />
                        </li>
                        <li class="nav-item">
                            <%--<a class="nav-link" data-toggle="tab" href="#kt_quick_panel_tab_logs" role="tab">Audit Logs</a>--%>
                            <asp:HyperLink runat="server" ID="HyperLink1" Text="Cancel" NavigateUrl="~/AdminPanel/Branch/BranchAddEdit.aspx" CssClass="nav-link" />
                        </li>
                    </ul>
                </div>
            </div>
            <!-- end::Quick Panel -->

            <!-- begin::Global Config(global config for global JS sciprts) -->
            <script>
                var KTAppOptions = {
                    "colors": {
                        "state": {
                            "brand": "#5d78ff",
                            "dark": "#282a3c",
                            "light": "#ffffff",
                            "primary": "#5867dd",
                            "success": "#34bfa3",
                            "info": "#36a3f7",
                            "warning": "#ffb822",
                            "danger": "#fd3995"
                        },
                        "base": {
                            "label": [
                                "#c5cbe3",
                                "#a1a8c3",
                                "#3d4465",
                                "#3e4466"
                            ],
                            "shape": [
                                "#f0f3ff",
                                "#d9dffa",
                                "#afb4d4",
                                "#646c9a"
                            ]
                        }
                    }
                };
            </script>
            <!-- end::Global Config -->

            <!--begin::Global Theme Bundle(used by all pages) -->
            <script src="~/Content/assets/plugins/global/plugins.bundle.js" type="text/javascript"></script>
            <script src="~/Content/assets/js/scripts.bundle.js" type="text/javascript"></script>
            <!--end::Global Theme Bundle -->

            <!--begin::Page CSS(used by this page) -->
            <link href="<%=ResolveClientUrl("~/Content/assets/css/datatable/dataTables.bootstrap4.min.css")%>" rel="stylesheet" type="text/css" />
            <link href="<%=ResolveClientUrl("~/Content/assets/css/datatable/responsive.bootstrap4.min.css")%>" rel="stylesheet" />
            <!--end::Page CSS -->

            <!--begin::Page Scripts(used by this page) -->
            <script src="<%=ResolveClientUrl("~/Content/assets/js/pages/crud/datatables/basic/paginations.js") %>" type="text/javascript"></script>

            <script src="<%=ResolveClientUrl("~/Content/assets/js/pages/crud/datatables/jquery.dataTables.min.js") %>" type="text/javascript"></script>
            <script src="<%=ResolveClientUrl("~/Content/assets/js/pages/crud/datatables/dataTables.bootstrap4.min.js") %>" type="text/javascript"></script>
            <script src="<%=ResolveClientUrl("~/Content/assets/js/pages/crud/datatables/dataTables.responsive.min.js") %>"></script>
            <script src="<%=ResolveClientUrl("~/Content/assets/js/pages/crud/datatables/responsive.bootstrap4.min.js") %>"></script>
            <script src="<%=ResolveClientUrl("~/Content/assets/js/pages/crud/datatables/datatables-demo.js") %>" type="text/javascript"></script>
            <!--end::Page Scripts -->

            <!--begin::Page Scripts(used by this page) -->
            <script src="~/Content/assets/js/pages/crud/metronic-datatable/base/data-local.js" type="text/javascript"></script>
            <!--end::Page Scripts -->

            <div class="row">
                <div class="container">
                    <div class="col-md-12">
                        <br />
                        <asp:GridView ID="gvBranch" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-hover table-responsive-sm" OnRowCommand="gvBranch_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Sr No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <div style="text-align: center">
                                            <asp:HyperLink runat="server" ID="hlEdit" ToolTip="Edit Details" NavigateUrl='<%# "~/AdminPanel/Branch/BranchAddEdit.aspx?BranchID=" + Eval("BranchID").ToString().Trim() %>'><i class="la la-edit"></i>Edit</asp:HyperLink>

                                            <asp:LinkButton ID="btnDelete" runat="server" ToolTip="Delete Record3" CssClass="btn btn-sm btn-clean btn-icon btn-icon-md" Text="Delete" CommandName="DeleteRecord" CommandArgument='<%# Eval("BranchID") %>'><i class="la la-trash"></i></asp:LinkButton>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="BranchName" HeaderText="Branch Name" />
                                <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" />
                                <asp:BoundField DataField="Address" HeaderText="Address" />
                                <asp:BoundField DataField="ManagerName" HeaderText="Manager Name" />
                                <asp:BoundField DataField="ManagerMobileNo" HeaderText="Manager Mobile No" />

                            </Columns>
                        </asp:GridView>
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

