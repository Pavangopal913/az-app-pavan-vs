using Mvc.StorageAccount.Demo.Data;

namespace Mvc.StorageAccount.Demo.Services
{
    public interface ITableStorageService
    {
        Task<AttendeeEntity> GetAttendee(string industry, string id);
        Task<List<AttendeeEntity>> GetAttendees();
        Task UpsertAttendee(AttendeeEntity attendeeEntity);
        Task DeleteAttendee(string industry, string id);
    }
}
