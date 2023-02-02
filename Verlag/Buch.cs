using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verlag
{
    public class Buch
    {

        string autor;
        string titel;
        int auflage;

        ISBN isbn = new ISBN("978-000000000");

        public string ISBN10
        {
            get { return isbn.ISBN10; }
            set { isbn.ISBN10 = value; }
        }
        public string ISBN13
        {
            get { return isbn.ISBN13; }
            set { isbn.ISBN13 = value; }
        }


        public string Autor
        {
            get { return autor; }
            set {

                if (value.Contains('#') || value.Contains(';') || value.Contains('§') || value.Contains('%') || value == null || value == "")
                {
                    throw new ArgumentException("Unerlaubter Character im Autornamen");
                }
                else
                {
                    autor = value;
                }
            }
        }

        public string Titel
        { 
            get { return titel; }
        }

        public int Auflage
        { 
            get { return auflage; }
            set {

                if (value > 0)
                {
                    auflage = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Auflage darf nicht niedriger als 0 sein");
                }
            }
        }


        public Buch(string autor, string titel, int auflage) 
        {
            this.Autor = autor;
            this.titel = titel;
            this.Auflage = auflage;
        }


        public Buch(string autor, string titel)
        {

            this.Autor = autor;
            this.titel = titel;
            this.auflage = 1;


        }



    }
}
