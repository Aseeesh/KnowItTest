using KnowIt.Domain.Entities;
using KnowIt.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Infrastructure.Repositories.EventDetails
{
    public class EventDetailRepository : BaseRepository<EventDetail>, IEventDetailRepository, IRepository<EventDetail>
    {
        private readonly DbSet<EventDetail> _dataset;

        public EventDetailRepository(ApplicationDbContext context) : base(context)
        {
            this._dataset = context.Set<EventDetail>();
        }
    }
}
