using System.Text.Json;

namespace FanShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bestellung = File.ReadAllText(@"D:\Test\bestellung.json");
            Bestellung test = JsonSerializer.Deserialize<Bestellung>(bestellung);

            AusgabeArtikel(@"D:\Test\alleArtikel.json");
            Console.WriteLine();
            test.AusgabeBestellung(@"D:\Test\alleArtikel.json");


            Console.ReadLine();
        }

        static void AusgabeArtikel(string pfad)
        {
            string fromJson = File.ReadAllText(pfad);
            List<Artikel> alleArtikel = JsonSerializer.Deserialize<List<Artikel>>(fromJson);

            Console.WriteLine("\n{0,-10} {1,-45} {2,4}", "Nr.", "Artikel", "Preis");
            Console.WriteLine(new string('-', 67));
            foreach (var item in alleArtikel)
            {
                Console.WriteLine("{0,-10} {1,-45} {2,4} Euro", item.Artikelnummer, item.Name, item.Preis);
            }
            Console.WriteLine(new string('-', 67));
        }
    }
}