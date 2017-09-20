<%@ Page Title="" Language="C#" MasterPageFile="~/LDPAdmin/AdminSite.Master" AutoEventWireup="true" CodeBehind="Embed.aspx.cs" Inherits="LDP.ROOT.LDPAdmin.EmbedPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
    <script src="/assets/JS/Admin/Embed.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <div class="box-content mrt30 mrb15 embed-content">
        <div class="box-header box-header-icon pd15" data-background-color="green">
            <i class="material-icons">apps</i>
        </div>
        <div class="box-body pd15">
            <h4 class="box-content-title pdb15 mrt0 mrb5">Quản lý Embed 
                <div class="pull-right">
                    <button class="btn btn-danger panel-heading-btn-right" id="btnSave" type="button">Cập nhật</button>
                </div>
            </h4>
            <div id="embed-box" class="mrt30">
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group label-floating">
                            <label class="control-label">Tiêu đề trang</label>
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                            <span class="material-input"></span>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 text-center">
                        <ul class="nav nav-pills nav-pills-icons">
                            <li class="active">
                                <a href="#header" role="tab" data-value="2" data-toggle="tab" aria-expanded="true">
                                    <i class="material-icons">info</i> Header
                                </a>
                            </li>
                            <li class="">
                                <a href="#body" role="tab" data-value="3" data-toggle="tab" aria-expanded="false">
                                    <i class="material-icons">location_on</i> Body
                                </a>
                            </li>
                            <li class="">
                                <a href="#footer" role="tab" data-value="4" data-toggle="tab" aria-expanded="false">
                                    <i class="material-icons">gavel</i> Footer
                                </a>
                            </li>
                        </ul>
                        <div class="form-group label-floating text-left">
                            <label class="control-label">Embed</label>
                            <asp:TextBox ID="txtEmbed" runat="server" CssClass="form-control"  TextMode="MultiLine" Height="200"></asp:TextBox>
                            <span class="material-input"></span>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
