using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Domain.DTO
{
    public class EventDetailDto
    {
        public string Name { get; set; }
        public int CreatedBy { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int EventCategoryId { get; set; }
        public DateTime EventDate { get; set; }

        public int Id { get; set; }
    }
}
