using AutoMapper;
using PropertyRental.Application.DTOs;
using PropertyRental.Domain.Entities;
using PropertyRental.Domain.Entities.User;
using PropertyRental.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRental.Application.Services
{
    internal class TenantAppService
    {
        private AppDbContext _context;

        private readonly IMapper _mapper;
        public TenantAppService(AppDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
        public bool Commit()
        {
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        

       
    }
}
