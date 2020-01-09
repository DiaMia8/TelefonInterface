using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonInterface
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Telefon t1 = new Telefon("65465631");
            Telefon t2 = new Telefon("5463546");
            HivasNaplo h1 = new HivasNaplo();
            t1.FigyeloRegisztral(h1);
            t2.FigyeloRegisztral(h1);
            t1.EgyenlegFeltoltes(3);
            t2.EgyenlegFeltoltes(5);
            t1.HivasKezdemenyezes(t2);


            Console.ReadLine();
        }
    }
    public class Telefon
    {
        string telefonszam;
        int egyenleg = 0;
        IHivasFigyelo hivasfigyelo;

        public Telefon(string telefonszam)
        {
            this.telefonszam = telefonszam;
            
        }

        public void FigyeloRegisztral(IHivasFigyelo figyelo)
        {
            this.hivasfigyelo = figyelo;
        }

        public void HivasFogadas(Telefon forras)
        {
            hivasfigyelo?.BejovoHivasTortent(this, forras.telefonszam);
            //?. nem nullreference exeption hanem nem csinaál semmit -> if helyett
        }

        public void HivasKezdemenyezes(Telefon cel)
        {
            hivasfigyelo?.KimenoHivasTortent(this, cel.telefonszam);
            if (egyenleg > 0)
            {
                cel.HivasFogadas(this);
                egyenleg--;
            }
        } 

        public void EgyenlegFeltoltes(int osszeg)
        {
            egyenleg += osszeg;
        }

    }

    public class HivasNaplo : IHivasFigyelo
    {
        public void BejovoHivasTortent(Telefon kuldo, string forrasTelefonSzam)
        {
            Console.WriteLine($"Bejövő hívás adatai: küldő: {kuldo}, kezdeményező: {forrasTelefonSzam}");
        }

        public void KimenoHivasTortent(Telefon kuldo, string celTelefonSzam)
        {
            Console.WriteLine($"Kimenő hívás adatai: küldő:{kuldo}, fogadó:{celTelefonSzam}");
        }
    }

    public interface IHivasFigyelo
    {
        void BejovoHivasTortent(Telefon kuldo, string forrasTelefonSzam);
        void KimenoHivasTortent(Telefon kuldo, string celTelefonSzam);

    }
}
