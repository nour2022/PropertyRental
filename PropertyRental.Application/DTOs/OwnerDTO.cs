using PropertyRental.Domain.Entities.Property;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRental.Application.DTOs
{
    public class OwnerDTO:UserDTO
    {
        
        public List<PropertyDTO> OwnedProperies { get; set; }
    }
}
