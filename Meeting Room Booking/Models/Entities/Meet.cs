using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Meeting_Room_Booking.Models.Entities
{
    public class Meet
    {
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public virtual BoardRoom BoardRoom { get; set; }

        public virtual List<Employee> Participants { get; set; }

        public virtual Employee Reserver { get; set; }

        public bool IsMandatory { get; set; }

        public Meet(DateTime startTime, DateTime endTime, bool isMandatory = true)
        {
            this.Id = Guid.NewGuid();
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.BoardRoom = new();
            this.Participants = new();
            this.Reserver = new();
            this.IsMandatory = isMandatory;
        }

        public Meet()
        {

            this.Id = Guid.NewGuid();
            this.BoardRoom = new();
            this.Participants = new();
            this.Reserver = new();
        }

    }
}
