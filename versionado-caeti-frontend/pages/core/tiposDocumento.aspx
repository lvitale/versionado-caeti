<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tiposDocumento.aspx.cs" Inherits="versionado_caeti_frontend.pages.core.tiposDocumento" MasterPageFile="~/pages/master-page/default.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" Runat="Server">
    <fieldset>
    <legend>Tipo de Documento</legend>
    <table align="center">
                
                <tr>
                    <td><asp:Label ID="Label2" runat="server" Text="Area"/></td>
                    <td><asp:TextBox ID="txtArea" runat="server" CssClass="camposArea" Width="134px"/></td>
                     <td>         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtArea"
                    ErrorMessage="RequiredFieldValidator">* Debe ingresar el area .</asp:RequiredFieldValidator></td>
      
                </tr>

                <tr>
                    <td><asp:Label ID="Label3" runat="server" Text="Descripcion"/></td>
                    <td><asp:TextBox ID="TxtDescripcion" runat="server" CssClass="camposArea" Height="59px" TextMode="MultiLine" Width="131px"/></td>
                     <td>         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtDescripcion"
                    ErrorMessage="RequiredFieldValidator">* Debe ingresar la descripcion .</asp:RequiredFieldValidator></td>
      
                </tr>
                   <tr>
                   <td></td>
                    <td></td>
                    <td><asp:Button runat="server" Text="grabar" ID="btnSave" onclick="btnSave_Click" CssClass="botones"/>
                        <asp:Button ID="btnSaveLimpiar" runat="server" Text="Limpiar" onclick="btnSaveLimpiar_Click" CssClass="botones" CausesValidation="false"/></td>
                </tr>
                <tr>
                    <td></td><td></td>
                    <td><asp:Label ID="lblMessage" Visible="False" runat="server" Font-Bold="True"/></td>
                 </tr>
             </table>
             </fieldset>
             <hr />
    <table id="Buscar" border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td style="width:50px; height: 19px;">
            Buscar:
        </td>
        <td style="height: 19px">
            
            <asp:TextBox ID="txtBuscar" runat="server" Width="75%" CssClass="camposArea"></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="botones" OnClick="btnBuscar_Click" CausesValidation="false" /></td>
        <td style="width:50px; height: 19px;">
            <asp:Button ID="BtnLimpiar" runat="server" CssClass="botones" OnClick="BtnLimpiar_Click"
                Text="Limpiar" CausesValidation="false" /></td>
    </tr>
</table>
    <br />
    <asp:DataGrid ID="grillaTipo" runat="server" AllowPaging="True" 
        AllowSorting="True" 
        AutoGenerateColumns="False"
        Width="100%"  
        PageSize="10" 
        onselectedindexchanged="grillaDocumento_SelectedIndexChanged">
        <HeaderStyle  ForeColor="White" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" BackColor="#660033" BorderColor="#660033" />
        <ItemStyle CssClass="GridItem" BackColor="#9966FF" BorderColor="#CC0066" Font-Bold="True"></ItemStyle>
        <Columns>
            <asp:BoundColumn DataField="codigo" HeaderText="codigo" Visible="false" ></asp:BoundColumn>
            <asp:BoundColumn DataField="area" HeaderText="area" ></asp:BoundColumn>
            <asp:BoundColumn DataField="descripcion" HeaderText="descripcion" ></asp:BoundColumn>
             <asp:TemplateColumn>
                <ItemTemplate><asp:ImageButton ID="btnDelete" runat="server" ImageUrl="/images/delete.png" CommandName="delete" CausesValidation="False" OnCommand="delete" CommandArgument='<%#Eval("codigo") + ";" +Eval("descripcion")%>' /></ItemTemplate>
            </asp:TemplateColumn>
             
        </Columns>
        <PagerStyle Mode="NumericPages" />
    </asp:DataGrid><p align="center"><asp:Label ID="lblPopupMessage" Visible="False" runat="server" Font-Bold="True"/></p><br />
    <table id="Acciones" border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="center" style="height: 18px">
             
            </td>
        </tr>
    </table>
</asp:Content>