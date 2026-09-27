<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Student_Management_System.Home" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home - Student Management System</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container text-center py-5">
            <div class="row justify-content-center">
                <div class="col-md-8">
                    <div class="card shadow">
                        <div class="card-header bg-primary text-white">
                            <h2>Welcome to Student Management System</h2>
                        </div>
                        <div class="card-body">
                            <p class="lead">
                                Manage student registration, search, and admin tasks easily with our system.
                            </p>
                            <asp:Button ID="btnRegister" runat="server" Text="Go to Register Page" CssClass="btn btn-success" PostBackUrl="~/Register.aspx" />
                            <br /><br />
                            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-outline-primary" PostBackUrl="~/Login.aspx" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
