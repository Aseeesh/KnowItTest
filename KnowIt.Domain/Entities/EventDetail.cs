using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Domain.Entities
{
    public class EventDetail : BaseEntity
    { 
        public string? Name { get; set; }
        public int? CreatedBy { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? EventCategoryId { get; set; } 
        public DateTime? EventDate { get; set; }
        private EventDetail()
        {
        }


        public EventDetail(DateTime? date, string? description, string title)
        {
            Validations(date, description);

            EventDate = date;
            Description = description;
            Title = title;
        }

        private void Validations(DateTime? date, string? description)
        {
            //if (date < DateTime.Now)
            //    throw new ArgumentException("Date not valid!");

            if (string.IsNullOrEmpty(description))
                throw new ArgumentException("Description is required!");

            if (description.Length <= 2)
                throw new ArgumentException("The description length must contain more than two characters!");
        }
    }
    }
