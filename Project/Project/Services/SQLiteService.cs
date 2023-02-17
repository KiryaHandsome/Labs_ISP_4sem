using Project.Entities;
using SQLite;

namespace Project.Services
{
    class SQLiteService : IDbService
    {
        private SQLiteConnection _connection = new SQLiteConnection(Constants.DatabaseFilePath, Constants.Flags);

        public IEnumerable<HotelRoom> GetAllRooms()
        {
            return _connection.Table<HotelRoom>();
        }

        public IEnumerable<Service> GetServices(int id)
        {
            return _connection.Table<Service>()
                .Where(s => s.RoomId == id);
        }

        public void Init()
        {
            _connection.Execute(Constants.DropTableIfExistsQuery + " HotelRoom");
            _connection.Execute(Constants.DropTableIfExistsQuery + "Service");

            _connection.CreateTable<HotelRoom>();
            _connection.CreateTable<Service>();

            _connection.Insert(new HotelRoom("Hot room", 132));
            _connection.Insert(new HotelRoom("Sweet room", 12));
            _connection.Insert(new HotelRoom("Hard-rock room", 77));

            _connection.Insert(new Service(1, "Some service", "bla-bla-bla"));
            _connection.Insert(new Service(1, "Water", "We give you a lot of water"));
            _connection.Insert(new Service(1, "Alcohol", "Unlimited beverages"));
            _connection.Insert(new Service(2, "Massage", "Free massage all time"));
            _connection.Insert(new Service(2, "Swimming pool", "pool"));
            _connection.Insert(new Service(3, "Music", "hard rock"));
            _connection.Insert(new Service(3, "service 3", "description"));
            _connection.Insert(new Service(3, "Some service", "descrition2"));
        }
    }
}
