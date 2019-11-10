using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Unzone.Models;

namespace Unzone.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public IList<TimeInfo> Locations { get; }

        public MainViewModel()
        {
            Locations = new ObservableCollection<TimeInfo>();
            Locations.Add(new TimeInfo() { UserName = "David", CurrentTime = "10:40", Location = "Taipei", TimeZoneId = "AEST", AMPM = "AM" });
            Locations.Add(new TimeInfo() { UserName = "Ben", CurrentTime = "10:45", Location = "Taipei", TimeZoneId = "CST", AMPM = "AM" });
            Locations.Add(new TimeInfo() { UserName = "Danel", CurrentTime = "11:40", Location = "Taipei", TimeZoneId = "CST", AMPM = "AM" });
            Locations.Add(new TimeInfo() { UserName = "Albert", CurrentTime = "23:01", Location = "usa", TimeZoneId = "PST", AMPM = "PM" });
        }
    }
}
