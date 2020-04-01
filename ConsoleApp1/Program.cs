
/// Autor: Najlepszy Wyraz Twarzy

/// Nie wiem czy wymagane było umieszczenie przestrzeni nazw w innych plikach, więc wrzuciłem do jednego
/// (zasada że mają być odrębne przestrzenie nazw jednak została dalej zachowana).

using System;

// Dla klasy Osoba
using KartotekaSpace;

//using KartotekaSpace.MockUp;

using KartotekaSpace.Impl;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Kartoteka kartoteka = new Kartoteka();
            kartoteka.Dodaj(new Osoba("Dalinar", "Kholin"));
            Osoba adolin = new Osoba("Adolin", "Kholin");
            kartoteka.Dodaj(adolin);
            kartoteka.Dodaj(new Osoba("Shalan", "Davar"));
            kartoteka.Dodaj(new Osoba("Torol", "Sadeas"));
            Console.WriteLine("Kartoteka ma rozmiar " + kartoteka.Rozmiar);
            Console.WriteLine("Kartoteka " + (kartoteka.CzyZawiera(adolin) ? "zawiera " : "nie zawiera ") + adolin);
            kartoteka.Usun(new Osoba("Torol", "Sadeas"));
            Console.WriteLine("Kartoteka ma rozmiar " + kartoteka.Rozmiar);
            Console.WriteLine("Pierwsza osoba w kartotece to " + kartoteka[0]);
            Console.WriteLine("\n" + kartoteka);
        }
    }
}
