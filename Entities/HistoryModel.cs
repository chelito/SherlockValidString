using System;

namespace Entities
{
    public class HistoryModel
    {
        public string Input { get; set; }

        public string Output { get; set; }

        public string Valid
        {
            get { return  Output != string.Empty ? "valid" : "not valid"; }
        }
        public string TimeStamp
        {
            get { return string.Format(@"{0:MM/dd/yyyy hh:mm tt}", DateTime.Now); }

        }
    }
}
