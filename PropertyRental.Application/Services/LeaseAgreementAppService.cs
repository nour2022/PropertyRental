using AutoMapper;
using PropertyRental.Application.DTOs;
using PropertyRental.Domain.Entities;
using PropertyRental.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRental.Application.Services
{
    public class LeaseAgreementAppService : IAppService<LeaseAgreementDTO>
    {
        private AppDbContext _context;

        private readonly IMapper _mapper;
        public LeaseAgreementAppService(AppDbContext dbContext, IMapper mapper)
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

        public bool Delete(int id)
        {
            _context.Remove(id);
            return Commit();
            
    }

        public List<LeaseAgreementDTO> GetAll()
        {
          List<LeaseAgreementDTO> result = new List<LeaseAgreementDTO>();
            var leaseAgreements = _context.LeaseAgreements.ToList();
            foreach(var leaseAgreement in leaseAgreements)
            {
                result.Add(_mapper.Map<LeaseAgreementDTO>(leaseAgreement));
            }
            return result;
        }

        public LeaseAgreementDTO GetById(int id)
        {
           var leaseAgreement = _context.LeaseAgreements.FirstOrDefault(a => a.Id == id);
            return _mapper.Map<LeaseAgreementDTO>(leaseAgreement);
        }

        public void Insert(LeaseAgreementDTO entity)
        {
           var leaseAgreement = _mapper.Map<LeaseAgreement> (entity);
            leaseAgreement.IsActive = true;
            _context.LeaseAgreements.Add(leaseAgreement);
            Commit();

        }

        public void Update(LeaseAgreementDTO entity, int id)
        {
            var property = _mapper.Map<LeaseAgreement>(entity);
            _context.LeaseAgreements.Update(property);
            Commit();
        }
    }
}
