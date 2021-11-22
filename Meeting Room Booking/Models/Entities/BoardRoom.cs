using System;
using System.ComponentModel.DataAnnotations;

namespace Meeting_Room_Booking.Models.Entities
{
    public class BoardRoom
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string Location { get; set; }

        [MaxLength(32)]
        public string Name { get; set; }

        public DateTime OpenTime { get; set; }

        public DateTime CloseTime { get; set; }

        public bool IsInMaintanance { get; set; }

        [Range(0, int.MaxValue)]
        public int Capacity { get; set; }

        public BoardRoom(string location, string name, DateTime opentime, DateTime closetime, int capacity, bool isInMaintanance = false)
        {
            this.Id = Guid.NewGuid();
            this.Location = location;
            this.Name = name;
            this.OpenTime = opentime;
            this.CloseTime = closetime;
            this.IsInMaintanance = isInMaintanance;
            this.Capacity = capacity;
        }

        public BoardRoom()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
