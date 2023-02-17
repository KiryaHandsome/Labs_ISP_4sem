using SQLite;

namespace Project.Entities
{
    [Table("Service")]
    public class Service
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int Id { get; set; }
        [Indexed]
        public int RoomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Service() { }

        public Service(int roomId, string name, string description)
        {
            RoomId = roomId;
            Name = name;
            Description = description;
        }

        public override string ToString()
        {
            return $"Room id: {Id}; Name of service: {Name}; Description: {Description}";
        }
    }
}
