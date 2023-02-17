using SQLite;

namespace Project.Entities
{
    [Table("HotelRoom")]
    public class HotelRoom
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }    

        public HotelRoom() { }

        public HotelRoom(string name, int number)
        {
            Name = name;
            Number = number;
        }
    }
}
