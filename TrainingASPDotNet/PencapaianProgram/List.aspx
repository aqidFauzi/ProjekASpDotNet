<%@ Page Title="" Language="C#" MasterPageFile="~/Metronic.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="TrainingASPDotNet.PencapaianProgram.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- BEGIN: Subheader -->
    <div class="m-subheader">
        <div class="d-flex align-items-center">
            <div class="mr-auto">
                <h3 class="m-subheader_title">
                    Pencapaian Program
                </h3>
            </div>
        </div>
    </div>
    <!-- END: Subheader -->
    <div class="m-content">
        <asp:HyperLink ID="ButangTambah" NavigateUrl="~/PencapaianProgram/Add.aspx" CssClass="btn btn-primary" runat="server">Tambah</asp:HyperLink>
    </div>

    <table class="table">
        <tr>
            <td>Kod</td>
            <td>Tarikh</td>
            <td>Lulus</td>
            <td>Jenis</td>
        </tr>
    </table>
</asp:Content>
