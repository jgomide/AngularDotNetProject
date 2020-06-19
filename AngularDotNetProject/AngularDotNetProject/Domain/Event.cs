using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDotNetProject.API.Domain
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string Location { get; set; }
        public string EventDate { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Release { get; set; }
        public string ImagemUrl { get; set; }

        
    }
}
