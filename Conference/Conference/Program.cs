using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
namespace Conference
{
    class Program
    {
        static void Main(string[] args)
        {
            var schedule = new Schedule
            {
                Rooms = new List<Room>
                {
                    new Room{No=1},new Room{No=2},new Room{No=3}
                }
            };
            while (true)
            {
                WriteLine("input conference start time");
                var lineStr = ReadLine();
                if (!ValidateTime(lineStr,out DateTime startTime))
                {
                    continue;
                }

                WriteLine("input conference end time");
                lineStr = ReadLine();
                if (!ValidateTime(lineStr, out DateTime endTime))
                {
                    continue;
                }

                var conference = new Conference { StartTime = startTime, EndTime = endTime };

                if (!schedule.ScheduleConference(conference))
                {
                    WriteLine("not idle time");
                }
                else
                {
                    WriteLine($"Success-------------------{conference.RoomNo}!");
                }
            }
        }

        static bool ValidateTime(string timeStr,out DateTime time)
        {
            if (!DateTime.TryParse(timeStr, out time))
            {
                WriteLine("wrong time");
                return false;
            }
            return true;
        }
    }

    public class Schedule
    {
        public List<Room> Rooms { get; set; }

        public bool ScheduleConference(Conference conference)
        {
            foreach (var room in Rooms)
            {
                if (room.CheckConferenceTime(conference))
                {
                    conference.RoomNo = room.No;
                    return true;
                }
            }
            return false;
        }
    }

    public class Room
    {
        public int No { get; set; }
        public DateTime OpenStartTime { get; set; } = DateTime.Parse("9:00:00");
        public DateTime OpenEndTime { get; set; } = DateTime.Parse("16:00:00");
        public List<Conference> Conferences { get; set; } = new List<Conference>();
        public List<IdleTimeSpan> IdleTimeSpans { get; set; }

        public Room()
        {
            IdleTimeSpans = new List<IdleTimeSpan> { new IdleTimeSpan { StartTime = OpenStartTime, EndTime = OpenEndTime } };
        }

        public bool CheckConferenceTime(Conference conference)
        {
            if (conference.StartTime < OpenStartTime)
            {
                return false;
            }

            if (conference.EndTime > OpenEndTime)
            {
                return false;
            }

            foreach (var timeSpan in IdleTimeSpans)
            {
                if (timeSpan.StartTime <= conference.StartTime && timeSpan.EndTime >= conference.EndTime)
                {
                    Conferences.Add(conference);
                    ReCountIdleTimeSpan();
                    return true;
                }
            }
            return false;
        }

        void ReCountIdleTimeSpan()
        {
            IdleTimeSpans.Clear();
            var scheduledConfs = Conferences.OrderBy(x => x.StartTime).ToList();
            IdleTimeSpan curTimeSpan = null;
            for (int i = 0; i <= scheduledConfs.Count; i++)
            {
                if (i == 0)
                {
                    curTimeSpan = new IdleTimeSpan { StartTime = OpenStartTime };
                }
                if (i< scheduledConfs.Count && scheduledConfs[i].StartTime > curTimeSpan.StartTime)
                {
                    curTimeSpan.EndTime = scheduledConfs[i].StartTime;
                    IdleTimeSpans.Add(curTimeSpan);
                    curTimeSpan = new IdleTimeSpan { StartTime = scheduledConfs[i].EndTime };
                }
                if (i == scheduledConfs.Count &&scheduledConfs.LastOrDefault().EndTime<OpenEndTime)
                {
                    curTimeSpan = new IdleTimeSpan { StartTime = scheduledConfs.LastOrDefault().EndTime, EndTime = OpenEndTime };
                }
            }
        }
    }

    public class Conference
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Name { get; set; }
        public int RoomNo { get; set; }
    }

    public class IdleTimeSpan
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
