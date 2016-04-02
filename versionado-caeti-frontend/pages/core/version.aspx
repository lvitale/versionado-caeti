<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="version.aspx.cs" Inherits="versionado_caeti_frontend.pages.core.version" MasterPageFile="~/pages/master-page/default.Master" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" Runat="Server">
      
    
    <fieldset>
    <legend>VERSIONADO</legend>
        <h4><asp:Label ID="lblHeader" runat="server" Text="Version"/></h4>
    <table align="center">
                <tr>
                    <td><asp:Label ID="Label1" runat="server" Text="Version"/></td>
                    <td><asp:TextBox ID="txtVersion" runat="server" CssClass="camposArea" BackColor="#CC99FF" BorderStyle="Solid" Enabled="False" Font-Bold="True" ForeColor="White"/>
                        <asp:ImageButton ID="nextVersion" ImageUrl="~/images/Next.png" runat="server" CausesValidation="False" OnClick="nextVersion_Click" />
                        <asp:ImageButton ID="backVersion" runat="server"  CausesValidation="False" ImageUrl="~/images/Back.png" OnClick="backVersion_Click" />
                    </td>
                     <td>         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVersion"
                    ErrorMessage="RequiredFieldValidator">* Debe ingresar el numero de version.</asp:RequiredFieldValidator></td>
      
                </tr>
                 <tr>
                    <td><asp:Label ID="Label2" runat="server" Text="SubVersion"/></td>
                    <td><asp:TextBox ID="txtsubversion" runat="server" CssClass="camposArea" BackColor="#CC99FF" BorderStyle="Solid" Enabled="False" Font-Bold="True" ForeColor="White" /></td>
                    <td>          <asp:RequiredFieldValidator ID="rq1" runat="server" ControlToValidate="txtsubversion"
                    ErrorMessage="RequiredFieldValidator">* Debe ingresar el numero de subversion</asp:RequiredFieldValidator></td>
                 </tr>
                <tr>
                    <td><asp:Label ID="Label5" runat="server" Text="Observacion"/></td>
                    <td><asp:TextBox ID="txtObervacion" runat="server" CssClass="camposArea" Height="54px" TextMode="MultiLine" Width="143px" /></td>
                    <td>          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtObervacion"
                    ErrorMessage="RequiredFieldValidator">* Debe ingresar la observacion</asp:RequiredFieldValidator></td>
                 </tr>
                 <tr>
                    <td><asp:Label ID="Label3" runat="server" Text="Estado"/></td>
                    <td><asp:DropDownList ID="comboEstado" runat="server"></asp:DropDownList></td>
                    <td>         </td>
      
                </tr>
                 <tr>
                    <td><asp:Label ID="Label4" runat="server" Text="Archivo"/></td>
                  
                     <td><asp:FileUpload ID= "Uploader" runat = "server" BorderStyle="Solid" /></td>
                    <td>&nbsp;</td>
      
                </tr>
                   <tr>
                   <td></td>
                    <td></td>
                    <td><asp:Button runat="server" Text="grabar" ID="btnSave" onclick="btnSave_Click" CssClass="botones"/>
                        <asp:Button ID="btnSaveLimpiar" runat="server" CausesValidation="False" Text="Limpiar" onclick="btnSaveLimpiar_Click" CssClass="botones"/></td>
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
            
            <asp:TextBox ID="txtBuscar" runat="server" Width="75%" CssClass="camposArea" BorderStyle="Solid"></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" CausesValidation="False" Text="Buscar" CssClass="botones" OnClick="btnBuscar_Click" BorderStyle="Solid" /></td>
        <td style="width:50px; height: 19px;">
            <asp:Button ID="BtnLimpiar" runat="server" CausesValidation="False" CssClass="botones" OnClick="BtnLimpiar_Click"
                Text="Limpiar" BorderStyle="Solid" /></td>
    </tr>
</table>
    <br />

    <asp:DataGrid ID="grillaVersion" runat="server" AllowPaging="True" 
        AllowSorting="True" 
        AutoGenerateColumns="False"
        Width="100%"  
        PageSize="15" 
        onselectedindexchanged="grillaVersion_SelectedIndexChanged">
          <HeaderStyle  ForeColor="White" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" BackColor="#660033" BorderColor="#660033" />
         <ItemStyle CssClass="GridItem" BackColor="#9966FF" BorderColor="#CC0066" Font-Bold="True"></ItemStyle>
       <Columns>
            <asp:BoundColumn DataField="version" HeaderText="version" ></asp:BoundColumn>
            <asp:BoundColumn DataField="subversion" HeaderText="subversion" ></asp:BoundColumn>
            <asp:BoundColumn DataField="nombre" HeaderText="nombre" ></asp:BoundColumn>
           <asp:BoundColumn DataField="observacion" HeaderText="observacion" ></asp:BoundColumn>
            <asp:BoundColumn DataField="id" HeaderText="id" Visible="false" ></asp:BoundColumn>
            
             <asp:TemplateColumn>
                <ItemTemplate><asp:ImageButton ID="btnDelete" runat="server" ImageUrl="/images/delete.png" CommandName="delete" CausesValidation="False" OnCommand="delete" CommandArgument='<%#Eval("id") + ";" +Eval("nombre")%>' /></ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn>
                <ItemTemplate><asp:ImageButton ID="btnModify" runat="server" ImageUrl="/images/Modify.png" CommandName="modify" CausesValidation="False"  OnCommand="modify"  CommandArgument='<%#Eval("id") + ";" +Eval("nombre")%>' /></ItemTemplate>
            </asp:TemplateColumn>
           
            <asp:ButtonColumn ButtonType="LinkButton" HeaderText="Descargar" Text="Descargar"  CommandName="Select" /> 
              
             
        </Columns>
        <PagerStyle Mode="NumericPages" />
    </asp:DataGrid>
    <p align="center"><asp:Label ID="lblPopupMessage" Visible="False" runat="server" Font-Bold="True"/>
    

 <asp:Button ID="btnShow" runat="server" Text="detalle" CausesValidation="False"  OnClick="btnShow_Click" style="display:none" />
    <cc1:ModalPopupExtender ID="modal" runat="server" PopupControlID="popup" TargetControlID="btnShow"
        CancelControlID="btnPopupCancelar" BackgroundCssClass="modalBackground" >
    </cc1:ModalPopupExtender>
     <asp:Panel ID="popup" runat="server"  align="center" CssClass="panelpopup" BorderStyle="Inset" ForeColor="White" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" BackColor="#660033" BorderColor="#660033" Height="182px" Width="387px"  >
          
        <table align="center">
            <tr class="bgCabecera">
				 <td colspan="2" align="center"><p>Modificacion de version</p></td>
			</tr>
            <tr>
                <td><asp:Label ID="Label6" runat="server" Text="Nombre"/><asp:Label Visible ="false"  ID="idpopup" runat="server"/></td>
                <td><asp:TextBox ID="txtPopupNombre" runat="server" CssClass="camposArea" Width="152px" Enabled="false" BackColor="Gray"/></td>
                    
            </tr>
            <tr>
                 <td><asp:Label ID="Label7" runat="server" Text="Observacion"/></td>
                 <td><asp:TextBox ID="txtPopupObservacion" runat="server" CssClass="camposArea" Width="152px"/></td>
            </tr>
                <tr>
                     <td style="height: 23px"><asp:Label ID="Label8" runat="server" Text="Estado"/></td>
                    <td style="height: 23px"><asp:DropDownList ID="comboPopupEstado" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label11" runat="server" Text="Archivo"/></td>
                  
                     <td><asp:FileUpload ID= "UpPopupLoader" runat = "server" BorderStyle="Solid" /></td>
                    <td>&nbsp;</td>
               </tr>
                <tr>
                   
                    <td></td>
                    <td><asp:Button runat="server" Text="Aceptar" CausesValidation="false" ID="btnPopupAceptar" onclick="modifyPopup_Click" CssClass="botones" BorderStyle="Solid"/>
                        <asp:Button ID="btnPopupCancelar" runat="server"  Text="Cancelar" CausesValidation="False" onclick="cancelPopup_Click" CssClass="botones" BorderStyle="Solid"/></td>
                </tr>
               
             </table>
       
    </asp:Panel>
    </p>
     </asp:Content>
