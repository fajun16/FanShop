namespace FanShop
{
    // Bestellposition ForeignKey Artikelnummer
    internal class Position
    {
        public int Id { get; set; }

        public int Artikelnummer { get; set; }

        public int Anzahl { get; set; }
    }
}
