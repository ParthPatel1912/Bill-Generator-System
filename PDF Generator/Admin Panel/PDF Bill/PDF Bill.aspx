<%@ Page Title="" Language="C#" MasterPageFile="~/PDF Generator/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="PDF Bill.aspx.cs" Inherits="PDF_Generator_Admin_Panel_PDF_Bill_PDF_Bill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphHeadContent" runat="Server">
    Download PDF

</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="cphBreadcrum" runat="Server">

    <li class="breadcrumb-item" style="float: left;">
        <a href="../Home/Home.aspx"><i class="feather icon-home"></i></a>
    </li>
    <li class="breadcrumb-item" style="float: left;"><a href="#">PDF Download</a> </li>

</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="cphCardTitle" runat="Server">
    PDF

</asp:Content>

<asp:Content ID="Content8" ContentPlaceHolderID="cphError" runat="Server">

    <asp:Label ID="lblError" EnableViewState="false" runat="server" CssClass="text-danger" />

</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">



    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <meta name="description" content="Invoicebus Invoice Template">
    <meta name="author" content="Invoicebus">

    <meta name="template-hash" content="91216e926eab41d8aa403bf4b00f4e19">

    <%--<link href="http://cdn.invoicebus.com/generator/generator.min.js?data=data.js" rel="stylesheet" />--%>


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
            width: 189px;
            height: 59px;
        }

        .auto-style3 {
            width: 352px;
            height: 59px;
        }

        .auto-style4 {
            width: 493px;
        }

        .auto-style5 {
            width: 502px;
        }
    </style>

    <div class="col-md-11 text-right pt-4">
        <asp:Button ID="btncancle" runat="server" OnClick="btncancle_Click" Text="Go back to List" CssClass="btn btn-success" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button runat="server" ID="btnPDF" type="button" class="button" Text="PDF Download" OnClick="btnPDF_Click" />
        <br />
        <br />
    </div>

    <asp:Panel ID="pnlBill" runat="server">
        <div class="container pb-5">

            <%--<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="20pt" Font-Underline="True" ForeColor="#0066FF" Text="PS Creation"></asp:Label>--%>
            <asp:Image runat="server" ID="imgLogo" ImageUrl="~/PDF Generator/Content/img/Untitlged-22.jpg" Height="130" Width="130" AlternateText="PS Creation Logo" />
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Font-Size="13pt" Text="Hiteshbhai Rajkot"></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" Font-Size="13pt" Text="Rajkot - 360 005"></asp:Label>
            <br />
            <asp:Label ID="Label5" runat="server" Font-Size="13pt" Text="Mobile No.: 89805 27700"></asp:Label>
            <br />
            <asp:Label ID="Label6" runat="server" Font-Size="13pt" Text="Email: parthshobhana19@gmail.com"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Font-Size="13pt" Text="Order Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : "></asp:Label>
            <asp:Label ID="lbldate" runat="server" Font-Size="13pt"></asp:Label>
            <br />
            <asp:Label ID="Label8" runat="server" Font-Size="13pt" Text="Invoice Bill No. : "></asp:Label>
            <asp:Label ID="lblInvoiveBillNo" runat="server" Font-Size="13pt"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="25pt" Font-Underline="True" ForeColor="Blue" Text="INVOICE"></asp:Label>
            <br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style3">
                        <asp:Label ID="Label10" runat="server" Font-Size="13pt" Text="Party Name  : "></asp:Label>
                        <asp:Label ID="lblPartyName" runat="server" Font-Size="13pt"></asp:Label>
                        <br />
                        <asp:Label ID="Label11" runat="server" Font-Size="13pt" Text="Party City : "></asp:Label>
                        <asp:Label ID="lblPartyCity" runat="server" Font-Size="13pt"></asp:Label>
                        ,
                        <asp:Label ID="lblState" runat="server" Font-Size="13pt"></asp:Label>
                        ,
                        <asp:Label ID="lblCountry" runat="server" Font-Size="13pt"></asp:Label>
                        <br />
                        <asp:Label ID="Label9" runat="server" Font-Size="13pt" Text="Party Mobile No.&nbsp;&nbsp; :  "></asp:Label>
                        <asp:Label ID="lblPartyMobileNo" runat="server" Font-Size="13pt"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label20" runat="server" Font-Size="13pt" Text="Status&nbsp;&nbsp; :  "></asp:Label>
                        <asp:Label ID="lblStatus" runat="server" Font-Size="13pt" Font-Bold="true" Font-Underline="true" ></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <table class="auto-style1">
                <tr>
                    <td>
                        <asp:GridView ID="gvData" runat="server" Width="1155px" CellPadding="4" ForeColor="#333333" GridLines="Both" Font-Size="12pt" AutoGenerateColumns="false">
                            <Columns>
                                <%--<asp:BoundField DataField="OrderDateTime" HeaderText="Order Date" HeaderStyle-Font-Bold="true" />--%>
                                <asp:BoundField DataField="CategoryName" HeaderText="Category Name" HeaderStyle-Font-Bold="true" />
                                <asp:BoundField DataField="ItemName" HeaderText="Item Name" HeaderStyle-Font-Bold="true" />
                                <asp:BoundField DataField="Price" HeaderText="Price" HeaderStyle-Font-Bold="true" />
                                <asp:BoundField DataField="Quantity" HeaderText="Quantity" HeaderStyle-Font-Bold="true" />
                                <asp:BoundField DataField="Amount" HeaderText="Amount" HeaderStyle-Font-Bold="true" />
                                <asp:BoundField DataField="Discount" HeaderText="Discount" HeaderStyle-Font-Bold="true" />
                                <asp:BoundField DataField="CourierCharge" HeaderText="Courier Charge" HeaderStyle-Font-Bold="true" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td>
                        <asp:Label ID="Label13" runat="server" Font-Size="13pt" Text="Sub Total &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : "></asp:Label>
                        <asp:Label ID="lblSubTotal" runat="server" Font-Size="13pt"></asp:Label>
                        <br />
                        <asp:Label ID="Label12" runat="server" Font-Size="13pt" Text="-- &nbsp; Discount&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : "></asp:Label>
                        <asp:Label ID="lblDiscount" runat="server" Font-Size="13pt"></asp:Label>
                        <br />
                        <asp:Label ID="Label17" runat="server" Font-Size="13pt" Text="+ &nbsp; Courier Charge :"></asp:Label>
                        <asp:Label ID="lblCourierCharge" runat="server" Font-Size="13pt"></asp:Label>
                        <br />
                        <asp:Label ID="Label19" runat="server" Text="______________________________" />
                        <br />
                        <asp:Label ID="Label14" runat="server" Font-Size="13pt" Text="Grand Total&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : " ForeColor="GrayText"></asp:Label>
                        <asp:Label ID="lblGrandTotal" runat="server" Font-Size="13pt"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td style="text-align: center">
                        <asp:Label ID="Label15" runat="server" Font-Size="13pt" Text="Hitesh"></asp:Label>
                        <br />
                        <asp:Label ID="Label18" runat="server" Text="______________________________" />
                        <br />
                        <asp:Label ID="Label16" runat="server" Font-Size="13pt" Text="Authorized Signature"></asp:Label>
                    </td>

                </tr>
            </table>
            <br />
        </div>

        <%--<div id="container pb-5">

            <div class="left-stripes">
                <div class="circle c-upper"></div>
                <div class="circle c-lower"></div>
            </div>

            <div class="right-invoice">
                <section id="memo">
                    <div class="company-info">
                        <div>
                            <asp:Label ID="lbl" runat="server" />
                        <br>
                        <span>{company_address}</span>
                        <span>{company_city_zip_state}</span>
                        <br>
                        <span>{company_phone_fax}</span>
                        <br>
                        <span>{company_email_web}</span>
                    </div>

                    <div class="logo">
                        <img src="#" data-logo="{company_logo}" />
                    </div>
                </section>

                <section id="invoice-title-number">

                    <div class="title-top">
                        <span class="x-hidden">{issue_date_label}</span>
                        <span>{issue_date}</span> <span id="number">{invoice_number}</span>
                    </div>

                    <div id="title">{invoice_title}</div>

                </section>

                <section id="client-info">
                    <span>{bill_to_label}</span>
                    <div class="client-name">
                        <span>{client_name}</span>
                    </div>

                    <div>
                        <span>{client_address}</span>
                    </div>

                    <div>
                        <span>{client_city_zip_state}</span>
                    </div>

                    <div>
                        <span>{client_phone_fax}</span>
                    </div>

                    <div>
                        <span>{client_email}</span>
                    </div>

                    <div>
                        <span>{client_other}</span>
                    </div>
                </section>

                <div class="clearfix"></div>

                <section id="invoice-info">
                    <div>
                        <span>{net_term_label}</span> <span>{net_term}</span>
                    </div>
                    <div>
                        <span>{due_date_label}</span> <span>{due_date}</span>
                    </div>
                    <div>
                        <span>{po_number_label}</span> <span>{po_number}</span>
                    </div>
                </section>

                <div class="clearfix"></div>

                <div class="currency">
                    <span>{currency_label}</span> <span>{currency}</span>
                </div>

                <section id="items">

                    <table>

                        <tr>
                            <th>{item_row_number_label}</th>
                            <!-- Dummy cell for the row number and row commands -->
                            <th>{item_description_label}</th>
                            <th>{item_quantity_label}</th>
                            <th>{item_price_label}</th>
                            <th>{item_discount_label}</th>
                            <th>{item_tax_label}</th>
                            <th>{item_line_total_label}</th>
                        </tr>

                        <tr data-iterate="item">
                            <td>{item_row_number}</td>
                            <!-- Don't remove this column as it's needed for the row commands -->
                            <td>{item_description}</td>
                            <td>{item_quantity}</td>
                            <td>{item_price}</td>
                            <td>{item_discount}</td>
                            <td>{item_tax}</td>
                            <td>{item_line_total}</td>
                        </tr>

                    </table>

                </section>

                <section id="sums">

                    <table>
                        <tr>
                            <th>{amount_subtotal_label}</th>
                            <td>{amount_subtotal}</td>
                        </tr>

                        <tr data-iterate="tax">
                            <th>{tax_name}</th>
                            <td>{tax_value}</td>
                        </tr>

                        <tr class="amount-total">
                            <!-- {amount_total_label} -->
                            <td colspan="2">{amount_total}</td>
                        </tr>

                        <!-- You can use attribute data-hide-on-quote="true" to hide specific information on quotes.
                 For example Invoicebus doesn't need amount paid and amount due on quotes  -->
                        <tr data-hide-on-quote="true">
                            <th>{amount_paid_label}</th>
                            <td>{amount_paid}</td>
                        </tr>

                        <tr data-hide-on-quote="true" class="due-amount">
                            <th>{amount_due_label}</th>
                            <td>{amount_due}</td>
                        </tr>

                    </table>

                </section>

                <div class="clearfix"></div>

                <section id="terms">

                    <span>{terms_label}</span>
                    <div>{terms}</div>

                </section>

                <div class="payment-info">
                    <div>{payment_info1}</div>
                    <div>{payment_info2}</div>
                    <div>{payment_info3}</div>
                    <div>{payment_info4}</div>
                    <div>{payment_info5}</div>
                </div>
            </div>
        </div>--%>

        <%--<table class="auto-style1" border="3">
            <tr>
                <td class="auto-style2">iuuiiisiuii</td>
                <td class="auto-style3">nfkdjhdid</td>
            </tr>
            <tr>
                <td class="auto-style4">uhihihihai</td>
                <td class="auto-style5">nvsvihivhie</td>
            </tr>
        </table>--%>
    </asp:Panel>

    <%--<link href="http://cdn.invoicebus.com/generator/generator.min.js?data=data.js" rel="stylesheet" />--%>
</asp:Content>

