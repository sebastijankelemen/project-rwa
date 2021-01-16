using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Rwa.Mvc.Models
{
    public class ProjectViewModel
    {
        private readonly ProjektDjelatnik projektDjelatnik;

        public string Name => projektDjelatnik.Projekt.Naziv;
        public string TotalTimeDuration
        {
            get
            {
                var duration = projektDjelatnik.RadniSati.GetValueOrDefault();
                return duration.ToString("HH:mm");
            }
        }

        public Djelatnik User => projektDjelatnik.Djelatnik;

        public ProjectViewModel(ProjektDjelatnik projektDjelatnik)
        {
            this.projektDjelatnik = projektDjelatnik;
        }


    }
}