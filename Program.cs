using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<string> dane = new List<string>
        {
            "PawełZwada",
            "AnnaNowak",
            "PiotrKowalski",
            "BeataKowalska",
            "ZbigniewBrzezinski",
            "TomaszAdamek",
            "JerzyGrotowski",
            "AndrzejWajda",
            "LechWalesa",
            "WladyslawGomulka",
            "Zygmunt2Wazon",
            "Zygmunt3Waza",
            "Mieszko1"
        };

        Console.WriteLine("Przed sortowaniem:");
        foreach (var element in dane)
        {
            Console.WriteLine(element);
        }

        dane = QuickSort(dane, 0, dane.Count - 1);

        Console.WriteLine("\nPo sortowaniu:");
        foreach (var element in dane)
        {
            Console.WriteLine(element);
        }
    }

    public static List<string> QuickSort(List<string> dane, int lewa, int prawa)
    {
        if (prawa - lewa < 10)
        {
            InsertionSort(dane, lewa, prawa);
        }
        else
        {
            int i = lewa, j = prawa;
            var pivot = dane[(lewa + prawa) / 2];

            while (i <= j)
            {
                while (string.Compare(dane[i], pivot) < 0)
                {
                    i++;
                }

                while (string.Compare(dane[j], pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Zamiana miejscami
                    var tmp = dane[i];
                    dane[i] = dane[j];
                    dane[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Wywołania rekurencyjne
            if (lewa < j)
            {
                QuickSort(dane, lewa, j);
            }

            if (i < prawa)
            {
                QuickSort(dane, i, prawa);
            }
        }

        return dane;
    }

    public static void InsertionSort(List<string> dane, int lewa, int prawa)
    {
        for (int i = lewa + 1; i <= prawa; i++)
        {
            var klucz = dane[i];
            int j = i - 1;

            while ((j >= lewa) && (string.Compare(dane[j], klucz) > 0))
            {
                dane[j + 1] = dane[j];
                j--;
            }

            dane[j + 1] = klucz;
        }
    }
}
