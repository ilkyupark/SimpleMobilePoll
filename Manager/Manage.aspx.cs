using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleMobilePoll.DAL.DataSet1TableAdapters;

namespace SimpleMobilePoll.Manager
{
    public partial class Manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 관리자 인증. 암호 "7788"을 입력하면 통과
                if (Request["pass"] != "7788")
                {
                    Response.Redirect("/Default.aspx", true);
                }
            }

            string myState = string.Empty;


            //Application.Lock();
            //ApplicationState intMyState = (ApplicationState)Application["MyState"];
            //if (intMyState == ApplicationState.BeforePoll)
            //    PollState.Text = "여론조사 시작 전";
            //else if (intMyState == ApplicationState.PollOngoing)
            //    PollState.Text = "여론조사 진행 중";
            //else
            //    PollState.Text = "여론조사 종료";
            //Application.UnLock();

            PollStateTableAdapter adapter = new PollStateTableAdapter();
            int currentState = (int)adapter.GetData().Rows[0]["PollState"];

            if (currentState == (int)ApplicationState.BeforePoll)
                PollState.Text = "여론조사 시작 전";
            else if (currentState == (int)ApplicationState.PollOngoing)
                PollState.Text = "여론조사 진행 중";
            else
                PollState.Text = "여론조사 종료";
        }

        protected void StartPollButton_Click(object sender, EventArgs e)
        {
            //Application.UnLock();
            // 현재 상태가 시작 전 상태일때만 시작 처리

            PollStateTableAdapter adapter = new PollStateTableAdapter();
            int currentState = (int)adapter.GetData().Rows[0]["PollState"];

            if (currentState == (int)ApplicationState.BeforePoll)
            {
                adapter.UpdateQuery((int)ApplicationState.PollOngoing);
                MessageLabel.Text = "여론조사를 시작합니다.";

                PollState.Text = "여론조사 시작 전";
            }

            //Application.UnLock();
        }

        protected void EndPollButton_Click(object sender, EventArgs e)
        {
            //Application.UnLock();
            // 현재 상태가 진행 중 상태일때만 시작 처리

            PollStateTableAdapter adapter = new PollStateTableAdapter();
            int currentState = (int)adapter.GetData().Rows[0]["PollState"];

            if (currentState == (int)ApplicationState.PollOngoing)
            {
                adapter.UpdateQuery((int)ApplicationState.PollEnd);
                MessageLabel.Text = "여론조사를 종료했습니다.";

                PollState.Text = "여론조사 종료";
            }

            //Application.UnLock();
        }

        protected void InitButton_Click(object sender, EventArgs e)
        {
            // 데이터베이스를 모두 비우고 상태를 여론조사 시작 전 상태로 만든다.
            var opinionAdapter = new OpinionTableAdapter();
            opinionAdapter.DeleteQuery();

            var userAdapter = new UserTableAdapter();
            userAdapter.DeleteQuery();

            //Application.Lock();
            //Application["MyState"] = ApplicationState.BeforePoll;
            //Application.UnLock();

            PollStateTableAdapter adapter = new PollStateTableAdapter();
            adapter.UpdateQuery((int)ApplicationState.BeforePoll);

            MessageLabel.Text = "여론조사 시작 전 상태입니다.";

            PollState.Text = "여론조사 시작 전";
        }
    }
}