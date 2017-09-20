<%@ Page Title="" Language="C#" MasterPageFile="~/LDPAdmin/AdminSite.Master" AutoEventWireup="true" CodeBehind="SEO.aspx.cs" Inherits="LDP.ROOT.LDPAdmin.SEOPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
    <script src="/assets/JS/Admin/SEO.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <div class="box-content mrt30 mrb15 seo-content">
        <div class="box-header box-header-icon pd15" data-background-color="green">
            <i class="material-icons">apps</i>
        </div>
        <div class="box-body pd15">
            <h4 class="box-content-title pdb15 mrt0 mrb5">Quản lý SEO 
                <div class="pull-right">
                    <button class="btn btn-danger panel-heading-btn-right" id="btnSave" type="button">Cập nhật</button>
                </div>
            </h4>
            <div id="seo-box" class="mrt30">
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group label-floating">
                            <label class="control-label">Trang</label>
                            <asp:DropDownList ID="ddlCategory" CssClass="form-control" runat="server"></asp:DropDownList>
                            <span class="material-input"></span>
                        </div>
                    </div>
                    <div class="col-md-8">
                        <div class="form-group label-floating">
                            <label class="control-label">Tên</label>
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                            <span class="material-input"></span>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group label-floating">
                            <label class="control-label">SeName</label>
                            <asp:TextBox ID="txtSeName" runat="server" CssClass="form-control"></asp:TextBox>
                            <span class="material-input"></span>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group label-floating">
                            <label class="control-label">MetaTitle</label>
                            <asp:TextBox ID="txtMetaTitle" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100"></asp:TextBox>
                            <span class="material-input"></span>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group label-floating">
                            <label class="control-label">MetaKeywords</label>
                            <asp:TextBox ID="txtMetaKeywords" runat="server" CssClass="form-control" TextMode="MultiLine" Height="150"></asp:TextBox>
                            <span class="material-input"></span>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group label-floating">
                            <label class="control-label">MetaDescription</label>
                            <asp:TextBox ID="txtMetaDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Height="200"></asp:TextBox>
                            <span class="material-input"></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
