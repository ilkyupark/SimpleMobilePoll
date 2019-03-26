using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace SimpleMobilePoll
{
    public enum ApplicationState { BeforePoll, PollOngoing, PollEnd }

    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // 응용 프로그램 시작 시 실행되는 코드
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // 응용프로그램 상태 정의
            //
            // 여론조사 시작 전 : BeforePoll
            // 여론조사 진행 중 : PollOngoing
            // 여론조사 종료 : PollEnd
            //
            // 응용프로그램의 상태는 BeforePoll 에서 시작하여 관리자의 관리활동에 따라 변하고,
            // 응용프로그램은 현재 상태에 맞는 동작을 한다.

            Application.Lock();
            Application["MyState"] = ApplicationState.BeforePoll;   // 응용프로그램 상태 초기화
            Application.UnLock();
        }
    }
}