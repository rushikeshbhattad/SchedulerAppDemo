using System;
using System.IO;

namespace SchedulerAppDemo
{
    class Appointment
    {
        string Name;
        int year = 2020, month = 1, day = 1, hour = 0, min = 0;
        void WriteData(string Name, int year, int month, int day, int hour, int min)
        {
            FileStream fs = new FileStream(@"C:/Users/Admin/Desktop/appointment.dat", FileMode.Append, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(Name);
            bw.Write(year);
            bw.Write(month);
            bw.Write(day);
            bw.Write(hour);
            bw.Write(min);
            bw.Flush();
            bw.Close();
            fs.Close();
        }
        void ReadData()
        {
            FileStream fs = new FileStream(@"C:/Users/Admin/Desktop/appointment.dat", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            Console.WriteLine("leng" + fs.Length);
            try
            {
                while (true)
                {
                    Name = br.ReadString();
                    if (Name == null)
                    {
                        break;
                    }
                    year = br.ReadInt32();
                    month = br.ReadInt32();
                    day = br.ReadInt32();
                    hour = br.ReadInt32();
                    min = br.ReadInt32();
                    Console.WriteLine(Name + "\t" + day + "-" + month + "-" + year + "\t" + hour + ":" + min);
                }
            }
            catch (EndOfStreamException eose)
            {

            }
            br.Close();
            fs.Close();
        }
        internal void AddAppointment()
        {
            Console.Write("Enter Name of person to meet: ");
            Name = Console.ReadLine();
            Console.Write("Enter Year: ");
            year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Month: ");
            month = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Day: ");
            day = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Hour: ");
            hour = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Minuite: ");
            min = Convert.ToInt32(Console.ReadLine());
            WriteData(Name, year, month, day, hour, min);
        }
        internal void ViewAppointment()
        {
            ReadData();
        }
        internal void SearchAppointment(string search)
        {
            FileStream fs = new FileStream(@"C:/Users/Admin/Desktop/appointment.dat", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            try
            {
                while (true)
                {
                    Name = br.ReadString();
                    if (Name == null)
                    {
                        break;
                    }
                    year = br.ReadInt32();
                    month = br.ReadInt32();
                    day = br.ReadInt32();
                    hour = br.ReadInt32();
                    min = br.ReadInt32();
                    if (Name == search)
                    {
                        Console.WriteLine(Name + "\t" + day + "-" + month + "-" + year + "\t" + hour + ":" + min);
                    }
                }
            }
            catch(EndOfStreamException eose)
            {

            }
            br.Close();
            fs.Close();
        }
        internal void ExitApp()
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input, search;
        A:
            Console.WriteLine("A. Add appointment");
            Console.WriteLine("V. View appointment");
            Console.WriteLine("S. Search appointment");
            Console.WriteLine("E. Exit");
            Console.Write("Enter your choice: ");
            input = Console.ReadLine();
            Appointment appointment = new Appointment();
            switch (input)
            {
                case "A":
                    appointment.AddAppointment();
                    goto A;
                case "V":
                    appointment.ViewAppointment();
                    goto A;
                case "S":
                    Console.WriteLine("Enter search name: ");
                    search = Console.ReadLine();
                    appointment.SearchAppointment(search);
                    goto A;
                case "E":
                    appointment.ExitApp();
                    break;
                default:
                    Console.WriteLine("Please enter correct operation");
                    goto A;
            }
        }
    }
}