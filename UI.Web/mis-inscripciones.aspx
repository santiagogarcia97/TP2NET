<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="mis-inscripciones.aspx.cs" Inherits="UI.Web.inscripciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <!-- tabla -->
    <div>
        <p class="font-weight-bold text-left h2">Mis Inscripciones</p>
    </div>

    <hr />

    <div class="grid-view">
        <asp:GridView ID="gvMisIns" runat="server" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="#343a40"
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID" OnLoad="Page_Load"
            CssClass="table table-bordered table-sm table-responsive table-hover">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="Id" />
            <asp:BoundField HeaderText="Curso" DataField="Curso" ItemStyle-Width="40%"/>
            <asp:BoundField HeaderText="Nota" DataField="Nota" ItemStyle-Width="30%"/>
            <asp:BoundField HeaderText="Condicion" DataField="Condicion" ItemStyle-Width="30%"/>
        </Columns>
        <HeaderStyle CssClass="thead-light" />
        </asp:GridView>
    </div>

</asp:Content>
