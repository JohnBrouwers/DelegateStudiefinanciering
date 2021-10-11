using OverheidLibrary;
using StudentLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentConsole
{
    class Program
    {
        #region Studenten

        private static Student janJansen = new Student("Jan Jansen");
        private static Student lisaLisasen = new Student("Lisa Lisasen");
        private static Student teunTeunsen = new Student("Teun Teunsen");
        private static List<Student> studenten = new List<Student> { janJansen, lisaLisasen, teunTeunsen};

        #endregion

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            Studiefinanciering studiefinanciering = new Studiefinanciering(1000000);

            #region de uitgeschreven manier om te abonneren op een event
            //studiefinanciering.UitbetalingEvent += new OverheidLibrary.UitbetalingDelegate(JanJansensUitbetaling); 
            #endregion

            studiefinanciering.UitbetalingEvent += JanJansensUitbetalingOntvanger;
            studiefinanciering.UitbetalingEvent += LisaLisasensUitbetalingOntvanger;
            studiefinanciering.UitbetalingEvent += TeunTeunisensUitbetalingOntvanger;

            #region Opdracht
            // 1. Maak een nieuwe student aan en voeg deze toe aan de lijst van studenten
            // 2. Maak in de region 'Betalingen' een nieuwe 'UitbetalingOntvanger' methode aan waarin het ontvangen bedrag op de bankrekening van de nieuwe student gezet wordt
            // 3. Schrijf code binnen de regio 'Opdracht' en hack het 'Studiefinancierings-UitbetalingEvent' door jouw nieuwe student meer of zelfs het hele landelijke studiefinanciering budget te laten ontvangen!



            // 4. Je verdient een bonus wanneer je de code van opdracht 1-3 binnen de region 'Opdracht' schrijft



            #endregion

            studiefinanciering.VerrichtBetalingen();

            foreach (var student in studenten)
            {
                DisplaySaldoInfo(student);
            }

            Console.WriteLine("\nPress <ENTER> to exit..");
            Console.ReadLine();
        }

        private static void DisplaySaldoInfo(Student student) 
        {
            Console.WriteLine($"Student {student.Naam} heeft {student.Bankrekening.SaldoInfo}");        
        }

        #region Uitbetalingen
        private static void JanJansensUitbetalingOntvanger(decimal amount) 
        {
            janJansen.Bankrekening.Saldo += amount;
        }
        private static void LisaLisasensUitbetalingOntvanger(decimal amount) 
        {
            lisaLisasen.Bankrekening.Saldo += amount;
        }
        private static void TeunTeunisensUitbetalingOntvanger(decimal amount) 
        {
            teunTeunsen.Bankrekening.Saldo += amount;
        }

        #endregion

    }
}
