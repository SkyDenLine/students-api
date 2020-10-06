using Microsoft.EntityFrameworkCore;
using Students.Domain.Interfaces;
using Students.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Infrastructure.Database
{
    public class Repository<TModel> : IRepository<TModel> where TModel : BaseEntity
    {
        private readonly StudentContext _context;
        public Repository(StudentContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(TModel model)
        {
            try
            {
                _context.Set<TModel>().Add(model);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return 1;
            }
            
        }

        public async Task<TModel> GetAsync(int id)
        {
            var model = await _context.Set<TModel>().FindAsync(id);
            return model;
        }

        

        public async Task<bool> RemoveAsync(int id)
        {
            var model = await _context.Set<TModel>().FindAsync(id);
            if (model != null)
            {
                _context.Set<TModel>().Remove(model);
                await _context.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<bool> UpdateAsync(TModel model)
        {          
            _context.Entry(model).State= EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;                        
        }

        public async Task<PageResponse<TModel>> GetPagedResult(int page, int pageSize)
        {
            var items = await _context.Set<TModel>().Skip((page * pageSize)-pageSize).Take(pageSize).ToListAsync();
            if(items!= null) 
            {
                

                int count = _context.Set<TModel>().Count();
                int pageCount = count % pageSize == 0 ? count / pageSize : (count / pageSize) + 1;

                return new PageResponse<TModel> { PagesCount = pageCount, PageData = items }; 
            }

            return new PageResponse<TModel>();
                
        }
    }
}
