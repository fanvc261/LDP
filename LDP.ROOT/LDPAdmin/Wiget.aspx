<%@ Page Title="" Language="C#" MasterPageFile="~/LDPAdmin/AdminSite.Master" AutoEventWireup="true" CodeBehind="Wiget.aspx.cs" Inherits="LDP.ROOT.LDPAdmin.WigetPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
    <script src="/assets/JS/Admin/Wiget.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <div class="box-content mrt30 mrb15 wiget-content">
        <div class="box-header box-header-icon pd15" data-background-color="green">
            <i class="material-icons">apps</i>
        </div>
        <div class="box-body pd15">
            <h4 class="box-content-title pdb15 mrt0 mrb5">Global Sales by Top Locations</h4>
            <div class="row">
                <div class="col-md-3 wiget-content-left">
                    <div class="panel panel-default">
                        <div class="panel-heading">Events</div>
                        <div class="panel-body">
                            <asp:Repeater ID="rptWiget" runat="server" >
                                <HeaderTemplate>
                                    <ul class="nav">
                                </HeaderTemplate>
                                <ItemTemplate >
                                    <li><a class="text-15" data_id="<%# Eval("Id") %>" data_guid="<%# Eval("WigetGuid") %>" href="#" alt="<%# Eval("Name") %>"> <%# Eval("Name") %></a></li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>

                <div class="col-md-9 wiget-content-right">
                    <div class="panel panel-default">
                        <div class="panel-heading">Events</div>
                        <div class="panel-body">

                            <div id="example">
                                <textarea id="txtContent" rows="10" cols="30" style="height: 440px" aria-label="editor">
                                </textarea> 
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
