using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Wagering.Models
{
    public static class Helpers
    {
        public static string ToURL(this string name)
        {
            return Regex.Replace(name, "[^a-zA-Z0-9_.:]+", string.Empty).ToLower();
        }

        public static string ToString(this List<WagerHostBid> hosts, int cutoff)
        {
            if (hosts.Count > cutoff)
                return $"{string.Join(", ", hosts.GetRange(0, cutoff - 1))}, +{hosts.Count - cutoff + 1} more...";
            return string.Join(", ", hosts);
        }

        public static string ToString(this decimal? value, string nullResult)
        {
            if (value.HasValue)
                return value.Value.ToString();
            return nullResult;
        }

        public static string ToTime(this DateTime date)
        {
            TimeSpan span = DateTime.Now - date;

            if (span.TotalMinutes <= 1)
                return "Just now";

            string hourComponent;
            string minuteComponent;

            if (span.Hours == 1)
                hourComponent = "1 hour";
            else
                hourComponent = $"{span.Hours} hours";
            if (span.Minutes == 1)
                minuteComponent = "1 minute";
            else
                minuteComponent = $"{span.Minutes} minutes";

            return $"{hourComponent} {minuteComponent} ago";
        }
    }
}
