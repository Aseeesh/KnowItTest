using KnowIt.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Service.EventDetailServices
{
    public interface IEventDetailService
    {
        Task<IEnumerable<EventDetailDto>> GetAllAsync();
        Task<EventDetailDto> GetAsync(int id);
        Task<EventDetailDto> PostAsync(EventDetailDto eventDetail);
        Task<EventDetailDto> PutAsync(EventDetailDto eventDetail);
        Task<bool> DeleteAsync(int id);
    }
}
