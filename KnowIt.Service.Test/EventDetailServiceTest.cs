using KnowIt.Service.EventDetailServices;
using KnowIt.Service.Test.Fakes;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KnowIt.Service.Test
{ 
       public class EventDetailServiceTest : EventDetailFakes
    {
        private IEventDetailService _service;
        private Mock<IEventDetailService> _serviceMock;

        [Fact]
        public async Task Should_be_possible_to_create_new_barbecue()
        {
            _serviceMock = new Mock<IEventDetailService>();
            _serviceMock.Setup(m => m.PostAsync(eventDetailDto)).ReturnsAsync(eventDetailDto);
            _service = _serviceMock.Object;

            var result = await _service.PostAsync(eventDetailDto);

            Assert.NotNull(result);
            Assert.Equal(eventDetailDto.Description, result.Description);
            Assert.Equal(eventDetailDto.Title, result.Title);
        }
        
        [Fact]
        public async Task Should_be_return_list_of_eventDetail()
        {
            _serviceMock = new Mock<IEventDetailService>();
            _serviceMock.Setup(m => m.GetAllAsync()).ReturnsAsync(eventDetailDtos);
            _service = _serviceMock.Object;

            var eventDetailList = await _service.GetAllAsync();

            Assert.NotNull(eventDetailList);
            Assert.NotEmpty(eventDetailList);
        }

       
         
    }

}
