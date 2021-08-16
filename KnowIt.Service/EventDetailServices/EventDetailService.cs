using AutoMapper;
using KnowIt.Domain.DTO;
using KnowIt.Domain.Entities;
using KnowIt.Infrastructure.Repositories.EventDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Service.EventDetailServices
{ 
     public class EventDetailService : IEventDetailService
    {
        private readonly IEventDetailRepository _repository;
        private readonly IMapper _mapper;

        public EventDetailService(IEventDetailRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

       

        public async Task<IEnumerable<EventDetailDto>> GetAllAsync()
        {
            var eventDetails = await _repository.GetAsync();
            return _mapper.Map<IEnumerable<EventDetailDto>>(eventDetails);
        }

        public async Task<EventDetailDto> GetAsync(int id)
        {
            var eventDetail = await _repository.GetByIdAsync(id);


            return _mapper.Map<EventDetailDto>(eventDetail);
        }

        public async Task<EventDetailDto> PostAsync(EventDetailDto eventDetail)
        {
            var entity = _mapper.Map<EventDetail>(eventDetail);
            entity.EventDate = DateTime.Now;
            var result = await _repository.AddAsync(entity);

            return _mapper.Map<EventDetailDto>(result);
        }

        public async Task<EventDetailDto> PutAsync(EventDetailDto eventDetail)
        {
            var entity = _mapper.Map<EventDetail>(eventDetail);
            entity.EventDate = DateTime.Now;
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<EventDetailDto>(result);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        
    }
}
