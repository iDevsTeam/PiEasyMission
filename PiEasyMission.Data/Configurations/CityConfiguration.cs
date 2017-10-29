using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using PiEasyMission.Domain.Entities;
using System.Threading.Tasks;

namespace PiEasyMission.Data.Configurations
{
    public class CityConfiguration : ComplexTypeConfiguration<City>
    {
        public CityConfiguration()
        {
            Property(a => a.Latitude).IsRequired();
            Property(a => a.Longitude).IsRequired();
            Property(a => a.Ville).IsRequired();

        }
    }
}
