using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Models;

namespace SalesWebMVC.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebMVCContext _context;

        public SalesRecordService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public List<SalesRecord> FindByDate(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(sale => sale.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(sale => sale.Date <= maxDate.Value);
            }

            return result
                .Include(sale => sale.Seller)
                .Include(sale => sale.Seller.Department)
                .OrderByDescending(sale => sale.Date)
                .ToList();
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            //return await _context.SalesRecord.Where(sale => sale.Date >= minDate && sale.Date <= maxDate).ToListAsync();
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(sale => sale.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(sale => sale.Date <= maxDate.Value);
            }

            return await result
                .Include(sale => sale.Seller)
                .Include(sale => sale.Seller.Department)
                .OrderByDescending(sale => sale.Date)
                .ToListAsync();
        }
    }
}
