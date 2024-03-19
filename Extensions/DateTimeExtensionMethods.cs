using System.Text.RegularExpressions;

namespace QuestionsAndAnswers.Extensions
{
    public static class DateTimeExtensionMethods
    {
        public static string FormatTimeDifference(this DateTime questionTime)
        {
            var currentCulture = Thread.CurrentThread.CurrentCulture;

            TimeSpan timeDifference = DateTime.UtcNow - questionTime;

            if (timeDifference.TotalSeconds < 60)
            {
                return currentCulture.Name == "pt" ? "agora mesmo" : "just now";
            }
            else if (timeDifference.TotalMinutes < 60)
            {
                int minutes = (int)timeDifference.TotalMinutes;
                return currentCulture.Name == "pt" ? $"perguntado há {minutes} minuto{(minutes != 1 ? "s" : "")}" : $"asked {minutes} minute{(minutes != 1 ? "s" : "")} ago";
            }
            else if (timeDifference.TotalHours < 24)
            {
                int hours = (int)timeDifference.TotalHours;
                return currentCulture.Name == "pt" ? $"perguntado há {hours} hora{(hours != 1 ? "s" : "")}" : $"asked {hours} hour{(hours != 1 ? "s" : "")} ago";
            }
            else if (timeDifference.TotalDays < 365)
            {
                int days = (int)timeDifference.TotalDays;
                return currentCulture.Name == "pt" ? $"perguntado há {days} dia{(days != 1 ? "s" : "")}" : $"asked {days} day{(days != 1 ? "s" : "")} ago";
            }
            else
            {
                int years = (int)(timeDifference.TotalDays / 365);
                return currentCulture.Name == "pt" ? $"perguntado há {years} ano{(years != 1 ? "s" : "")}" : $"asked {years} year{(years != 1 ? "s" : "")} ago";
            }
        }
    }
}

