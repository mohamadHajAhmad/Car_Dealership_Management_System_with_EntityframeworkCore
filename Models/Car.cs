
namespace Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public DateTime Year { get; set; }
        public string Gear { get; set; }
        public int Km { get; set; }

        public List<Part> Parts { get; set; }

    }
}