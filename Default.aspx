<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SimpleMobilePoll._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <p style="margin-top: 20px">
        여론조사 페이지 방문을 환영합니다!<br />
        본 여론조사는 익명으로 진행되며, <b>한번만</b> 참여할 수 있습니다.<br />
        자신의 성별과 직급을 입력한 뒤 질문에 답해주세요.<br />
        결과는 여론조사가 끝난 뒤에 확인할 수 있습니다.
    </p>
    <div id="PersonalInfo">
        <p>1. 당신의 성별은 무엇입니까?<asp:Label ID="GenderAlertLabel" runat="server" ForeColor="#CC0000"></asp:Label></p>
        <asp:RadioButton ID="MaleRadioButton" GroupName="Gender" Text="남자" runat="server" />
        <asp:RadioButton ID="FemaleRadioButton" GroupName="Gender" Text="여자" runat="server" />
        <p>2. 당신의 직급은 무엇입니까?<asp:Label ID="PositionAlertLabel" runat="server" ForeColor="#CC0000"></asp:Label></p>
        <asp:RadioButton ID="Position1RadioButton" GroupName="Position" Text="사원" runat="server" />
        <asp:RadioButton ID="Position2RadioButton" GroupName="Position" Text="대리" runat="server" />
        <asp:RadioButton ID="Position3RadioButton" GroupName="Position" Text="과장" runat="server" />
        <asp:RadioButton ID="Position4RadioButton" GroupName="Position" Text="부장" runat="server" />
        <asp:RadioButton ID="Position5RadioButton" GroupName="Position" Text="임원" runat="server" />
    </div>

    <div id="Question">
        <h2>질문</h2>
        <p>나는 아침에 회사에 출근하는 것이 행복하다.<asp:Label ID="QuestionAlertLabel" runat="server" ForeColor="#CC0000"></asp:Label></p>
        <asp:RadioButton ID="QuestionRadioButton1" GroupName="Question" Text="매우 그렇지 않다" runat="server" />
        <asp:RadioButton ID="QuestionRadioButton2" GroupName="Question" Text="그렇지 않다" runat="server" />
        <asp:RadioButton ID="QuestionRadioButton3" GroupName="Question" Text="보통" runat="server" />
        <asp:RadioButton ID="QuestionRadioButton4" GroupName="Question" Text="그렇다" runat="server" />
        <asp:RadioButton ID="QuestionRadioButton5" GroupName="Question" Text="매우 그렇다" runat="server" />
    </div>
    <input id="SubmitButton" type="submit" runat="server" value="제출" style="margin-top: 20px" />
</asp:Content>
