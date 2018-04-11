using SacramentMeetingPlanner.Models;
using System;
using System.Linq;

namespace SacramentMeetingPlanner.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MeetingContext context)
        {
            context.Database.EnsureCreated();

            // Look for any members.
            if (context.sacramentMeetingPlans.Any())
            {
                return;   // DB has been seeded
            }
           // var member = new Member[]
           //{
           // new Member{FirstName="Carson",LastName="Alexander",TalkDate=DateTime.Parse("2005-09-01")},
           // new Member{FirstName="Meredith",LastName="Alonso",TalkDate=DateTime.Parse("2002-09-01")},
           // new Member{FirstName="Arturo",LastName="Anand",TalkDate=DateTime.Parse("2003-09-01")},
           // new Member{FirstName="Gytis",LastName="Barzdukas",TalkDate=DateTime.Parse("2002-09-01")},
           // new Member{FirstName="Yan",LastName="Li",TalkDate=DateTime.Parse("2002-09-01")},

           //};
           // foreach (Member s in member)
           // {
           //     context.Members.Add(s);
           // }
           // context.SaveChanges();
            var sacramentMeetingPlan = new SacramentMeetingPlan[]
            {
            new SacramentMeetingPlan{Date=DateTime.Parse("2018-04-08"), OpeningPrayer="Wally Herrera", ClosingPrayer="Johnny Bingham",
                OpeningHymn="Stand All Amazed", SacramentHymn="Keep the commandments", ClosingHymn="Praise to the Man", LeaderName="Bishop Sells", Presiding="President Robinson", Topic="Priesthood Prevlidges",
                Announcements="Baby Blessing", Talk1="Glad Smith", Talk2="Lyndsey Henderson", Talk3="Tank Henderson" }
            };
            foreach (SacramentMeetingPlan s in sacramentMeetingPlan)
            {
                context.sacramentMeetingPlans.Add(s);
            }
            context.SaveChanges();

        }
    } }