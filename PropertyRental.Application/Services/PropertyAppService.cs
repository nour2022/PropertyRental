using AutoMapper;
using PropertyRental.Application.DTOs;
using PropertyRental.Domain.Entities.Property;
using PropertyRental.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRental.Application.Services
{
    public class PropertyAppService : IAppService<PropertyDTO>
    {
       private AppDbContext _context;
        
        private readonly IMapper _mapper;
        public PropertyAppService(AppDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
        public bool Commit()
        {
           if( _context.SaveChanges() > 0 )
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
            _context.Remove( id );
           return Commit();
        }

        public List<PropertyDTO> GetAll()
        {
           List<PropertyDTO> propertiesDTO = new List<PropertyDTO>();
            var properties= _context.Properties.ToList();
            foreach(var property in properties ) { 
                propertiesDTO.Add(_mapper.Map<PropertyDTO>(property));
            }
            return propertiesDTO;
        }

        public PropertyDTO GetById(int id)
        {
           var property = _context.Properties.FirstOrDefault(p => p.Id == id);
            return _mapper.Map<PropertyDTO>(property);
        }

        public void Insert(PropertyDTO entity)
        {
           Property property = _mapper.Map<Property>(entity);
            _context.Properties.Add(property);
            Commit();
        }

        public void Update(PropertyDTO entity,int id)
        {
            var property = _mapper.Map<Property>(entity);
            _context.Properties.Update(property);
            Commit();
        }
        public List<PropertyDTO> GetAvailable()
        {
            var properties = GetAll();
            List<PropertyDTO> AvailableProperties = new List<PropertyDTO>();
            foreach (var property in properties)
            {
                if(property.Status == PropertyStatus.Available)
                {
                    AvailableProperties.Add(property);
                }

            }
            return AvailableProperties;
        }
    }
}
