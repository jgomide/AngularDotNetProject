using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AngularDotNetProject.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace AngularDotNetProject.Repository.Repository
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        //GENERIC
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
        //EVENT
        public async Task<Event[]> GetAllEventAsync(bool includeHeadline = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Releases)
                .Include(e => e.SocialNetworks);

            if (includeHeadline)
            {
                query = query
                    .Include(he => he.HeadlineEvents)
                    .ThenInclude(h => h.Headline);
            }

            query = query.OrderByDescending(e => e.EventDate);

            return await query.ToArrayAsync();

        }
        public async Task<Event> GetEventAsyncById(int eventId, bool includeHeadline = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Releases)
                .Include(e => e.SocialNetworks);

            if (includeHeadline)
            {
                query = query
                    .Include(he => he.HeadlineEvents)
                    .ThenInclude(h => h.Headline);
            }

            query = query.OrderByDescending(e => e.EventDate)
                .Where(e => e.EventId == eventId);
                  

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Event[]> GetAllEventAsyncByName(string name, bool includeHeadline = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Releases)
                .Include(e => e.SocialNetworks);

            if (includeHeadline)
            {
                query = query
                    .Include(he => he.HeadlineEvents)
                    .ThenInclude(h => h.Headline);
            }

            query = query.OrderByDescending(e => e.EventDate)
                .Where(e => e.Name.ToLower().Contains(name.ToLower()));
                  

            return await query.ToArrayAsync();
        }
        //HEADLINE
        public async Task<Headline> GetHeadlineAsync(int headlineId, bool includeEvent = false)
        {
            IQueryable<Headline> query = _context.Headlines
                .Include(h => h.SocialNetworks);

            if (includeEvent)
            {
                query = query
                    .Include(he => he.HeadlineEvents)
                    .ThenInclude(e => e.Event);
            }

            query = query.OrderBy(h => h.Name)
                .Where(h => h.HeadlineId == headlineId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Headline[]> GetAllHeadlineAsyncByName(string name, bool includeEvent = false)
        {
            IQueryable<Headline> query = _context.Headlines
                .Include(h => h.SocialNetworks);

            if (includeEvent)
            {
                query = query
                    .Include(he => he.HeadlineEvents)
                    .ThenInclude(e => e.Event);
            }

            query = query.Where(h => h.Name.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }
    }
}
