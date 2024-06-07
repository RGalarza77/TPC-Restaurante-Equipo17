<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="TPC_AppRestaurante_Equipo17.Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="row">
        <div class="col-4">

        </div>
        <div class="col-4">


    <div class="mb-3">
        <label for="formGroupExampleInput" class="form-label">Usuario</label>
        <input type="text" class="form-control" id="txtUser" placeholder="Username">
    </div>
    <div class="mb-3">
        <label for="formGroupExampleInput2" class="form-label">Contraseña</label>
        <input type="password" class="form-control" id="txtPass" placeholder="********">
    </div>
        </div>

    </div>
</asp:Content>
