<%@ Page Language="C#" AutoEventWireup="true" CodeFile="email-sent-report.aspx.cs" MasterPageFile="~/AdminMaster.master" Inherits="_Default" %>

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
                            <h4 class="page-title mb-1">Email Sent Report</h4>
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="dashboard">Dashboard</a></li>
                                <li class="breadcrumb-item active">User Report</li>
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
                                         <div class="col-2">
                                            <asp:TextBox runat="server" ID="txtDateFrom" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                        </div>
                                          
                                        <div class="col-2">
                                            <asp:TextBox runat="server" ID="txtDateTo" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                        </div>
                                        <div class="col-2">
                                            <asp:DropDownList runat="server" ID="ddlUser" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                        <div class="col-2">
                                            <asp:DropDownList runat="server" ID="ddlMachineName" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                          <div class="col-2">
                                            <asp:DropDownList runat="server" ID="ddlGroupName" CssClass="form-control"></asp:DropDownList>
                                        </div>

                                        
                                        
                                        <div class="col-1">
                                            <asp:Button runat="server" ID="btnSubmit" Text="Search" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
                                        </div>

                                    </div>

                                    <table id="datatable-buttons" class=" table table-striped table-bordered dt-responsive nowrap" style="border-collapse: collapse; border-spacing: 0; width: 100%;">
                                        <thead>
                                            <tr>
                                                <th>User Name</th>
                                                <th>Machine Name</th>
                                                <th>From</th>
                                                <th>To</th>
                                                <th>CC</th>
                                                <th>BCC</th>
                                                <th>Subject</th>
                                                <th>Body</th>
                                                
                                                <th>Start Time</th>
                                                <th>End Time</th>
                                            </tr>
                                        </thead>


                                        <tbody>
                                            <asp:Repeater runat="server" ID="rptUser">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%# ((Email)Container.DataItem).userName %></td>
                                                        <td><%# ((Email)Container.DataItem).machineName %></td>
                                                        <td><%# ((Email)Container.DataItem).from %></td>
                                                        <td><%# ((Email)Container.DataItem).to %></td>
                                                        <td><%# ((Email)Container.DataItem).cc %></td>
                                                        <td><%# ((Email)Container.DataItem).bCc %></td>
                                                        <td><%# ((Email)Container.DataItem).subject %></td>
                                                        <td><%# ((Email)Container.DataItem).body %></td>
                                                        <td><%# ((Email)Container.DataItem).startTime.ToString("dd-MM-yyyy hh:mm tt") %></td>
                                                        <td><%# ((Email)Container.DataItem).endTime.ToString("dd-MM-yyyy hh:mm tt") %></td>
                                                        
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
   
</asp:Content>
