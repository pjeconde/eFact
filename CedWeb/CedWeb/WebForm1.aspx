<%@ Page language="c#" AutoEventWireup="false" CodeFile="~/WebForm1.aspx.cs" Inherits="CedWeb.WebForm1" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD runat="server">
		<title>WebForm1</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<style>
		.greyed
		{
		  background-color:#c0c0c0;
		}
		</style>
	</HEAD>
	<body onload="AddEmptyHeaderDataLoad()">
		<script language=javascript>
		function AddEmptyHeaderDataLoad()
		{
			if ( typeof(dgTittle4) != 'undefined' )
			{
			   dgTittle4.rows[1].cells[0].innerText = 'Tittle Joseph';
			   dgTittle4.rows[1].cells[1].innerText = '29';
			   dgTittle4.rows[1].cells[2].innerText = '5/67 Rachna Vaishali Ghaziabad';
			}
		}		
		</script>		
		<form id="Form1" method="post" runat="server">
			&nbsp;
			<table>
				<tr>
					<td valign=top style="width: 357px">
						<b><font color=red>Ex. I - Header Freeze</font></b><br>
						<Tittle:CustomDataGrid id="dgTittle" FreezeHeader=true
							runat="server" AutoGenerateColumns=False
							GridHeight="150"
							>
						<Columns>
							<asp:TemplateColumn HeaderText="User Name" >
								<ITEMTEMPLATE>
									<asp:Label Runat="server" ID="lblName" Width="100" Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>'  />
								</ITEMTEMPLATE>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Grade"  HeaderStyle-HorizontalAlign=Right  >
								<ITEMTEMPLATE>
									<asp:TextBox Runat="server"  Width="100" ID="txtAge" Text='<%# DataBinder.Eval(Container, "DataItem.Age") %>'  />
								</ITEMTEMPLATE>
							</asp:TemplateColumn>
						</Columns> 				 
						</Tittle:CustomDataGrid>
					</td>
					<td>&nbsp;&nbsp;</td>
					<td valign=top style="width: 436px">
						<b><font color=red>Ex. II - Row(s)<font color=green>(1)</font> Freeze</font></b><br>
						<Tittle:CustomDataGrid id="dgTittle2" FreezeHeader=true
							runat="server" AutoGenerateColumns=True
							GridHeight="110"
							FreezeRows=1
							>						 
						</Tittle:CustomDataGrid>
					</td>
				</tr>
				<tr>
				<td colspan=3><hr></Td>
				</tr>
				<tr>					
					<td valign=top style="width: 357px">
						<b><font color=red>Ex. III - Column(s) <font color=green>(2)</font> Freeze</font></b><br>
						<Tittle:CustomDataGrid id="dgTittle3" FreezeHeader=true
							runat="server" ShowFooter="true"  
							GridHeight="200"
							GridWidth="350"
							FreezeColumns=2
							AutoGenerateColumns=false Height="1px" Width="232px" OnItemCommand="dgTittle3_ItemCommand" OnSelectedIndexChanged="dgTittle3_SelectedIndexChanged">				
							<Columns>
							<asp:TemplateColumn HeaderText="Name" >
								<ITEMTEMPLATE>
									<asp:Label Runat="server" ID="Label1" Width="100" Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>'  />
                                
</ITEMTEMPLATE>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Grade"  >
								<ITEMTEMPLATE>
									<asp:Label Runat="server"   ID="Textbox1" Text='<%# DataBinder.Eval(Container, "DataItem.Age") %>'  />
                                
</ITEMTEMPLATE>
                                <headerstyle horizontalalign="Right" />
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Address" >
                                <itemstyle wrap="False" />
								<ITEMTEMPLATE>
									<asp:Label Runat="server"  ID="Label2" Text='<%# DataBinder.Eval(Container, "DataItem.Address") %>'  />
                                
</ITEMTEMPLATE>
                                <headerstyle horizontalalign="Right" />
							</asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="TipoDoc" >
                                <itemstyle wrap="False" />
                                <footertemplate>
<asp:DropDownList id="DropDownListReferencias" runat="server" __designer:wfdid="w6" Width="224px"></asp:DropDownList> 
</footertemplate>
								<ITEMTEMPLATE>
<asp:Label id="LabelTipoDoc" Text='<%# DataBinder.Eval(Container, "DataItem.Codigo") %>' Runat="server" __designer:wfdid="w5"></asp:Label> 
</ITEMTEMPLATE>
                                <headerstyle horizontalalign="Right" />
                                <edititemtemplate>
<asp:DropDownList id="DropDownListReferenciasEdit" runat="server" __designer:wfdid="w7" Width="224px"></asp:DropDownList>
</edititemtemplate>
							</asp:TemplateColumn>

						</Columns> 				 
                            <ItemStyle CssClass="GridNormal" />
                            <PagerStyle ForeColor="Blue" HorizontalAlign="Center" Mode="NumericPages" />
                            <HeaderStyle CssClass="GridHeader" />
                            <AlternatingItemStyle CssClass="GridAlternate" />
                            <FooterStyle CssClass="GridHeader" />
						</Tittle:CustomDataGrid>
					</td>
					<td>&nbsp;&nbsp;</td>
					<td valign=top style="width: 436px">
						<b><font color=red>Ex. IV - Add fixed row(s) <font color=green>(1)</font> at top in all datagrid page</font></b><br>
						<Tittle:CustomDataGrid id="dgTittle4" 
							runat="server" 							
							GridHeight="209"
							AutoGenerateColumns=false
							AddEmptyHeaders=1
							EmptyHeaderClass = "greyed"							
							PageSize=7
							FreezeHeader=true
							PagerStyle-Mode=NumericPages 
							AllowPaging=True 
							OnPageIndexChanged="dgTittle4_PageIndexChanged"
							>				
							<Columns>
							<asp:TemplateColumn HeaderText="Name" >
								<ITEMTEMPLATE>
									<asp:Label Runat="server" ID="Label3" Width="100" Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>'  />
								</ITEMTEMPLATE>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Grade"  HeaderStyle-HorizontalAlign=Right  >
								<ITEMTEMPLATE>
									<asp:Label Runat="server"   ID="Label4" Text='<%# DataBinder.Eval(Container, "DataItem.Age") %>'  />
								</ITEMTEMPLATE>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Address"  HeaderStyle-HorizontalAlign=Right  ItemStyle-Wrap=False >
								<ITEMTEMPLATE>
									<asp:Label Runat="server"  ID="Label5" Text='<%# DataBinder.Eval(Container, "DataItem.Address") %>'  />
								</ITEMTEMPLATE>
							</asp:TemplateColumn>
						</Columns> 				 
						</Tittle:CustomDataGrid>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
