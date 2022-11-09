using System.Text.Json;

namespace FanShop
{
    internal class Bestellung
    {
        public List<Position> AllePositionen { get; set; }

        public Bestellung() { }

        public void AusgabeBestellung(string pfad)
        {
            // Artikel-Liste aus JSON-Datei einlesen
            string fromJson = File.ReadAllText(pfad);
            List<Artikel> alleArtikel = JsonSerializer.Deserialize<List<Artikel>>(fromJson);

            // Inner Join zwischen Artikeln und Bestellpositionen und Gesamtpreis errechnen
            var join = from artikel in alleArtikel
                       join position in AllePositionen
                       on artikel.Artikelnummer equals position.Artikelnummer
                       select new
                       {
                           artikel.Artikelnummer,
                           artikel.Name,
                           position.Anzahl,
                           Summe = position.Anzahl * artikel.Preis
                       };


            // Spaltennamen
            Console.WriteLine("\n{0,-10} {1,-45} {2,-15} {3,4}", "Nr.", "Artikel", "Anzahl", "Preis");
            Console.WriteLine(new string('-', 83));

            // Bestellpositionen
            foreach (var item in join)
            {
                Console.WriteLine("{0,-10} {1,-45} {2,-15} {3,4} Euro", item.Artikelnummer, item.Name, item.Anzahl, item.Summe);
            }

            // Gesamtpreis
            Console.WriteLine(new string('-', 83));
            Console.WriteLine("Gestamtpreis: {0} Euro\n", join.Sum(x => x.Summe));
        }
    }
}
