using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WoWGenGUI
{
    static class Program
    {
        public static string faction;
        public static string race;
        public static string job;
        public static string spec;
        public static string job_img;
        public static string spec_img;
        public static string[] faction_list = { "Alliance", "Horde" };
        public static string[] alliance_list = { "Dwarf", "Gnome", "Human", "Night Elf" };
        public static string[] horde_list = { "Orc", "Tauren", "Troll", "Undead" };


        // Alliance job lists.
        public static List<string[]> allianceJobList = new List<string[]>
        {
            new string[] {"Hunter", "Paladin", "Priest", "Rogue", "Warrior" }, // Dwarf classes.
            new string[] {"Mage", "Rogue", "Warlock", "Warrior"}, // Gnome classes.
            new string[] {"Mage" , "Paladin", "Priest", "Rogue", "Warlock", "Warrior"}, // Human classes.
            new string[] {"Druid" , "Hunter", "Priest", "Rogue", "Warrior"} // Night elf classes.
        };

        // Horde job lists.
        public static List<string[]> hordeJobList = new List<string[]>
        {
            new string[] {"Hunter", "Rogue", "Shaman", "Warlock", "Warrior" }, // Orc classes.
            new string[] {"Druid", "Hunter", "Shaman", "Warrior"}, // Tauren classes.
            new string[] {"Hunter" , "Mage", "Priest", "Rogue", "Shaman", "Warrior"}, // Troll classes.
            new string[] {"Mage" , "Priest", "Rogue", "Warlock", "Warrior"} // Undead classes.
        };

        // Specialization dictionary (string, string[]).
        public static Dictionary<string, string[]> specList = new Dictionary<string, string[]>
        {
            {"Druid", new string[] {"Balance", "Feral", "Restoration"} },
            {"Hunter", new string[] {"Beastmastery", "Marksmanship", "Survival"} },
            {"Mage", new string[] {"Arcane", "Fire", "Frost"} },
            {"Paladin", new string[] {"Holy", "Protection", "Retribution"} },
            {"Priest", new string[] {"Discipline", "Holy", "Shadow"} },
            {"Rogue", new string[] {"Assassination", "Combat", "Subtlety"} },
            {"Shaman", new string[] {"Elemental", "Enhancement", "Restoration"} },
            {"Warlock", new string[] {"Affliction", "Demonology", "Destruction"} },
            {"Warrior", new string[] {"Arms", "Fury", "Protection"} }
        };

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void GenChar()
        {

            Random random = new Random();

            // Generate faction.
            int factionIndex = random.Next(faction_list.Length);
            faction = faction_list[factionIndex];
            Console.WriteLine("Faction: " + faction);

            // Generate race.
            int raceIndex;
            if (faction == "Alliance")
            {
                raceIndex = random.Next(alliance_list.Length);
                race = alliance_list[raceIndex];
            }
            else
            {
                raceIndex = random.Next(horde_list.Length);
                race = horde_list[raceIndex];
            }
            Console.WriteLine("Race: " + race);

            // Generate class.
            int jobIndex;
            if (faction == "Alliance")
            {
                jobIndex = random.Next(allianceJobList[raceIndex].Length);
                job = allianceJobList[raceIndex][jobIndex];
            }
            else
            {
                jobIndex = random.Next(hordeJobList[raceIndex].Length);
                job = hordeJobList[raceIndex][jobIndex];
            }
            Console.WriteLine("Job: " + job);

            // Generate spec.
            int specIndex;
            specIndex = random.Next(3);
            specList.TryGetValue(job, out string[] classSpecList);
            spec = classSpecList[specIndex];
            Console.WriteLine("Spec: " + spec);

            // Generate image paths.
            job_img = job.ToLower();
            spec_img = job.ToLower() + "_" + spec.ToLower();

            Console.ReadLine();
        }
    }
}
