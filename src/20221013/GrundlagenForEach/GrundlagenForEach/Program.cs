using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrundlagenForEach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Participant[] teilnehmerListe;

            teilnehmerListe = CreateDummyParticipant(2);

            DisplayParticipants(teilnehmerListe);
        }

        private static void DisplayParticipants(Participant[] participantList)
        {
            foreach(Participant teilnehmer in participantList)
            {
                Console.WriteLine($"{teilnehmer.Name} {teilnehmer.Surname} | {teilnehmer.Location} | {teilnehmer.Birthday.ToShortDateString()}");
            }
        }

        private static Participant[] CreateDummyParticipant(int participantCount)
        {
            Participant[] dummyList = new Participant[participantCount];

            //initialize items
            for (int i = 0; i < dummyList.Length; i++)
            {
                dummyList[i] = new Participant();

                dummyList[i].Name = $"Teilnehmer {i + 1}";
                dummyList[i].Surname = "Black";
                dummyList[i].Location = "Dornbirn";

                dummyList[i].Birthday = new DateTime(2000, 1, 1);
                dummyList[i].Birthday = dummyList[i].Birthday.AddDays(i * 9);
            }

            return dummyList;
        }
    }
}
