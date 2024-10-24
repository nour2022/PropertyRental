using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyRental.Application.DTOs;

namespace PropertyRental.Application.Mapping
{
    using AutoMapper;
    using PropertyRental.Domain.Entities;
    using PropertyRental.Domain.Entities.Property;
    using PropertyRental.Domain.Entities.User;

    public class MappingProfile : Profile
    {
       
        public MappingProfile()
        {
            
            // Property -> PropertyDTO mapping
            CreateMap<Property, PropertyDTO>();
            CreateMap<PropertyDTO, Property>();

            // CreatePropertyDTO -> Property mapping (for creation)
            // CreateMap<CreatePropertyDTO, Property>();

            // UpdatePropertyDTO -> Property mapping (for update)
            // CreateMap<UpdatePropertyDTO, Property>();

            // Owner -> OwnerDTO mapping
            CreateMap<Owner, OwnerDTO>();
            CreateMap<OwnerDTO, Owner>();

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
               

            CreateMap<Role, RoleDTO>();
            CreateMap<RoleDTO, Role>();
            // Tenant -> TenantDTO mapping
            CreateMap<Tenant, TenantDTO>();
            CreateMap<TenantDTO, Tenant>();

            // RentalAgreement -> RentalAgreementDTO mapping
            CreateMap<LeaseAgreement, LeaseAgreementDTO>();
            CreateMap<LeaseAgreementDTO, LeaseAgreement>();



        }
    }

}
