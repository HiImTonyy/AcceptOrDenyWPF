using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AcceptOrDenyLibrary
{
    public class Work
    {
        private int dayWage;
        private int currentDay;
        private int currentLineup;
        private int totalLineup;
        private double bonusPayTotal;
        public int todaysCorrectJudgements;
        public int todaysIncorrectJudgements;
        private int weeksCorrectJudgements;
        private int weeksIncorrectJudgements;
        private int alltimeCorrectJudgements;
        private int alltimeIncorrectJudgements;
        private double moneyPerCorrectChoice;
        private int moneyPerWrongChoice;
        private int moneyLost;
        private double moneyGained;
        private double mostMoneyMade;
        private int highestPerfectCorrectStreak;
        private int currentPerfectCorrectSteak;
        private int highestPerfectIncorrectStreak;
        private int currentPerfectIncorrectSteak;
        private double totalMoneyMade;


        public int DayWage
        {
            get { return dayWage; }
            set { dayWage = value; }
        }

        public int CurrentDay
        {
            get { return currentDay; }
            set { currentDay = value; }
        }

        public int CurrentLineup
        {
            get { return currentLineup; }
            set { currentLineup = value; }
        }

        public int TotalLineup
        {
            get { return totalLineup; }
            set { totalLineup = value; }
        }

        public double BonusPayTotal
        {
            get { return bonusPayTotal; }
            set { bonusPayTotal = value; }
        }

        public int TodaysCorrectJudgements
        {
            get { return todaysCorrectJudgements; }
            set { todaysCorrectJudgements = value; }
        }

        public int TodaysIncorrectJudgements
        {
            get { return todaysIncorrectJudgements; }
            set { todaysIncorrectJudgements = value; }
        }

        public int WeeksCorrectJudgements
        {
            get { return weeksCorrectJudgements; }
            set { weeksCorrectJudgements = value; }
        }

        public int WeeksIncorrectJudgements
        {
            get { return weeksIncorrectJudgements; }
            set { weeksIncorrectJudgements = value; }
        }

        public int AlltimeCorrectJudgements
        {
            get { return alltimeCorrectJudgements; }
            set { alltimeCorrectJudgements = value; }
        }

        public int AlltimeIncorrectJudgements
        {
            get { return alltimeIncorrectJudgements; }
            set { alltimeIncorrectJudgements = value; }
        }

        public double MoneyPerCorrectChoice
        {
            get { return moneyPerCorrectChoice; }
            set { moneyPerCorrectChoice = value; }
        }

        public int MoneyPerWrongChoice
        {
            get { return moneyPerWrongChoice; }
            set { moneyPerWrongChoice = value; }
        }

        public int MoneyLost
        {
            get { return moneyLost; }
            set { moneyLost = value; }
        }

        public double MoneyGained
        {
            get { return moneyGained; }
            set { moneyGained = value; }
        }

        public double MostMoneyMade
        {
            get { return mostMoneyMade; }
            set { mostMoneyMade = value; }
        }

        public int HighestPerfectCorrectStreak
        {
            get { return highestPerfectCorrectStreak; }
            set { highestPerfectCorrectStreak = value; }
        }

        public int CurrentPerfectCorrectStreak
        {
            get { return currentPerfectCorrectSteak; }
            set { currentPerfectCorrectSteak = value; }
        }

        public int HighestPerfectIncorrectStreak
        {
            get { return highestPerfectIncorrectStreak; }
            set { highestPerfectIncorrectStreak = value; }
        }

        public int CurrentPerfectIncorrectStreak
        {
            get { return currentPerfectIncorrectSteak; }
            set { currentPerfectIncorrectSteak = value; }
        }

        public double TotalMoneyMade
        {
            get { return totalMoneyMade; }
            set {  totalMoneyMade = value; }
        }

        public Work()
        {
            dayWage = 50;
            currentDay = 1;
            currentLineup = 10;
            totalLineup = 10;
            bonusPayTotal = 0;
            todaysCorrectJudgements = 0;
            todaysIncorrectJudgements = 0;
            weeksCorrectJudgements = 0;
            weeksIncorrectJudgements = 0;
            alltimeCorrectJudgements = 0;
            alltimeIncorrectJudgements = 0;
            moneyPerCorrectChoice = 0.25;
            moneyPerWrongChoice = 10;
            moneyLost = 0;
            moneyGained = 0;
            mostMoneyMade = 0;
            highestPerfectCorrectStreak = 0;
            currentPerfectCorrectSteak = 0;
            highestPerfectIncorrectStreak = 0;
            currentPerfectIncorrectSteak = 0;
            totalMoneyMade = 0;
        }



        public static bool MakeChoice(string choice, NPC npc, Work work)
        {
            if (choice == "accept" && npc.IsIllegal == false)
            {
                IncreaseCorrectJudgement(work);
                return false;
            }
            else if (choice == "deny" && npc.IsIllegal == true)
            {
                IncreaseCorrectJudgement(work);
                return false;
            }
            else if (choice == "deny" && npc.IsIllegal == false)
            {

                IncreaseIncorrectJudgement(work, npc);
                npc.ErrorTypeString = "... oh wait, THEY WERE LEGAL!";
                return true;
            }
            else return true;
        }

        public static void IncreaseCorrectJudgement(Work work)
        {
            Debug.WriteLine("Correct!");
            work.TodaysCorrectJudgements++;
        }

        public static bool IncreaseIncorrectJudgement(Work work, NPC npc)
        {
            Debug.WriteLine($"Incorrect! the error was their {npc.ErrorTypeString}.");
            work.TodaysIncorrectJudgements++;
            return true;
        }

        public static void TallyUpMoney(Player player, Work work)
        {
            work.BonusPayTotal = work.MoneyPerCorrectChoice * work.TodaysCorrectJudgements;
            work.MoneyLost = work.MoneyPerWrongChoice * work.TodaysIncorrectJudgements;

            work.MoneyGained = work.DayWage + work.bonusPayTotal - work.MoneyLost;
            player.Money = player.Money + work.MoneyGained;
        }

        public static string BossEndOfDayComment(Player player, Work work)
        {
            string bossComment = "pizza";
            int commentSelected = 0;

            List<string> worstDayComments = new List<string>();

            worstDayComments.Add($"YOU FUCKING SUCKED TODAY {player.FirstName.ToUpper()}! DO BETTER NEXT TIME... IF THERE IS A NEXT TIME.");
            worstDayComments.Add($"WHAT THE HELL HAPPEND TODAY? YOU FUCKED UP BAD {player.FirstName.ToUpper()}!");
            worstDayComments.Add($"YOU ARE A MSSIVE FAILURE TO OUR COUNTRY {player.FirstName.ToUpper()}!");

            List<string> badDayComments = new List<string>();

            badDayComments.Add($"Hey {player.FirstName}, you tired? WELL TOO BAD! DO BETTER NEXT TIME.");
            badDayComments.Add($"Your not a complete failure, but... you should have done better today {player.FirstName}.");
            badDayComments.Add($"You get a C today {player.FirstName}. that is all.");

            List<string> averageDayComments = new List<string>();

            averageDayComments.Add($"Not great, but not bad either today {player.FirstName}.");
            averageDayComments.Add($"Decent work today {player.FirstName}.");
            averageDayComments.Add($"Eh.. today could have been worse.");

            List<string> goodDayComments = new List<string>();

            goodDayComments.Add($"Good job today {player.FirstName}!");
            goodDayComments.Add($"Keep up the good work {player.FirstName}!");
            goodDayComments.Add($"{player.FirstName}, you did well today. I hope to see that tomorrow as well!");

            List<string> bestDayComments = new List<string>();

            bestDayComments.Add($"You did flawless today {player.FirstName}. well done!");
            bestDayComments.Add($"Amazing job today {player.FirstName}!");
            bestDayComments.Add($"{player.FirstName}, you did beyond amazing today. I hope to see more of that!");

            if (work.TodaysIncorrectJudgements == work.TotalLineup)
            {
                commentSelected = Logic.RollRandomNumber(0, worstDayComments.Count);
                bossComment = worstDayComments[commentSelected];

                work.currentPerfectIncorrectSteak++;
                work.currentPerfectCorrectSteak = 0;
                if (work.CurrentPerfectIncorrectStreak > work.HighestPerfectIncorrectStreak) { work.HighestPerfectIncorrectStreak = work.CurrentPerfectIncorrectStreak;}
            }
            else if (work.TodaysCorrectJudgements == work.TotalLineup)
            {
                commentSelected = Logic.RollRandomNumber(0, bestDayComments.Count );
                bossComment = bestDayComments[commentSelected];

                work.currentPerfectCorrectSteak++;
                work.currentPerfectIncorrectSteak = 0;
                if (work.CurrentPerfectCorrectStreak > work.HighestPerfectCorrectStreak) { work.HighestPerfectCorrectStreak = work.CurrentPerfectCorrectStreak; }
            }
            else if (work.TodaysIncorrectJudgements == work.TodaysCorrectJudgements)
            {
                commentSelected = Logic.RollRandomNumber(0, averageDayComments.Count);
                bossComment = averageDayComments[commentSelected];
            }
            else if (work.TodaysCorrectJudgements > work.TodaysIncorrectJudgements)
            {
                commentSelected = Logic.RollRandomNumber(0, goodDayComments.Count);
                bossComment = goodDayComments[commentSelected];
            }
            else if (work.TodaysIncorrectJudgements > work.TodaysCorrectJudgements)
            {
                commentSelected = Logic.RollRandomNumber(0, badDayComments.Count);
                bossComment = badDayComments[commentSelected];
            }

            return bossComment;
        }
    }
}
