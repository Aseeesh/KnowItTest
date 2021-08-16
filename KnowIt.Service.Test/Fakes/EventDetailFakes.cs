using KnowIt.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Service.Test.Fakes
{
  public  class EventDetailFakes
    {
        public string Name { get; set; }
        public int CreatedBy { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int EventCategoryId { get; set; }
        public DateTime EventDate { get; set; }

        public int Id { get; set; }
        public List<EventDetailDto> eventDetailDtos { get; set; } = new List<EventDetailDto>();
        public EventDetailDto eventDetailDto { get; set; } = new EventDetailDto();
        public EventDetailFakes()
        {
            InitFakeDataObjects();
        }

        protected void InitFakeDataObjects()
        {
            Id = Faker.RandomNumber.Next(100);
            EventDate = Faker.Identification.DateOfBirth();
            Description = Faker.Lorem.Words(30).ToString();
            Title = Faker.Lorem.Words(50).ToString();
        }
        }
}
