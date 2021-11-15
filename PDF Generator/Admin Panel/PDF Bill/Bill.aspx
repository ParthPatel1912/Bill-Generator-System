<%@ Page Title="Bill PDF" Language="C#" AutoEventWireup="true" CodeFile="Bill.aspx.cs" Inherits="PDF_Generator_Admin_Panel_PDF_Bill_Bill" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background: #fff; color: #666666">
    <form id="form1" runat="server">

        <style>
            .button {
                display: inline-block;
                padding: 15px 25px;
                font-size: 24px;
                cursor: pointer;
                text-align: center;
                text-decoration: none;
                outline: none;
                color: #fff;
                background-color: #ffb300;
                border: none;
                border-radius: 15px;
                box-shadow: 0 9px #999;
            }

                .button:hover {
                    background-color: #ff6600
                }

                .button:active {
                    background-color: #ff6600;
                    box-shadow: 0 5px #555;
                    transform: translateY(4px);
                }

            .auto-style1 {
                width: 100%;
            }

            .auto-style2 {
                width: 412px;
                height: 59px;
            }

            .auto-style3 {
                width: 352px;
                height: 59px;
            }

            .auto-style4 {
                width: 651px;
            }

            .auto-style5 {
                width: 502px;
            }

            .right-btn {
                float: right;
            }

            .left-btn {
                float: left;
            }

            .container {
                padding: 50px;
            }
        </style>

        <script type="text/javascript">

            function GetFileName() {
                if ('<%= Session["UserID"] %>' == "1") {
                    document.getElementById("btncancle").style.display = "none";
                    document.getElementById("btnPDF").style.display = "none";
                    var fileSaveName = '<%= lblPartyName.Text.ToString().Trim() + " " + lbldate.Text.ToString().Trim() %>';
                    document.title = fil



















                    eSaveName;
                    window.print();
                    document.getElementById("btnPDF").style.display = "";
                    document.getElementById("btncancle").style.display = "";
                }

                else {
                        document.getElementById('lblerror').innerHTML = 'You are not Admin !!!';
                }
                
            }



            function GotoList() {
                window.location.href = "../BillTeam/BillTeamGridViewList.aspx";
            }
        </script>



        <br />
        <br />
        <br />
        <div>
            <input id="btncancle" runat="server" type="button" style="border: dotted; border-color: palevioletred; height: 50px; background-color: lightgray; margin-left: 20px; border-radius: 10px; padding-left: 20px; padding-right: 20px;" class="left-btn" onclick="GotoList()" value="Go back to List" />
            <input runat="server" id="btnPDF" type="button" class="button right-btn" value="PDF Download" onclick="GetFileName()" />
            <br />
            <br />
            <br />
            <br />
            <label id="lblerror" runat="server" style="color: red; padding-left:20px;"></label>
            <br />
            <br />
            <br />
            <br />
        </div>

        <asp:Panel ID="pnlBill" runat="server">
            <div class="container pb-5">

                <%--<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="30pt" Font-Underline="True" ForeColor="#0066FF" Text="PS Creation"></asp:Label>--%>
                <asp:Image runat="server" ID="imgLogo" ImageUrl="~/PDF Generator/Content/img/Untitlged-22.jpg" Width="150" Height="150" AlternateText="PS Creation Logo" />
                <br />
                <br />
                <asp:Label ID="Label3" runat="server" Font-Size="18pt" Text="Hiteshbhai Rajkot"></asp:Label>
                <br />
                <asp:Label ID="Label4" runat="server" Font-Size="18pt" Text="Rajkot - 360 005"></asp:Label>
                <br />
                <asp:Label ID="Label5" runat="server" Font-Size="18pt" Text="Mobile No.: 89805 27700"></asp:Label>
                <br />
                <asp:Label ID="Label6" runat="server" Font-Size="18pt" Text="Email: parthshobhana19@gmail.com"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label7" runat="server" Font-Size="18pt" Text="Order Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : "></asp:Label>
                <asp:Label ID="lbldate" runat="server" Font-Size="18pt"></asp:Label>
                <br />
                <asp:Label ID="Label8" runat="server" Font-Size="18pt" Text="Invoice Bill No. : "></asp:Label>
                <asp:Label ID="lblInvoiveBillNo" runat="server" Font-Size="18pt"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="32pt" Font-Underline="True" ForeColor="White" Text=" &nbsp; INVOICE &nbsp;" BackColor="Blue"></asp:Label>
                <br />
                <br />
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style2"></td>
                        <td class="auto-style3">
                            <asp:Label ID="Label10" runat="server" Font-Size="18pt" Text="Party Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : "></asp:Label>
                            <asp:Label ID="lblPartyName" runat="server" Font-Size="18pt"></asp:Label>
                            <br />
                            <asp:Label ID="Label11" runat="server" Font-Size="18pt" Text="Party City&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : "></asp:Label>
                            <asp:Label ID="lblPartyCity" runat="server" Font-Size="18pt"></asp:Label>
                            ,
                        <asp:Label ID="lblState" runat="server" Font-Size="18pt"></asp:Label>
                            ,
                        <asp:Label ID="lblCountry" runat="server" Font-Size="18pt"></asp:Label>
                            <br />
                            <asp:Label ID="Label9" runat="server" Font-Size="18pt" Text="Party Mobile No.&nbsp;&nbsp; :  "></asp:Label>
                            <asp:Label ID="lblPartyMobileNo" runat="server" Font-Size="18pt"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="Label20" runat="server" Font-Size="18pt" Text="Status&nbsp;&nbsp; :  "></asp:Label>
                            <asp:Label ID="lblStatus" runat="server" Font-Size="18pt" Font-Bold="true" Font-Underline="true"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
                <br />
                <table class="auto-style1">
                    <tr>
                        <td>
                            <asp:GridView ID="gvData" runat="server" HeaderStyle-HorizontalAlign="Left" Width="1200px" Font-Size="15pt" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <%--<asp:BoundField DataField="OrderDateTime" HeaderStyle-Font-Bold="true" HeaderText="Order Date">
                                        <HeaderStyle Font-Bold="True" />
                                    </asp:BoundField>--%>
                                    <asp:BoundField DataField="CategoryName" HeaderStyle-Font-Bold="true" HeaderText="Category Name">
                                        <HeaderStyle Font-Bold="True" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ItemName" HeaderStyle-Font-Bold="true" HeaderText="Item Name">
                                        <HeaderStyle Font-Bold="True" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Price" HeaderStyle-Font-Bold="true" HeaderText="Price">
                                        <HeaderStyle Font-Bold="True" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Quantity" HeaderStyle-Font-Bold="true" HeaderText="Quantity">
                                        <HeaderStyle Font-Bold="True" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Amount" HeaderStyle-Font-Bold="true" HeaderText="Amount">
                                        <HeaderStyle Font-Bold="True" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Discount" HeaderStyle-Font-Bold="true" HeaderText="Discount">
                                        <HeaderStyle Font-Bold="True" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CourierCharge" HeaderStyle-Font-Bold="true" HeaderText="Courier Charge">
                                        <HeaderStyle Font-Bold="True" />
                                    </asp:BoundField>
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
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style4">&nbsp;</td>
                        <td>
                            <asp:Label ID="Label13" runat="server" Font-Size="18pt" Text="Sub Total &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : "></asp:Label>
                            <asp:Label ID="lblSubTotal" runat="server" Font-Size="18pt"></asp:Label>
                            <br />
                            <asp:Label ID="Label12" runat="server" Font-Size="18pt" Text="-- &nbsp; Discount&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : "></asp:Label>
                            <asp:Label ID="lblDiscount" runat="server" Font-Size="18pt"></asp:Label>
                            <br />
                            <asp:Label ID="Label17" runat="server" Font-Size="18pt" Text="+ &nbsp; Courier Charge :"></asp:Label>
                            <asp:Label ID="lblCourierCharge" runat="server" Font-Size="18pt"></asp:Label>
                            <br />
                            <asp:Label runat="server" Text="____________________________________" />
                            <br />
                            <asp:Label ID="Label14" runat="server" Font-Size="18pt" Text="Grand Total&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : " BackColor="LightGray" ForeColor="White"></asp:Label>
                            <asp:Label ID="lblGrandTotal" runat="server" Font-Size="18pt"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td style="text-align: center">
                            <asp:Label ID="Label15" runat="server" Font-Size="18pt" Text="Hitesh"></asp:Label>
                            <br />
                            <asp:Label runat="server" Text="______________________________" />
                            <br />
                            <asp:Label ID="Label16" runat="server" Font-Size="18pt" Text="Authorized Signature"></asp:Label>
                        </td>

                    </tr>
                </table>
                <br />
            </div>
        </asp:Panel>
    </form>
</body>
</html>
