using System;
using System.Text;

namespace KartotekaSpace
{
    class Osoba
    {
        string _imie_;
        public string imie { get { return _imie_; } }

        string _nazwisko_;
        public string nazwisko { get { return _nazwisko_; } }

        public Osoba(string imie, string nazwisko)
        {
            _imie_ = imie;
            _nazwisko_ = nazwisko;
        }

        public override string ToString()
        {
            return  imie + " " + nazwisko;
        }

        public static bool operator==(Osoba o1, Osoba o2)
        {
            return (o1.imie == o2.imie) && (o1.nazwisko == o2.nazwisko) ? true : false;
        }
        public static bool operator!=(Osoba o1, Osoba o2)
        {
            return (o1.imie == o2.imie) && (o1.nazwisko == o2.nazwisko) ? false : true;
        }
    }

    namespace MockUp
    {
        class Kartoteka
        {
            public void Dodaj(Osoba osoba) { }
            public void Usun(Osoba osoba) { }
            public int Rozmiar { get { return 1; } }
            public bool CzyZawiera(Osoba osoba) { return true; }
            public Osoba this[int index] { get { return new Osoba("Gall", "Anonim"); } }
        }
    }

    namespace Impl
    {
        class Kartoteka
        {
            const int resizeAmount = 8;

            Osoba[] osoby;
            int capacity;
            int amount = 0;

            public Kartoteka(int size)
            {
                if (size < 0)
                {
                    Console.WriteLine("Nie prawidłowy rozmiar kartoteki");
                    osoby = new Osoba[resizeAmount];
                    capacity = resizeAmount;
                    return;
                }
                osoby = new Osoba[size];
                capacity = size;
            }
            public Kartoteka()
            {
                osoby = new Osoba[resizeAmount];
                capacity = resizeAmount;
            }


            public void Dodaj(Osoba osoba)
            {
                if (amount == capacity)
                    ExpandSize();
                osoby[amount++] = osoba;
            }
            public void Usun(Osoba osoba)
            {
                if(amount == 0)
                {
                    Console.WriteLine("Usunięcie osoby z kartoteki nie powiodło się bo nie zawiera ona żadnych osób!");
                    return;
                }
                for(int i = 0; i < amount; i++)
                {
                    if(osoby[i] == osoba)
                    {
                        while (i < amount)
                            osoby[i] = osoby[++i];
                        amount--;
                        return;
                    }
                }
                Console.WriteLine("Usunięcie osoby z kartoteki nie powiodło się bo nie zawiera ona tej osoby " + osoba.ToString());
            }
            public int Rozmiar { get { return amount; } }
            public bool CzyZawiera(Osoba osoba)
            {
                for(int i = 0; i < amount; i++)
                {
                    if (osoby[i] == osoba)
                        return true;
                }
                return false;
            }
            public Osoba this[int index] { get { return osoby[index]; } }

            public override string ToString()
            {
                // A bit of polish... nearly front-end level (nearly)
                StringBuilder builder = new StringBuilder("W kartotece " + (1<amount&&amount<5?"są ":"jest ") + amount + (amount == 1?" osoba:":(1<amount&&amount<5?" osoby:":" osób:") + "\n"));
                for(int i = 0; i < amount; i++)
                    builder.AppendLine(osoby[i].ToString());
                return builder.ToString();
            }
            
            void ExpandSize()
            {
                Osoba[] _osoby = new Osoba[osoby.Length + resizeAmount];
                for(int i = 0; i < osoby.Length; i++)
                {
                    _osoby[i] = osoby[i];
                }
            }
        }
    }
}
