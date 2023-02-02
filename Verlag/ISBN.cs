using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verlag
{
    internal class ISBN
    {

        private int grundwert;
        private int fuehrungsnummer = 978;
        private int pruefziffer13 = -1;
        private int pruefziffer10 = -1;


        public ISBN(string wert)
        {

            isbnDatenAufteilen(wert);
            
        }

        public void isbnDatenAufteilen(string wert)
        {
            wert = wert.Replace("-", "");

            string ziffern = wert;

            if (ziffern.Length > 10 & ziffern.Length < 13)
            {
                fuehrungsnummer = Convert.ToInt32(ziffern.Substring(0, 3));
                grundwert = Convert.ToInt32(ziffern.Substring(2, ziffern.Length - 3));
            }
            else if (ziffern.Length == 13)
            {
                fuehrungsnummer = Convert.ToInt32(ziffern.Substring(0, 3));
                grundwert = Convert.ToInt32(ziffern.Substring(2, ziffern.Length - 4));
                pruefziffer13 = Convert.ToInt32(ziffern.Substring(ziffern.Length - 1, 1));
            }
            else if (ziffern.Length == 10)
            {
                fuehrungsnummer = -1;
                grundwert = Convert.ToInt32(ziffern.Substring(0, ziffern.Length - 1));
                pruefziffer10 = Convert.ToInt32(ziffern.Substring(ziffern.Length - 1, 1));
            }
        }


        public string ISBN13
        {
            get { return ISBN13Berechnen(); }
            set { isbnDatenAufteilen(value); }
        }
        public string ISBN10
        {
            get { return ISBN10Berechnen(); }
            set { isbnDatenAufteilen(value); }

        }



        public string ISBN13Berechnen()
        {
            int pruefziffer = -1;
            char[] ziffern = $"{fuehrungsnummer}{grundwert}".ToCharArray();
            int ungeradeZahlenSumme = 0;
            int geradeZahlenSumme = 0;

            List<int> ungeradeZahlen = new List<int>();
            List<int> geradeZahlen = new List<int>();

            bool zuordnungSwitch = false;

            for (int i = 0; i < ziffern.Length; i++)
            {
                int zahl = Convert.ToInt32(ziffern[i]);
                if(!zuordnungSwitch)
                {
                    ungeradeZahlen.Add(Convert.ToInt32(ziffern[i]));
                    zuordnungSwitch=true;
                }
                else
                {
                    geradeZahlen.Add(Convert.ToInt32(ziffern[i]));
                    zuordnungSwitch=false;
                }
            }

            foreach(int i in ungeradeZahlen)
            {
                ungeradeZahlenSumme += i;
            }

            foreach(int i in geradeZahlen)
            {
                geradeZahlenSumme += i * 3;
            }

            pruefziffer = 10 - ((geradeZahlenSumme + ungeradeZahlenSumme) % 10);


            string isbn13 = $"{fuehrungsnummer}-{grundwert}{pruefziffer}";


            return isbn13;
        }

        public string ISBN10Berechnen()
        {
            int pruefziffer = -1;
            char[] ziffern = grundwert.ToString().ToCharArray();
            int summe = 0;

            for(int i = 0; i < ziffern.Length; i++)
            {
                summe = ziffern[i] * i;
            }

            pruefziffer = summe % 11;

            string isbn10 = $"{grundwert}{pruefziffer}";

            return isbn10;
        }

    }
}
