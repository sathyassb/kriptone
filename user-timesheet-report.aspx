<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user-timesheet-report.aspx.cs" MasterPageFile="~/AdminMaster.master" Inherits="_Default" %>

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
                            <h4 class="page-title mb-1">User Timesheet Report</h4>
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="dashboard">Dashboard</a></li>
                                <li class="breadcrumb-item active">User Idle Time Report</li>
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

                                         <div class="col-2">
                                             <h5 class="header-title">From Date</h5>
                                            <asp:TextBox runat="server" ID="txtDateFrom" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                        </div>
                                          
                                        <div class="col-2">
                                            <h5 class="header-title">To Date</h5>
                                            <asp:TextBox runat="server" ID="txtDateTo" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                        </div>
                                          <div class="col-2">
                                            <h5 class="header-title">Option</h5>
                                            <asp:DropDownList runat="server" ID="ddlOption" CssClass="form-control">
                                                <asp:ListItem Text="Everything" Value="full"></asp:ListItem>
                                                <asp:ListItem Text="Consolidated" Value="total"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-1 mt-4">
                                            <asp:Button runat="server" ID="btnSubmit" Text="Search" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
                                        </div>

                                    </div>

                                    <table id="datatable-buttons" class=" table table-striped table-bordered dt-responsive nowrap" style="border-collapse: collapse; border-spacing: 0; width: 100%;">
                                        <thead>
                                            <tr>
                                                <th>User Name</th>
                                                <th>Date</th>
                                                <th>Machine Name</th>
                                                <th>Login Time</th>
                                                <th>Logoff Time</th>
                                                <th>Total Hours</th>
                                                <th>Total Idle Hours</th>
                                                <th>Total Productive Hours</th>
                                                
                                                
                                            </tr>
                                        </thead>


                                        <tbody>
                                            <asp:Repeater runat="server" ID="rptUser">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%# ((UserTimeSheet)Container.DataItem).UserName %></td>
                                                        <td><%# ((UserTimeSheet)Container.DataItem).StartTime.ToString("dd-MM-yyy") %></td>
                                                        <td><%# ((UserTimeSheet)Container.DataItem).MachineName %></td>
                                                        <td><%# ((UserTimeSheet)Container.DataItem).StartTime.ToString("dd-MM-yyy hh:mm tt") %></td>
                                                        <td><%# ((UserTimeSheet)Container.DataItem).EndTime.ToString("dd-MM-yyy hh:mm tt") %></td>
                                                        <td><%# (new TimeSpan(0,((UserTimeSheet)Container.DataItem).TotalMinutes,0).Days*24+
                                                                new TimeSpan(0,((UserTimeSheet)Container.DataItem).TotalMinutes,0).Hours)+"h:"+
                                                                    new TimeSpan(0,((UserTimeSheet)Container.DataItem).TotalMinutes,0).Minutes+"m"%></td>
                                                        <td><%# (new TimeSpan(0,((UserTimeSheet)Container.DataItem).IdleMinutes,0).Days*24+
                                                                new TimeSpan(0,((UserTimeSheet)Container.DataItem).IdleMinutes,0).Hours)+"h:"+
                                                                    new TimeSpan(0,((UserTimeSheet)Container.DataItem).IdleMinutes,0).Minutes+"m"%></td>
                                                        <td><%# (new TimeSpan(0,((UserTimeSheet)Container.DataItem).TotalMinutes-((UserTimeSheet)Container.DataItem).IdleMinutes,0).Days*24+
                                                                new TimeSpan(0,((UserTimeSheet)Container.DataItem).TotalMinutes-((UserTimeSheet)Container.DataItem).IdleMinutes,0).Hours)+"h:"+
                                                                    new TimeSpan(0,((UserTimeSheet)Container.DataItem).TotalMinutes-((UserTimeSheet)Container.DataItem).IdleMinutes,0).Minutes+"m"%></td>
                                                        
                                                        
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
