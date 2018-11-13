<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="reportes.aspx.cs" Inherits="UI.Web.main.reportes" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div>
        <p class="font-weight-bold text-left h2">Reportes</p>
    </div>

    <hr />
    <rsweb:ReportViewer ID="rvReportes" runat="server" AsyncRendering="False" Width="100%" Height="800px"></rsweb:ReportViewer>
</asp:Content>
