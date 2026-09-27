<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Student_Management_System.Admin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Search</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container py-5">
            <div class="row justify-content-center">
                <div class="col-md-8">
                    <div class="card shadow">
                        <div class="card-header bg-primary text-white d-flex justify-content-between ">
                            <h4 class="mb-0">Search Student by Email</h4>
                             <asp:Button ID="logout" runat="server" Text="Logout" CssClass="btn btn-danger " OnClick="logout_Click" />
                         
                        </div>
                        <div class="card-body">
                            <div class="input-group mb-3">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Enter student email"></asp:TextBox>
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-success" OnClick="btnSearch_Click" />
                            </div>

                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered text-center mt-3"
                                AutoGenerateColumns="true" EmptyDataText="No data found.">
                            </asp:GridView>

                            <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
