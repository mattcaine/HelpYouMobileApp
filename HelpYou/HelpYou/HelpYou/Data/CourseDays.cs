using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace HelpYou.Data
{
   public class CourseDays
    {

        ObservableCollection<Day> Days = new ObservableCollection<Day>();

        public CourseDays()
        {
            Days.Add(new Day
            {
                Id = 1,
                Name = "Monday",
                IsSelected = false
            });
            Days.Add(new Day
            {
                Id = 2,
                Name = "Tuesday",
                IsSelected = false
            });
            Days.Add(new Day
            {
                Id = 3,
                Name = "Wednesday",
                IsSelected = false
            });
            Days.Add(new Day
            {
                Id = 4,
                Name = "Thursday",
                IsSelected = false
            });
            Days.Add(new Day
            {
                Id = 5,
                Name = "Friday",
                IsSelected = false
            });
            Days.Add(new Day
            {
                Id = 6,
                Name = "Saturday",
                IsSelected = false
            });
            Days.Add(new Day
            {
                Id = 7,
                Name = "Sunday",
                IsSelected = false
            });
        }

        public ObservableCollection<Day> GetDays()
        {
            return Days;
        }

        public string GetName(int Id)
        {
            return Days.Where(d => d.Id == Id).FirstOrDefault().Name;
        }

        public ObservableCollection<Day> GetSelectedDays()
        {
            ObservableCollection<Day> SelectedDays = new ObservableCollection<Day>();
            foreach (Day day in Days)
            {
                if (day.IsSelected)
                {
                    SelectedDays.Add(day);
                }
            }

            return SelectedDays;
        }

        public string GetSelectedDaysToString()
        {
            string SelectedDays = "";
            foreach (Day day in Days)
            {
                if (day.IsSelected)
                {
                    if (string.IsNullOrEmpty(SelectedDays))
                    {
                        SelectedDays = day.Id.ToString();
                    }
                    else
                    {
                        SelectedDays = SelectedDays + "," + day.Id.ToString();
                    }
                }
            }

            return SelectedDays;
        }

        public void SetSelectedValue(int Id, bool SelectedValue)
        {
            Days.Where(d => d.Id == Id).FirstOrDefault().IsSelected = SelectedValue;
        }
    }
}
