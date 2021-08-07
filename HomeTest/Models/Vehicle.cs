using HomeTest.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HomeTest.Models
{
    public abstract class Vehicle : IEntity, VEntity
    {
        public int Id { get; set; }

        [JsonIgnore]
        [StringLength(20, MinimumLength = 3)]
        public string Type { get; set; }

        [Required]
        [StringLength(20)]
        public string Color { get; set; }
    }
}
