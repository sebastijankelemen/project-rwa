using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Rwa.Mvc.Models
{
    public sealed class WorkHourViewModel
    {
        private const string TimeFormat = "hh\\:mm";

        private readonly int id;
        private readonly DateTime startDate;
        private readonly DateTime endDate;

        public int Id => id;

        public string TimePeriod
        {
            get
            {
                return $"{startDate.ToString(TimeFormat)}-{endDate.ToString(TimeFormat)}";
            }
        }

        public string Duration
        {
            get
            {
                var duration = endDate - startDate;
                return duration.ToString(TimeFormat);
            }
        }

        public WorkHourViewModel(int id, DateTime startDate, DateTime endDate)
        {
            this.id = id;
            this.startDate = startDate;
            this.endDate = endDate;
        }

        
    }
}