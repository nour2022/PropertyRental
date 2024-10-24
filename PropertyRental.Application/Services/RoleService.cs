using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PropertyRental.Application.DTOs;
using PropertyRental.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRental.Application.Services
{
    public class RoleService
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;
        public RoleService(AppDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;   
        }
        public RoleDTO GetById(int id)
        {
           var role= _context.Roles.FirstOrDefault(r=>r.Id == id);

            return _mapper.Map<RoleDTO>( role);
        }
        public  int  GetByName(string name)
        {
            var role=  _context.Roles.FirstOrDefault(r=>r.NormalizedName == name.ToUpper());
            return role.Id;
        }
    }
}
