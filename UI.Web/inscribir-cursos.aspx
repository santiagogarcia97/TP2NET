<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="inscribir-cursos.aspx.cs" Inherits="UI.Web.inscribir_cursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <!-- tabla -->
    <div>
        <p class="font-weight-bold text-left h2">Inscribir a cursado</p>
    </div>

    <hr />

    <div>    
       <p>
        <asp:UpdatePanel ID="UpdatePanelButtons" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Button ID="btnInscribir" Text="Inscribir" runat="server"
                    CssClass="btn btn-outline-success btn-sm" OnClick="btnInscribir_Click"  />
                <asp:Button ID="btnDeseleccionar" CssClass="btn btn-outline-danger btn-sm" runat="server" 
                    Visible="false" Text="x" />
            </ContentTemplate>
        </asp:UpdatePanel>
       </p>    
    </div>

    <div class="grid-view">
        <asp:UpdatePanel ID="UpdatePanelGrid" runat="server" UpdateMode="Conditional">

            <ContentTemplate>
                <asp:GridView ID="gvCursos" runat="server" AutoGenerateColumns="False"
                    SelectedRowStyle-BackColor="#343a40"
                    SelectedRowStyle-ForeColor="White"
                    DataKeyNames="ID" OnLoad="Page_Load"
                    CssClass="table table-bordered table-sm table-responsive table-hover" 
                     OnSelectedIndexChanged="gvCursos_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="Id" />
                    <asp:BoundField HeaderText="Año" DataField="AnioCalendario" />
                    <asp:BoundField HeaderText="Curso" DataField="Curso" ItemStyle-Width="50%"/>
                    <asp:BoundField HeaderText="Cupo" DataField="Cupo" ItemStyle-Width="50%"/>
                    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                </Columns>
                <HeaderStyle CssClass="thead-light" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
