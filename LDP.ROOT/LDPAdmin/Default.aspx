<%@ Page Title="" Language="C#" MasterPageFile="~/LDPAdmin/AdminSite.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LDP.ROOT.LDPAdmin.RegInfoList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
    <script src="/assets/JS/Admin/RegInfoList.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <div class="box-content mrt30 mrb15 seo-content">
        <div class="box-header box-header-icon pd15" data-background-color="green">
            <i class="material-icons">apps</i>
        </div>
        <div class="box-body pd15">
            <h4 class="box-content-title pdb15 mrt0 mrb5">Danh sách đăng ký 
                <div class="pull-right">
                    <button class="btn btn-danger " id="btnDelete" type="button">Xóa</button>
                    <button class="btn btn-danger " id="btnExport" type="button">Export</button>
                </div>
            </h4>
            <div id="reginfolist-box" class="mrt30">
                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <div id="grdInfo"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
