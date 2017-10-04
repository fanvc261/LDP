<%@ Page Title="" Language="C#" MasterPageFile="~/LDPAdmin/AdminSite.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="LDP.ROOT.LDPAdmin.UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
    <script src="/assets/JS/Admin/UserList.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <div class="box-content mrt30 mrb15 seo-content">
        <div class="box-header box-header-icon pd15" data-background-color="green">
            <i class="material-icons">apps</i>
        </div>
        <div class="box-body pd15">
            <h4 class="box-content-title pdb15 mrt0 mrb5">Quản lý người dùng 
                <div class="pull-right">
                    <button class="btn btn-danger panel-heading-btn-right" id="btnAddNew" type="button">Thêm mới</button>
                  <%--  <button class="btn btn-danger panel-heading-btn-right" id="btnDelete" type="button">Xóa</button>--%>
                </div>
            </h4>
            <div id="userlist-box" class="mrt30">
                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <div id="grdUser"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
