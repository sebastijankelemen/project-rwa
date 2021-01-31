using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Rwa.Mvc.Models
{
    public class ProjectViewModel
    {
        private readonly ProjektDjelatnik projektDjelatnik;

        public string Project => projektDjelatnik.Projekt.Naziv;
        public string TotalWorkHours
        {
            get
            {
                var endDate = projektDjelatnik?.RadniSati1?.KrajTrajanja;
                var startDate = projektDjelatnik?.RadniSati1?.PocetakTrajanja;

                if(!endDate.HasValue || !startDate.HasValue)
                {
                    return string.Empty;
                }

                var total = (endDate - startDate);

                return total.Value.ToString("HH:mm");
            }
        }



        public Djelatnik User => projektDjelatnik.Djelatnik;

        public ProjectViewModel(ProjektDjelatnik projektDjelatnik)
        {
            this.projektDjelatnik = projektDjelatnik;
        }


    }
}