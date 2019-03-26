<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PollResult.aspx.cs" Inherits="SimpleMobilePoll.PollResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="margin-top: 20px">여론조사 결과</h2>
    <div id="NumberOfPeople">
        <p>총 참여인원 : <asp:Label ID="AllNumberLabel" runat="server" Text=""></asp:Label>명</p>
        <p>남자 : <asp:Label ID="MaleNumberLabel" runat="server" Text=""></asp:Label>명
           여자 : <asp:Label ID="FemaleNumberLabel" runat="server" Text=""></asp:Label>명</p>
        <p>사원 : <asp:Label ID="Position1NumberLabel" runat="server" Text=""></asp:Label>명
           대리 : <asp:Label ID="Position2NumberLabel" runat="server" Text=""></asp:Label>명
           과장 : <asp:Label ID="Position3NumberLabel" runat="server" Text=""></asp:Label>명
           부장 : <asp:Label ID="Position4NumberLabel" runat="server" Text=""></asp:Label>명
           임원 : <asp:Label ID="Position5NumberLabel" runat="server" Text=""></asp:Label>명
        </p>
    </div>
    <div id="PositiveNegative" style="margin-top: 20px">
        <h3>성별</h3>
        <p>남자 긍정 <asp:Label ID="MalePositive" runat="server" Text=""></asp:Label>% 부정 <asp:Label ID="MaleNegative" runat="server" Text=""></asp:Label>%<br />
           여자 긍정 <asp:Label ID="FemalePositive" runat="server" Text=""></asp:Label>% 부정 <asp:Label ID="FemaleNegative" runat="server" Text=""></asp:Label>%
        </p>
        <h3>직급별</h3>
        <p>
            사원 긍정 <asp:Label ID="Position1Positive" runat="server" Text=""></asp:Label>% 부정 <asp:Label ID="Position1Negative" runat="server" Text=""></asp:Label>%<br />
            대리 긍정 <asp:Label ID="Position2Positive" runat="server" Text=""></asp:Label>% 부정 <asp:Label ID="Position2Negative" runat="server" Text=""></asp:Label>%<br />
            과장 긍정 <asp:Label ID="Position3Positive" runat="server" Text=""></asp:Label>% 부정 <asp:Label ID="Position3Negative" runat="server" Text=""></asp:Label>%<br />
            부장 긍정 <asp:Label ID="Position4Positive" runat="server" Text=""></asp:Label>% 부정 <asp:Label ID="Position4Negative" runat="server" Text=""></asp:Label>%<br />
            임원 긍정 <asp:Label ID="Position5Positive" runat="server" Text=""></asp:Label>% 부정 <asp:Label ID="Position5Negative" runat="server" Text=""></asp:Label>%<br />
        </p>
    </div>
</asp:Content>
