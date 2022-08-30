<%@ Page Language="C#" AutoEventWireup="true" CodeFile="print-report.aspx.cs" MasterPageFile="~/AdminMaster.master" Inherits="_Default" %>

<asp:Content runat="server" ContentPlaceHolderID="contentPlaceholder">
    

    <!-- DataTables -->
    <!-- ============================================================== -->
    <!-- Start right Content here -->
    <!-- ============================================================== -->
    <div class="main-content">
        <div class="page-content">
            <!-- Page-Title -->
            <div class="page-title-box">
                <div class="container-fluid">
                    <div class="row align-items-center">
                        <div class="col-md-8">
                            <h4 class="page-title mb-1">Print Report</h4>
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="dashboard">Dashboard</a></li>
                                <li class="breadcrumb-item active">Print Report</li>
                            </ol>
                        </div>
                        <div class="col-md-4">
                        </div>
                    </div>

                </div>
            </div>
            <!-- end page title end breadcrumb -->

            <div class="page-content-wrapper">
                <div class="container-fluid">
                    <!-- end row -->

                    <div class="row">
                        <div class="col-12">
                            <div class="card">
                                <div class="card-body">
                                    <div class="row mb-5">
                                         <div class="col-3 user-list">
                                            <h5 class="header-title">User Name</h5>
                                            <asp:ListBox runat="server" ID="lbxUser" SelectionMode="Multiple" CssClass="form-control" OnSelectedIndexChanged="ddlUser_SelectedIndexChanged"></asp:ListBox>
                                        </div>
                                      
                                        <div class="col-2">
                                            <h5 class="header-title">Machine Name</h5>
                                            <asp:DropDownList runat="server" ID="ddlMachineName" CssClass="form-control"></asp:DropDownList>
                                        </div>

                                         <div class="col-3">
                                             <h5 class="header-title">From Date</h5>
                                            <asp:TextBox runat="server" ID="txtDateFrom" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                        </div>
                                          
                                        <div class="col-3">
                                            <h5 class="header-title">To Date</h5>
                                            <asp:TextBox runat="server" ID="txtDateTo" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                        </div>
                                        
                                        <div class="col-1 mt-4">
                                            <asp:Button runat="server" ID="btnSubmit" Text="Search" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
                                        </div>

                                    </div>

                                    <table id="datatable-buttons" class=" table table-striped table-bordered dt-responsive nowrap" style="border-collapse: collapse; border-spacing: 0; width: 100%;">
                                        <thead>
                                            <tr>
                                                <th>User Name</th>
                                                <th>Machine Name</th>
                                                <th>File Name</th>
                                                <th>Pages </th>
                                                <th>Copies</th>
                                                <th>Printer Name</th>
                                                <th>Print Time</th>
                                                
                                            </tr>
                                        </thead>


                                        <tbody>
                                            <asp:Repeater runat="server" ID="rptUser">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%# ((PrintReport)Container.DataItem).UserName %></td>
                                                        <td><%# ((PrintReport)Container.DataItem).MachineName %></td>
                                                        <td><%# ((PrintReport)Container.DataItem).FileName %></td>
                                                        <td><%# ((PrintReport)Container.DataItem).NoOfPages %></td>
                                                        <td><%# ((PrintReport)Container.DataItem).NoOfCopies %></td>
                                                        <td><%# ((PrintReport)Container.DataItem).PrinterName %></td>
                                                        <td><%# ((PrintReport)Container.DataItem).StartTime.ToString("dd-MM-yyyy hh:mm tt") %></td>

                                                        
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <!-- end col -->
                    </div>
                    <!-- end row -->

                </div>
                <!-- end container-fluid -->
            </div>
            <!-- end page-content-wrapper -->
        </div>
        <!-- End Page-content -->


    </div>
    <!-- end main content-->
    <link rel="stylesheet" href="assets/css/bootstrap-multiselect.css">
<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-multiselect/0.9.13/js/bootstrap-multiselect.js"></script>

   <script type="text/javascript">
    $(function () {
        $('[id*=lbxUser]').multiselect({
            includeSelectAllOption: true
        });
    });
   </script>
</asp:Content>
