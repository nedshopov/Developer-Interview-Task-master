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
      public string OpenStatusText {
         get
         {
            return StatusText();
         }
      }

      /// <summary>
      /// Opening hours for today.
      /// </summary>
      public List<int> OpeningHoursToday { get; set; }

      private bool OpenNow()
      {
         bool isOpen;
         switch(DateTime.Now.DayOfWeek)
         {
            case DayOfWeek.Sunday:
               isOpen = IsOpenAtThisTime(SundayOpeningHours);
               break;
            case DayOfWeek.Monday:
               isOpen = IsOpenAtThisTime(MondayOpeningHours);
               break;
            case DayOfWeek.Tuesday:
               isOpen = IsOpenAtThisTime(TuesdayOpeningHours);
               break;
            case DayOfWeek.Wednesday:
               isOpen = IsOpenAtThisTime(WednesdayOpeningHours);
               break;
            case DayOfWeek.Thursday:
               isOpen = IsOpenAtThisTime(ThursdayOpeningHours);
               break;
            case DayOfWeek.Friday:
               isOpen = IsOpenAtThisTime(FridayOpeningHours);
               break;
            case DayOfWeek.Saturday:
               isOpen = IsOpenAtThisTime(SaturdayOpeningHours);
               break;
            default:
               isOpen = false;
               break;
         }
         return isOpen;
      }

      private bool IsOpenAtThisTime(List<int> workingHours)
      {
         bool isOpen = false;
         if(HasWorkingHours(workingHours))
         {
            isOpen = (DateTime.Now.Hour >= workingHours[0] && DateTime.Now.Hour < workingHours[1]);
         }
         return isOpen;
      }

      private bool OpenOnDay(DayOfWeek day)
      {
         bool isOpen;
         switch(day)
         {
            case DayOfWeek.Sunday:
               isOpen = HasWorkingHours(SundayOpeningHours);
               break;
            case DayOfWeek.Monday:
               isOpen = HasWorkingHours(MondayOpeningHours);
               break;
            case DayOfWeek.Tuesday:
               isOpen = HasWorkingHours(TuesdayOpeningHours);
               break;
            case DayOfWeek.Wednesday:
               isOpen = HasWorkingHours(WednesdayOpeningHours);
               break;
            case DayOfWeek.Thursday:
               isOpen = HasWorkingHours(ThursdayOpeningHours);
               break;
            case DayOfWeek.Friday:
               isOpen = HasWorkingHours(FridayOpeningHours);
               break;
            case DayOfWeek.Saturday:
               isOpen = HasWorkingHours(SaturdayOpeningHours);
               break;
            default:
               isOpen = false;
               break;
         }
         return isOpen;
      }

      private bool HasWorkingHours(List<int> openHours)
      {
         return (openHours[0] != 0 && openHours[1] != 0);
      }

      private string StatusText()
      {
         string statusText;
         if(IsOpen)
         {
            statusText = "OPEN TODAY UNTIL " + GetClosingTime();
         }
         else
         {
            DayOfWeek nextWorkingDay = FindNextOpenDay();
            statusText = $"Reopens {nextWorkingDay.ToString()} at {GetOpeningTime(nextWorkingDay)}"; 
         }
         return statusText;
      }

      private string GetOpeningTime(DayOfWeek day)
      {
         string hour;
         switch(day)
         {
            case DayOfWeek.Sunday:
               hour = GetAmPmFormat(SundayOpeningHours[0]);
               break;
            case DayOfWeek.Monday:
               hour = GetAmPmFormat(MondayOpeningHours[0]);
               break;
            case DayOfWeek.Tuesday:
               hour = GetAmPmFormat(TuesdayOpeningHours[0]);
               break;
            case DayOfWeek.Wednesday:
               hour = GetAmPmFormat(WednesdayOpeningHours[0]);
               break;
            case DayOfWeek.Thursday:
               hour = GetAmPmFormat(ThursdayOpeningHours[0]);
               break;
            case DayOfWeek.Friday:
               hour = GetAmPmFormat(FridayOpeningHours[0]);
               break;
            case DayOfWeek.Saturday:
               hour = GetAmPmFormat(SaturdayOpeningHours[0]);
               break;
            default:
               hour = string.Empty;
               break;
         }
         return hour;
      }

      private DayOfWeek FindNextOpenDay()
      {
         DateTime date = DateTime.Today;
         while(!OpenOnDay(date.DayOfWeek))
         {
            date = date.AddDays(1);
         }
         return date.DayOfWeek;
      }

      private string GetClosingTime()
      {
         string hour;
         switch(DateTime.Today.DayOfWeek)
         {
            case DayOfWeek.Sunday:
               hour = GetAmPmFormat(SundayOpeningHours[1]);
               break;
            case DayOfWeek.Monday:
               hour = GetAmPmFormat(MondayOpeningHours[1]);
               break;
            case DayOfWeek.Tuesday:
               hour = GetAmPmFormat(TuesdayOpeningHours[1]);
               break;
            case DayOfWeek.Wednesday:
               hour = GetAmPmFormat(WednesdayOpeningHours[1]);
               break;
            case DayOfWeek.Thursday:
               hour = GetAmPmFormat(ThursdayOpeningHours[1]);
               break;
            case DayOfWeek.Friday:
               hour = GetAmPmFormat(FridayOpeningHours[1]);
               break;
            case DayOfWeek.Saturday:
               hour = GetAmPmFormat(SaturdayOpeningHours[1]);
               break;
            default:
               hour = string.Empty;
               break;
         }
         return hour;
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

