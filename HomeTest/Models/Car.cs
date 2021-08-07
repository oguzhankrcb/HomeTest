using HomeTest.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HomeTest.Models
{
    public class Headlight : IEntity, IHeadlight
    {
        public int Id { get; set; }

        public bool IsOn { get; set; }
    }

    public class Wheel : IEntity, IWheel
    {
        public int Id { get; set; }

        public string Brand { get; set; }
        public string Model { get; set; }
        public float Size { get; set; }
    }

    public class Car : Vehicle
    {
        [Required]
        //[JsonIgnore]
        public ICollection<Wheel> Wheels { get; set; }

        [Required]
        //[JsonIgnore]
        public ICollection<Headlight> Headlights { get; set; }
    }
}
