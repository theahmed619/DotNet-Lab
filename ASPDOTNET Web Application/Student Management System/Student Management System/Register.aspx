<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Student_Management_System.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Management</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container py-5">
            <div class="row">
                <div class="col-md-6 offset-md-3">
                    <div class="card shadow">
                        <div class="card-header text-center bg-primary text-white">
                            <h3>Student Register</h3>
                        </div>
                        <div class="card-body">

                            <div class="mb-3">
                                <asp:Label ID="lblName" runat="server" Text="Name" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Placeholder="Enter your name"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" Placeholder="Enter your email"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Enter your password"></asp:TextBox>
                            </div>

                            <div class="d-grid">
                                <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-success" OnClick="btnRegister_Click" />
                            </div>

                            <div class="d-flex justify-content-center mt-3">
                                <asp:Label ID="lblMessage" runat="server" CssClass="text-success"></asp:Label>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
