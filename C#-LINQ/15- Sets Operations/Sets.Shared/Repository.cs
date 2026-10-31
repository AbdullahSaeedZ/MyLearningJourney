using System;
using System.Collections.Generic;

namespace Sets.Shared
{
    public static class Repository
    {
        public static Meeting Meeting1 => new Meeting
        {
            Title = "Meeting - 1",
            Date = new DateOnly(2022, 03, 02),
            StartAt = new TimeOnly(08, 0, 0),
            EndAt = new TimeOnly(09, 0, 0),
            Participants = new List<Employee>
            {
                new Employee { EmployeeNo = "a10", Name = "Ruba Ali" },
                new Employee { EmployeeNo = "a11", Name = "Sana Sayed" },
                new Employee { EmployeeNo = "a12", Name = "Abeer Omar" }
            }
        };

        public static Meeting Meeting2 => new Meeting
        {
            Title = "Meeting - 2",
            Date = new DateOnly(2022, 03, 02),
            StartAt = new TimeOnly(09, 0, 0),
            EndAt = new TimeOnly(10, 0, 0),
            Participants = new List<Employee>
            {
                new Employee { EmployeeNo = "a11", Name = "Sana Sayed" },
                new Employee { EmployeeNo = "a13", Name = "Rashed Sameh" },
                new Employee { EmployeeNo = "a15", Name = "Omniya Sayed" }
            }
        };

        public static Meeting Meeting3 => new Meeting
        {
            Title = "Meeting - 3",
            Date = new DateOnly(2022, 03, 02),
            StartAt = new TimeOnly(10, 0, 0),
            EndAt = new TimeOnly(11, 0, 0),
            Participants = new List<Employee>
            {
                new Employee { EmployeeNo = "a12", Name = "Abeer Omar" },
                new Employee { EmployeeNo = "a14", Name = "Khalid Mansour" },
                new Employee { EmployeeNo = "a16", Name = "Mona Adel" }
            }
        };

        public static Meeting Meeting7 => new Meeting
        {
            Title = "Meeting - 7",
            Date = new DateOnly(2022, 03, 03),
            StartAt = new TimeOnly(11, 0, 0),
            EndAt = new TimeOnly(12, 0, 0),
            Participants = new List<Employee>
            {
                new Employee { EmployeeNo = "a10", Name = "Ruba Ali" },
                new Employee { EmployeeNo = "a14", Name = "Khalid Mansour" },
                new Employee { EmployeeNo = "a17", Name = "Fahad Salem" }
            }
        };

        public static List<Meeting> All => new List<Meeting>
        {
            Meeting1,
            Meeting2,
            Meeting3,
            Meeting7
        };
    }
}