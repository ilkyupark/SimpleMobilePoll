using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleMobilePoll.DAL.DataSet1TableAdapters;

namespace SimpleMobilePoll
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 여론조사 진행 상태에 따른 분기

                //Application.Lock();
                //ApplicationState myState = (ApplicationState)Application["MyState"];
                //Application.UnLock();

                PollStateTableAdapter adapter = new PollStateTableAdapter();
                int currentState = (int)adapter.GetData().Rows[0]["PollState"];

                if (currentState == (int)ApplicationState.BeforePoll)         // 여론조사 시작 전
                    Response.Redirect("BeforePoll.aspx", true);
                else if (currentState == (int)ApplicationState.PollEnd)       // 여론조사 종료
                    Response.Redirect("PollResult.aspx", true);
                else // 여론조사 진행 중
                {
                    // IP 주소를 검사해서 이미 참여했는지 검사
                    string userIPAddress = Request.UserHostAddress;

                    var userAdapter = new UserTableAdapter();
                    var table = userAdapter.GetData();
                    foreach (var row in table)
                    {
                        if (row.IPAddress == userIPAddress)
                        {
                            Response.Redirect("PollOngoing.aspx", true);
                        }
                    }
                }
            }
            else
            {
                // 모든 정보와 답을 빠짐없이 입력했는지 체크
                // 성별
                if (MaleRadioButton.Checked == false && FemaleRadioButton.Checked == false)
                {
                    GenderAlertLabel.Text = "성별을 반드시 선택해야 합니다.";

                }

                // 직급
                if (Position1RadioButton.Checked == false
                    && Position2RadioButton.Checked == false
                    && Position3RadioButton.Checked == false
                    && Position4RadioButton.Checked == false
                    && Position5RadioButton.Checked == false)
                {
                    PositionAlertLabel.Text = "직급을 반드시 선택해야 합니다.";
                }
                // 질문
                if (QuestionRadioButton1.Checked == false
                    && QuestionRadioButton2.Checked == false
                    && QuestionRadioButton3.Checked == false
                    && QuestionRadioButton4.Checked == false
                    && QuestionRadioButton5.Checked == false
                    )
                {
                    QuestionAlertLabel.Text = "질문의 답을 반드시 선택해야 합니다.";
                }
                else
                {
                    // 여론조사 참여자와 의견에 대한 정보를 데이터베이스에 입력
                    // 참여자 정보
                    string gender = string.Empty;
                    string position = string.Empty;
                    string IPAddress = Request.UserHostAddress;

                    // 성별
                    if (MaleRadioButton.Checked == true)
                        gender = "남자";
                    else
                        gender = "여자";

                    // 직급
                    if (Position1RadioButton.Checked == true)
                        position = "사원";
                    else if (Position2RadioButton.Checked == true)
                        position = "대리";
                    else if (Position3RadioButton.Checked == true)
                        position = "과장";
                    else if (Position4RadioButton.Checked == true)
                        position = "부장";
                    else
                        position = "임원";

                    var userAdapter = new UserTableAdapter();
                    userAdapter.Insert(gender, position, IPAddress);

                    int lastUserId = (int)userAdapter.GetLastUserId();

                    // 질문의 답 입력
                    int opinion = 0;
                    if (QuestionRadioButton1.Checked == true)
                        opinion = 1;
                    else if (QuestionRadioButton2.Checked == true)
                        opinion = 2;
                    else if (QuestionRadioButton3.Checked == true)
                        opinion = 3;
                    else if (QuestionRadioButton4.Checked == true)
                        opinion = 4;
                    else
                        opinion = 5;

                    var opinionAdapter = new OpinionTableAdapter();
                        opinionAdapter.Insert(lastUserId, opinion);
                }

                Response.Redirect("EndPoll.aspx");
            }
        }
    }
}