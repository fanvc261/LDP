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
                        <div class="panel-heading">
                            Danh sách<div class="pull-right">
                                <button class="btn btn-danger panel-heading-btn-right" id="btnAddNew" type="button">Thêm mới</button>
                            </div>
                        </div>
                        <div class="panel-body">
                            <asp:Repeater ID="rptWiget" runat="server">
                                <HeaderTemplate>
                                    <ul class="nav nav-wiget">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li><a class="text-15" data_id="<%# Eval("Id") %>" data_guid="<%# Eval("WigetGuid") %>" href="#" alt="<%# Eval("Name") %>"><%# Eval("Name") %></a></li>
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
                        <div class="panel-heading">
                            <span id="editTitle">Thêm mới</span>
                            <div class="pull-right">
                                <button class="btn btn-danger panel-heading-btn-right" id="btnDelete" type="button">Xóa</button>
                                <button class="btn btn-danger panel-heading-btn-right" id="btnSave" type="button">Thêm mới</button>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div id="wiget-box">
                                <div class="row">
                                    <div class="col-md-9">
                                        <div class="form-group label-floating">
                                            <label class="control-label">Tên</label>
                                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                                            <span class="material-input"></span>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group label-floating">
                                            <label class="control-label">Thứ tự </label>
                                            <asp:TextBox ID="txtRank" runat="server" CssClass="form-control" type="number"></asp:TextBox>
                                            <span class="material-input"></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3" id="divContainer">
                                        <div class="form-group label-floating">
                                            <label class="control-label">Khu vực</label>
                                            <asp:DropDownList ID="ddlContainer" CssClass="form-control" runat="server"></asp:DropDownList>
                                            <span class="material-input"></span>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group label-floating">
                                            <label class="control-label">Class</label>
                                            <asp:TextBox ID="txtBodyClass" runat="server" CssClass="form-control"></asp:TextBox>
                                            <span class="material-input"></span>
                                        </div>
                                    </div>
                                    
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <div class="togglebutton">
                                                <label>
                                                    <asp:CheckBox ID="cbHide" runat="server" />
                                                    Ẩn
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <div class="togglebutton">
                                                <label>
                                                    <asp:CheckBox ID="cbAllPage" runat="server" />
                                                    Dùng chung
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <textarea id="txtContent" runat="server" rows="10" cols="30" style="height: 440px" aria-label="editor">
                                </textarea>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
