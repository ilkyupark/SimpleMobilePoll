<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SimpleMobilePoll.Manager.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="margin-top: 20px">관리자 페이지</h2>
    <p>현재 여론조사 상태 : <asp:Label ID="PollState" runat="server" Text=""></asp:Label>
        
    </p>
    <div id="ControlButtons" style="margin-top: 20px">
        <asp:Label ID="MessageLabel" runat="server" Text=""></asp:Label>
        <asp:Button ID="StartPollButton" runat="server" Text="여론조사 시작" OnClick="StartPollButton_Click" /><br /><br />
        <asp:Button ID="EndPollButton" runat="server" Text="여론조사 종료" OnClick="EndPollButton_Click" /><br /><br />
        <asp:Button ID="InitButton" runat="server" Text="여론조사 초기화" OnClick="InitButton_Click" />
    </div>
    
</asp:Content>
