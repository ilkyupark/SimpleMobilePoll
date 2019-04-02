using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleMobilePoll.DAL.DataSet1TableAdapters;

namespace SimpleMobilePoll
{
    public partial class PollResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // url 직접 접근 차단
            //if (Request.Url.OriginalString.Contains("PollResult.aspx") == true)
            //{
            //    Response.Redirect("Default.aspx", true);
            //}

            // 데이터베이스에서 데이터를 가져와서 여론조사 결과를 보여준다.
            //ApplicationState intMyState = 0;
            //Application.Lock();
            //intMyState = (ApplicationState)Application["MyState"];
            //Application.UnLock();

            PollStateTableAdapter adapter = new PollStateTableAdapter();
            int currentState = (int)adapter.GetData().Rows[0]["PollState"];

            if (currentState == (int)ApplicationState.PollEnd)
            {
                var resultAdapter = new ResultSourceTableAdapter();
                var table = resultAdapter.GetData();

                // 참여자 총원 수
                int AllPeopleNumber = table.Rows.Count;

                // 남여 수
                int maleNumber = 0, femaleNumber = 0;
                foreach (var g in table)
                {
                    if (g.Gender == "남자")
                        maleNumber++;
                    else
                        femaleNumber++;
                }

                // 직급별 임직원 수
                int position1 = 0, position2 = 0, position3 = 0, position4 = 0, position5 = 0;

                foreach (var p in table)
                {
                    if (p.Position == "사원")
                        position1++;
                    else if (p.Position == "대리")
                        position2++;
                    else if (p.Position == "과장")
                        position3++;
                    else if (p.Position == "부장")
                        position4++;
                    else
                        position5++;
                }

                // 성별에 따른 긍정 부정
                int intMalePoitive = 0, intMaleNegative = 0;
                int intFemalePositive = 0, intFemaleNegative = 0;

                foreach (var i in table)
                {
                    if (i.Gender == "남자")
                    {
                        if (i.Opinion == 4 || i.Opinion == 5)
                            intMalePoitive++;
                        else if (i.Opinion == 1 || i.Opinion == 2)
                            intMaleNegative++;
                    }
                    else
                    {
                        if (i.Opinion == 4 || i.Opinion == 5)
                            intFemalePositive++;
                        else if (i.Opinion == 1 || i.Opinion == 2)
                            intFemaleNegative++;
                    }
                }

                double doubleMalePositive = 0d, doubleMaleNegative = 0d, doubleFemalePositive = 0d, doubleFemaleNegative = 0d;


                if (!(AllPeopleNumber == 0))
                {
                    doubleMalePositive = (double)intMalePoitive / (double)AllPeopleNumber * 100;
                    doubleMaleNegative = (double)intMaleNegative / (double)AllPeopleNumber * 100;

                    doubleFemalePositive = (double)intFemalePositive / (double)AllPeopleNumber * 100;
                    doubleFemaleNegative = (double)intFemaleNegative / (double)AllPeopleNumber * 100;
                }

                // 직급에 따른 긍정 부정
                int intPosition1Positive = 0, intPosition2Positive = 0, intPosition3Positive = 0, intPosition4Positive = 0, intPosition5Positive = 0;
                int intPosition1Negative = 0, intPosition2Negative = 0, intPosition3Negative = 0, intPosition4Negative = 0, intPosition5Negative = 0;

                foreach(var i in table)
                {
                    if (i.Position == "사원")
                    {
                        if (i.Opinion == 4 || i.Opinion == 5)
                        {
                            intPosition1Positive++;
                        }
                        else if (i.Opinion == 1 || i.Opinion == 2)
                        {
                            intPosition1Negative++;
                        }
                    }
                    else if (i.Position == "대리")
                    {
                        if (i.Opinion == 4 || i.Opinion == 5)
                        {
                            intPosition2Positive++;
                        }
                        else if (i.Opinion == 1 || i.Opinion == 2)
                        {
                            intPosition2Negative++;
                        }

                    }
                    else if (i.Position == "과장")
                    {
                        if (i.Opinion == 4 || i.Opinion == 5)
                        {
                            intPosition3Positive++;
                        }
                        else if (i.Opinion == 1 || i.Opinion == 2)
                        {
                            intPosition3Negative++;
                        }

                    }
                    else if (i.Position == "부장")
                    {
                        if (i.Opinion == 4 || i.Opinion == 5)
                        {
                            intPosition4Positive++;
                        }
                        else if (i.Opinion == 1 || i.Opinion == 2)
                        {
                            intPosition4Negative++;
                        }

                    }
                    else // 임원
                    {
                        if (i.Opinion == 4 || i.Opinion == 5)
                        {
                            intPosition5Positive++;
                        }
                        else if (i.Opinion == 1 || i.Opinion == 2)
                        {
                            intPosition5Negative++;
                        }
                    }

                }

                double doublePosition1Positive = 0d, doublePosition1Negative = 0d;
                double doublePosition2Positive = 0d, doublePosition2Negative = 0d;
                double doublePosition3Positive = 0d, doublePosition3Negative = 0d;
                double doublePosition4Positive = 0d, doublePosition4Negative = 0d;
                double doublePosition5Positive = 0d, doublePosition5Negative = 0d;


                if (!(AllPeopleNumber == 0))
                {
                    doublePosition1Positive = (double)intPosition1Positive / (double)AllPeopleNumber * 100;
                    doublePosition1Negative = (double)intPosition1Negative / (double)AllPeopleNumber * 100;

                    doublePosition2Positive = (double)intPosition2Positive / (double)AllPeopleNumber * 100;
                    doublePosition2Negative = (double)intPosition2Negative / (double)AllPeopleNumber * 100;

                    doublePosition3Positive = (double)intPosition3Positive / (double)AllPeopleNumber * 100;
                    doublePosition3Negative = (double)intPosition3Negative / (double)AllPeopleNumber * 100;

                    doublePosition4Positive = (double)intPosition4Positive / (double)AllPeopleNumber * 100;
                    doublePosition4Negative = (double)intPosition4Negative / (double)AllPeopleNumber * 100;
                    
                    doublePosition5Positive = (double)intPosition5Positive / (double)AllPeopleNumber * 100;
                    doublePosition5Negative = (double)intPosition5Negative / (double)AllPeopleNumber * 100;
                }

                // 결과 표시
                AllNumberLabel.Text = AllPeopleNumber.ToString();
                MaleNumberLabel.Text = maleNumber.ToString();
                FemaleNumberLabel.Text = femaleNumber.ToString();

                Position1NumberLabel.Text = position1.ToString();
                Position2NumberLabel.Text = position2.ToString();
                Position3NumberLabel.Text = position3.ToString();
                Position4NumberLabel.Text = position4.ToString();
                Position5NumberLabel.Text = position5.ToString();

                MalePositive.Text = doubleMalePositive.ToString();
                MaleNegative.Text = doubleMaleNegative.ToString();

                FemalePositive.Text = doubleFemalePositive.ToString();
                FemaleNegative.Text = doubleFemaleNegative.ToString();

                Position1Positive.Text = doublePosition1Positive.ToString();
                Position1Negative.Text = doublePosition1Negative.ToString();

                Position2Positive.Text = doublePosition2Positive.ToString();
                Position2Negative.Text = doublePosition2Negative.ToString();

                Position3Positive.Text = doublePosition3Positive.ToString();
                Position3Negative.Text = doublePosition3Negative.ToString();

                Position4Positive.Text = doublePosition4Positive.ToString();
                Position4Negative.Text = doublePosition4Negative.ToString();

                Position5Positive.Text = doublePosition5Positive.ToString();
                Position5Negative.Text = doublePosition5Negative.ToString();
            }
        }
    }
}

