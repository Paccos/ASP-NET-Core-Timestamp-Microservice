using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace TimeStampAPI.Model
{
    public class Timestamp
    {
        [JsonIgnore]
        public DateTime Date { get; set; }

        public string Utc => Date.ToString("ddd, dd MMM yyyy HH:mm:ss") + " GMT";
        public string Unix
        {
            get
            {
                var offset = new DateTimeOffset(Date);
                return offset.ToUnixTimeMilliseconds()
                             .ToString();
            }
        }


        public Timestamp(string dateStr)
        {
            var dateComponents = dateStr.Split("-");

            if (dateComponents.Length != 3)
            {
                try
                {
                    var unixMilliseconds = long.Parse(dateStr);
                    var offset = DateTimeOffset.FromUnixTimeMilliseconds(unixMilliseconds);

                    Date = offset.UtcDateTime;
                }
                catch
                {
                    throw new ArgumentException("dateStr has wrong format");
                }
            }
            else
            {
                try
                {
                    var ymd = dateComponents.Select(c => int.Parse(c)).ToArray();

                    Date = new DateTime(ymd[0], ymd[1], ymd[2], 0, 0, 0, DateTimeKind.Utc);
                }
                catch
                {
                    throw new ArgumentException("dateStr has wrong format");
                }
            }
        }
    }
}