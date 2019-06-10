using System;
using System.Collections.Generic;

namespace JuniorInterviewTask.Models
{
   public class HelperServiceModel
   {
      public HelperServiceModel()
      {
         WorkingDays = WorkingDays.Other;
      }

      public Guid Id { get; set; }
      public string Title { get; set; }
      public string Description { get; set; }
      public string TelephoneNumber { get; set; }

      public List<int> MondayOpeningHours { get; set; }
      public List<int> TuesdayOpeningHours { get; set; }
      public List<int> WednesdayOpeningHours { get; set; }
      public List<int> ThursdayOpeningHours { get; set; }
      public List<int> FridayOpeningHours { get; set; }
      public List<int> SaturdayOpeningHours { get; set; }
      public List<int> SundayOpeningHours { get; set; }

      /// <summary>
      /// The working schedule.
      /// </summary>
      public WorkingDays WorkingDays { get; set; }

      /// <summary>
      /// Whether it is open today.
      /// </summary>
      public bool IsOpen
      {
         get { return OpenNow(); }
      }

      /// <summary>
      /// Text for the open status.
      /// </summary>
      public string OpenStatusText
      {
         get
         {
            return StatusText();
         }
      }

      /// <summary>
      /// A simplistic method for getting the city name from the title.
      /// </summary>
      public string City
      {
         get
         {
            if(Title.Contains("London"))
            {
               return "london";
            }
            else
            {
               return Title.Replace(" Helper Service", "").Replace(" ", "").Trim().ToLowerInvariant();
            } 
         }
      }
      /// <summary>
      /// Opening hours for today.
      /// </summary>
      public List<int> OpeningHoursToday { get; set; }

      private string StatusText()
      {
         string statusText;
         if(IsOpen)
         {
            statusText = "OPEN TODAY UNTIL " + GetAmPmFormat(GetClosingTime(DateTime.Today.DayOfWeek));
         }
         else
         {
            DayOfWeek nextWorkingDay = FindNextOpenDay();
            statusText = $"Reopens {nextWorkingDay.ToString()} at {GetAmPmFormat(GetOpeningTime(nextWorkingDay))}"; 
         }
         return statusText;
      }

      private DayOfWeek FindNextOpenDay()
      {
         DateTime date = GetOpeningTime(DateTime.Today.DayOfWeek) >= DateTime.Now.Hour ? DateTime.Today : DateTime.Today.AddDays(1);
         while(!OpenOnDay(date.DayOfWeek))
         {
            date = date.AddDays(1);
         }
         return date.DayOfWeek;
      }

      private bool OpenNow()
      {
         bool isOpen = false;
         if(HasWorkingHours(GetWorkingHoursForDay(DateTime.Now.DayOfWeek)))
         {
            isOpen = (DateTime.Now.Hour >= GetWorkingHoursForDay(DateTime.Now.DayOfWeek)[0] && DateTime.Now.Hour < GetWorkingHoursForDay(DateTime.Now.DayOfWeek)[1]);
         }
         return isOpen;
      }

      private bool OpenOnDay(DayOfWeek day)
      {
         return HasWorkingHours(GetWorkingHoursForDay(day));
      }

      private bool HasWorkingHours(IList<int> openHours)
      {
         return (openHours[0] != 0 && openHours[1] != 0);
      }

      private int GetOpeningTime(DayOfWeek day)
      {
         return GetWorkingHoursForDay(day)[0];
      }

      private int GetClosingTime(DayOfWeek day)
      {
         return GetWorkingHoursForDay(day)[1];
      }

      private IList<int> GetWorkingHoursForDay(DayOfWeek day)
      {
         IList<int> hours;
         switch(day)
         {
            case DayOfWeek.Sunday:
               hours = SundayOpeningHours;
               break;
            case DayOfWeek.Monday:
               hours = MondayOpeningHours;
               break;
            case DayOfWeek.Tuesday:
               hours = TuesdayOpeningHours;
               break;
            case DayOfWeek.Wednesday:
               hours = WednesdayOpeningHours;
               break;
            case DayOfWeek.Thursday:
               hours = ThursdayOpeningHours;
               break;
            case DayOfWeek.Friday:
               hours = FridayOpeningHours;
               break;
            case DayOfWeek.Saturday:
               hours = SaturdayOpeningHours;
               break;
            default:
               hours = new List<int> {0, 0};
               break;
         }
         return hours;
      }

      private string GetAmPmFormat(int hour)
      {
         string hourInAmPm;
         if(hour > 12)
         {
            hourInAmPm = hour.ToString() + "pm";
         }
         else
         {
            hourInAmPm = hour.ToString() + "am";
         }
         return hourInAmPm;
      }
   }
}

