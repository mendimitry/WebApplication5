<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Answers.aspx.cs" Inherits="WebApplication5.Books" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <link  type="text/css" rel="stylesheet" href="~/css/StyleSheet1.css" />
     <script type="text/javascript">
         function getDate() {
             var date = new Date();
             var hours = date.getHours();
             var minutes = date.getMinutes();
             var seconds = date.getSeconds();
             //По надобности условие ниже повторить с minutes и hours
             if (seconds < 10) {
                 seconds = '0' + seconds;
             }
             document.getElementById('timedisplay').innerHTML = hours + ':' + minutes + ':' + seconds;
         }
         setInterval(getDate, 0);
     </script>

    
    <style type="text/css">
        .auto-style8 {
            font-weight: bold;
        }
        .auto-style9 {
            color: #FFFFFF;
        }
    </style>

    
    Текущее время сайта:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   </head>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<div id="timedisplay" class="auto-style7">&nbsp; </div>
<body>
    <center>
    <ul id="navbar">
  <li class="auto-style9"><a href="#"><span class="auto-style8">Test</span></a></li>
  <li><a href="#">Test</a></li>
  <li><a href="#" class="auto-style6">Test</a></li>
  <li><a href="#">Test</a> < </li>
</ul>
        
      <form id="form1" runat="server">
            <div>
                 </div>
            <br />
                 <ul id="navbar">
            <table class="auto-style4">
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="c2" colspan="2">&nbsp;</table>
        </div>
            
        <div>
            

                
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />
            

                
            </ul>
                <br />
                        
                                <br />
            <font size="5" color="red" face="Times New Roman">
                <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" Height="187px" Width="227px"  AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                        <asp:BoundField DataField="QuestionId" HeaderText="QuestionId" SortExpression="QuestionId" />
                        <asp:CheckBoxField DataField="IsRight" HeaderText="IsRight" SortExpression="IsRight" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                 
                </asp:GridView>
                                
                                </font>
                                
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:quizConnectionString %>" ProviderName="<%$ ConnectionStrings:quizConnectionString.ProviderName %>" SelectCommand="SELECT Id, Title, QuestionId, IsRight FROM answers">
            </asp:SqlDataSource>
                                
                                <caption class="c1"><font size="5" color="red" face="Times New Roman"></font>
            
            </center>
         </div>
             </form>

  
    </div>  
</form>  
  

</body>
</html>
