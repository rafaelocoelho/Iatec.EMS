using System.Text.Json.Serialization;

namespace Iatec.EMS.Services.DTOs
{
    public class EventParticipantDTO
    {
        public long Id { get; set; }
        [JsonIgnore]
        public long EventId { get; set; }
        [JsonIgnore]
        public long UserId { get; set; }

        public UserDTO User { get; set; }
        public EventDTO Event { get; set; }

        public EventParticipantDTO() { }

        public EventParticipantDTO(long id, long eventId, long userId)
        {
            Id = id;
            EventId = eventId;
            UserId = userId;
        }
    }
}
