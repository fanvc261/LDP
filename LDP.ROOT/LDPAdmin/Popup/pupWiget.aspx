<%@ Page Title="" Language="C#" MasterPageFile="~/LDPAdmin/Popup/AdminPopup.Master" AutoEventWireup="true" CodeBehind="pupWiget.aspx.cs" Inherits="LDP.ROOT.LDPAdmin.pupWiget" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
    <script src="/assets/JS/Admin/pupWiget.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="text-center pup-title">
        <asp:Literal ID="ltrTitle" runat="server" ></asp:Literal>
    </div>
    <div class="pup-content wiget-content">
        <div class="box-body pd15">
            <div id="wiget-box">
                <textarea id="txtContent" runat="server" rows="10" cols="30" style="height: 440px" aria-label="editor"> adasdasdas
                                </textarea>
            </div>
        </div>
    </div>
    <div class="text-center pup-ctr">
        <button class="btn btn-danger" id="btnCancel" type="button">Hủy</button>
        <button class="btn btn-danger" id="btnSave" type="button">Lưu</button>
    </div>
</asp:Content>
