<%@ Page Title="" Language="C#" MasterPageFile="~/LDPAdmin/AdminSite.Master" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="LDP.ROOT.LDPAdmin.UserEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
    <%--<script src="/assets/JS/Admin/UserEdit.js"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <div class="box-content mrt30 mrb15 seo-content">
        <div class="box-header box-header-icon pd15" data-background-color="green">
            <i class="material-icons">apps</i>
        </div>
        <div class="box-body pd15">
            <h4 class="box-content-title pdb15 mrt0 mrb5">Thông tin người dùng
                <div class="pull-right">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-danger panel-heading-btn-right" Text="Cập nhật" OnClick="btnSave_Click" />
                    <asp:Button ID="btnDel" runat="server" CssClass="btn btn-danger panel-heading-btn-right" Text="Xóa" OnClick="btnDel_Click" />
                    <input id="btnCancel" class="btn btn-danger panel-heading-btn-right" onclick="javascript: location.href = '/LDPAdmin/UserList.aspx';"   value="Hủy" type="button" />
                </div>
            </h4>
            <div id="seo-box" class="mrt30">
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group label-floating">
                            <label class="control-label">Tên truy cập</label>
                            <asp:TextBox ID="txtUserName" required="true" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                            <span class="material-input"></span>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group label-floating">
                            <label class="control-label">Mật khẩu</label>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>
                            <span class="material-input"></span>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">

                        <div class="form-group label-floating">
                            <label class="control-label">Họ tên</label>
                            <asp:TextBox ID="txtFullName" required="true" runat="server" CssClass="form-control"></asp:TextBox>
                            <span class="material-input"></span>
                        </div>
                    </div>
                </div>
                <div class="row">

                    <div class="col-md-12">
                        <div class="form-group label-floating">
                            <label class="control-label">Email</label>
                            <asp:TextBox ID="txtEmail" required="true" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                            <span class="material-input"></span>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <div class="togglebutton">
                                <label>
                                    <asp:CheckBox ID="cbActive" runat="server" />
                                    Active
                                </label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <div class="togglebutton">
                                <label>
                                    <asp:CheckBox ID="cbBlock" runat="server" />
                                    Khóa
                                </label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
