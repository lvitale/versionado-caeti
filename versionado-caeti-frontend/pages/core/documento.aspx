<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="documento.aspx.cs" Inherits="versionado_caeti_frontend.pages.core.documento" MasterPageFile="~/pages/master-page/default.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" Runat="Server">
    <fieldset>
    <legend>Documento</legend>
    <table align="center">
                <tr>
                    <td><asp:Label ID="Label1" runat="server" Text="Nombre"/></td>
                    <td><asp:TextBox ID="txtNombre" runat="server" CssClass="camposArea" Width="152px"/></td>
                     <td>         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre"
                    ErrorMessage="RequiredFieldValidator">* Debe ingresar el nombre del documento.</asp:RequiredFieldValidator></td>
      
                </tr>
                <tr>
                    <td><asp:Label ID="Label2" runat="server" Text="Descripcion"/></td>
                    <td><asp:TextBox ID="txtDescripcion" runat="server" CssClass="camposArea" Height="70px" TextMode="MultiLine" Width="150px"/></td>
                     <td>         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescripcion"
                    ErrorMessage="RequiredFieldValidator">* Debe ingresar la descripcion.</asp:RequiredFieldValidator></td>
      
                </tr>
                 <tr>
                    <td><asp:Label ID="Label4" runat="server" Text="Tipo"/></td>
                    <td><asp:DropDownList ID="comboTipo" runat="server"></asp:DropDownList></td>
                    <td>         </td>
      
                </tr>
                   <tr>
                   <td></td>
                    <td></td>
                    <td><asp:Button runat="server" Text="grabar" ID="btnSave" onclick="btnSave_Click" CssClass="botones" BorderStyle="Solid"/>
                        <asp:Button ID="btnSaveLimpiar" runat="server" Text="Limpiar" CausesValidation="False" onclick="btnSaveLimpiar_Click" CssClass="botones" BorderStyle="Solid"/></td>
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
            
            <asp:TextBox ID="txtBuscar" runat="server" Width="75%" CssClass="camposArea" OnTextChanged="txtBuscar_TextChanged"></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" CausesValidation="False" Text="Buscar" CssClass="botones" OnClick="btnBuscar_Click" BorderStyle="Solid" /></td>
        <td style="width:50px; height: 19px;">
            <asp:Button ID="BtnLimpiar" runat="server" CausesValidation="False" CssClass="botones" OnClick="BtnLimpiar_Click"
                Text="Limpiar" BorderStyle="Solid" /></td>
    </tr>
</table>
    <br />
    <asp:DataGrid ID="grillaDocumento" runat="server" AllowPaging="True" 
        AllowSorting="True" 
        AutoGenerateColumns="False"
        Width="100%"  
        PageSize="10" 
        onselectedindexchanged="grillaDocumento_SelectedIndexChanged"
        
        >
         <HeaderStyle  ForeColor="White" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" BackColor="#660033" BorderColor="#660033" />
         <ItemStyle CssClass="GridItem" BackColor="#9966FF" BorderColor="#CC0066" Font-Bold="True"></ItemStyle>
        <Columns>
            <asp:BoundColumn DataField="id" HeaderText="id" Visible="false" ></asp:BoundColumn>
            
            <asp:BoundColumn DataField="nombre" HeaderText="nombre" ></asp:BoundColumn>
            <asp:BoundColumn DataField="descripcion" HeaderText="descripcion" ></asp:BoundColumn>
            <asp:BoundColumn DataField="descripcionTipo" HeaderText="tipo" ></asp:BoundColumn>
            <asp:TemplateColumn>
                <ItemTemplate><asp:ImageButton ID="btnDelete" runat="server" ImageUrl="/images/delete.png" CommandName="delete" CausesValidation="False" OnCommand="delete"  CommandArgument='<%#Eval("id") + ";" +Eval("nombre")%>' /></ItemTemplate>
            </asp:TemplateColumn>
             <asp:TemplateColumn>
                <ItemTemplate><asp:ImageButton ID="btnModify" runat="server" ImageUrl="/images/Modify.png" CommandName="modify" CausesValidation="False"  OnCommand="modify"  CommandArgument='<%#Eval("id") + ";" +Eval("nombre")%>' /></ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn>
                <ItemTemplate><asp:ImageButton ID="btnlink" runat="server" ImageUrl="~/images/Next.png" CommandName="viewdetails" CausesValidation="False" OnCommand="viewdetails" CommandArgument='<%#Eval("id") + ";" +Eval("nombre")%>'/></ItemTemplate>
            </asp:TemplateColumn>
           
        </Columns>
        <PagerStyle Mode="NumericPages" />
    </asp:DataGrid> <p align="center"><asp:Label ID="lblPopupMessage" Visible="False" runat="server" Font-Bold="True"/></p><br />
    <table id="Acciones" border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="center" style="height: 18px">
             
            </td>
        </tr>
    </table>

   

     <asp:Button ID="btnShow" runat="server" Text="detalle" CausesValidation="False"  OnClick="btnShow_Click" style="display:none" />
    <cc1:ModalPopupExtender ID="modal" runat="server" PopupControlID="popup" TargetControlID="btnShow"
        CancelControlID="btnPopupCancelar" BackgroundCssClass="modalBackground" >
    </cc1:ModalPopupExtender>
    <asp:Panel ID="popup" runat="server"  align="center" CssClass="panelpopup" BorderStyle="Inset" ForeColor="White" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" BackColor="#660033" BorderColor="#660033"  >
          
        <table align="center">
            <tr class="bgCabecera">
				<td colspan="2" align="center"><p>Modificacion de documento</p></td>
								
				</tr>
                <tr>
                    <td><asp:Label ID="Label3" runat="server" Text="Nombre"/></td>
                    <td><asp:TextBox ID="txtPopupNombre" runat="server" CssClass="camposArea" Width="152px" Enabled="false" BackColor="Gray"/></td>
                </tr>
                <tr>
                     <td><asp:Label ID="Label5" runat="server" Text="Descripcion"/></td>
                    <td><asp:TextBox ID="txtPopupDescripcion" runat="server" CssClass="camposArea" Width="152px"/></td>
                </tr>
                <tr>
                     <td><asp:Label ID="Label6" runat="server" Text="Tipo"/></td>
                    <td><asp:DropDownList ID="comboPopupTipo" runat="server"></asp:DropDownList></td>
                </tr>
                
                   <tr>
                   
                    <td></td>
                    <td><asp:Button runat="server" Text="Aceptar" CausesValidation="false" ID="btnPopupAceptar" onclick="modifyPopup_Click" CssClass="botones" BorderStyle="Solid"/>
                        <asp:Button ID="btnPopupCancelar" runat="server"  Text="Cancelar" CausesValidation="False" onclick="cancelPopup_Click" CssClass="botones" BorderStyle="Solid"/></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Label ID="lblpopup" Visible="False" runat="server" Font-Bold="True"/></td>
                 </tr>
                  <tr>
                    <td></td>
                    <td><asp:Label ID="lblId" Visible="False" runat="server" Font-Bold="True"/></td>
                 </tr>
             </table>
       
    </asp:Panel>
</asp:Content>
