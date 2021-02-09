using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Rwa.Mvc.Models
{
    public class ProjectViewModel
    {
        private const string TimeFormat = "hh\\:mm";

        private readonly ProjektDjelatnik projektDjelatnik;

        public string Project => projektDjelatnik.Projekt.Naziv;
        public string TotalWorkHours
        {
            get
            {
                var hours = projektDjelatnik.RadniSatis.Select(r => r.KrajTrajanja - r.PocetakTrajanja);
                var totalHours = TimeSpan.FromMilliseconds(hours.Sum(s => s.TotalMilliseconds));
                return totalHours.ToString(TimeFormat);
            }
        }

        public IEnumerable<WorkHourViewModel> WorkHours
        {
            get
            {
                var workHours = projektDjelatnik.RadniSatis;

                return workHours.Select(s => 
                {
                    return new WorkHourViewModel(s.IDRadniSati, s.PocetakTrajanja, s.KrajTrajanja);
                });
            }
        }


        public Djelatnik User => projektDjelatnik.Djelatnik;

        public ProjectViewModel(ProjektDjelatnik projektDjelatnik)
        {
            this.projektDjelatnik = projektDjelatnik;
        }
    }
}