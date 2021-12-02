using System;
using System.ComponentModel.DataAnnotations;

namespace Meeting_Room_Booking.Models.Entities
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(16)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(16)]
        public string LastName { get; set; }

        [MaxLength(16)]
        public string Position { get; set; }

        [Range(16, int.MaxValue)]
        public int Age { get; set; }

        [Range(0.0,double.MaxValue)]
        public double Experience { get; set; }

        [Required]
        public DateTime WorkingSince { get; set; }

        public bool IsOnVacation { get; set; }

        public Employee(string firstName, string lastName, string position, int age, double experience, DateTime workingSince, bool isOnVacation = false)
        {
            this.Id = Guid.NewGuid();
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Position = position;
            this.Age = age;
            this.Experience = experience;
            this.WorkingSince = workingSince;
            this.IsOnVacation = isOnVacation;
        }

        public Employee()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
