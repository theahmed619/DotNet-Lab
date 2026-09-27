<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Employee_Management_System.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Management</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container py-5">
            <h2 class="text-center mb-4">Employee Management System</h2>

            <div class="row mb-3">
                <div class="col-md-4">
                    <asp:Label ID="lblId" runat="server" CssClass="form-label" Text="ID"></asp:Label>
                    <input id="txtId" type="text" runat="server" class="form-control" />
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblFname" runat="server" CssClass="form-label" Text="First Name"></asp:Label>
                    <asp:TextBox ID="txtFname" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblLname" runat="server" CssClass="form-label" Text="Last Name"></asp:Label>
                    <asp:TextBox ID="txtLname" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row mb-3">
                <div class="col-md-4">
                    <asp:Label ID="lblGender" runat="server" CssClass="form-label" Text="Gender"></asp:Label>
                    <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblCity" runat="server" CssClass="form-label" Text="City"></asp:Label>
                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblActive" runat="server" CssClass="form-label" Text="Is Active"></asp:Label>
                    <asp:DropDownList ID="ddlActive" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>
            </div>

            <div class="mb-3">
             <%--   <asp:Label ID="lblMsg" runat="server" CssClass="text-success"></asp:Label><br />--%>
                <asp:Label ID="lblTotal" runat="server" CssClass="text-info"></asp:Label>
            </div>

            <div class="d-flex justify-content-center mb-4 gap-3">
                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAdd_Click" />
                <asp:Button ID="btnSelect" runat="server" Text="Select" CssClass="btn btn-info" OnClick="btnSelect_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-warning" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
            </div>
            <div class="d-flex justify-content-center mb-3">
                
                <asp:Label ID="lblMsg" runat="server" CssClass="text-danger"></asp:Label>
            </div>
            <div class="table-responsive">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" CssClass="table table-bordered table-striped text-center" Width="100%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <HeaderStyle BackColor="#0d6efd" ForeColor="white" Font-Bold="True" />
                </asp:GridView>
            </div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
