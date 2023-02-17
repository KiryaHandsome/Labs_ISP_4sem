using Project.Entities;

namespace Project.Services
{
    public interface IDbService
    {
        IEnumerable<HotelRoom> GetAllRooms();
        IEnumerable<Service> GetServices(int id);
        void Init();
    }
}
