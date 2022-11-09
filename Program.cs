using System.Text.Json;

namespace FanShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Bestellung anlegen
            string bestellung = File.ReadAllText(@"D:\Projekte\FanShop\bestellung.json");
            Bestellung test = JsonSerializer.Deserialize<Bestellung>(bestellung);

            // Pfad zur Artikelliste weitergeben
            AusgabeArtikel(@"D:\Projekte\FanShop\alleArtikel.json");
            Console.WriteLine();
            test.AusgabeBestellung(@"D:\Projekte\FanShop\alleArtikel.json");


            Console.ReadLine();
        }

        static void AusgabeArtikel(string pfad)
        {
            // Artikelliste einlesen
            string fromJson = File.ReadAllText(pfad);
            List<Artikel> alleArtikel = JsonSerializer.Deserialize<List<Artikel>>(fromJson);

            // Spaltennamen
            Console.WriteLine("\n{0,-10} {1,-45} {2,4}", "Nr.", "Artikel", "Preis");
            Console.WriteLine(new string('-', 67));

            // Artikel eingeben
            foreach (var item in alleArtikel)
            {
                Console.WriteLine("{0,-10} {1,-45} {2,4} Euro", item.Artikelnummer, item.Name, item.Preis);
            }
            Console.WriteLine(new string('-', 67));
        }
    }
}