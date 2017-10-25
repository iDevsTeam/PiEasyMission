using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiEasyMission.Data.Infrastructure
{
    public class DataBaseFactory : IDataBaseFactory
    {
        private PiEasyMissionContext dataContext;

        public PiEasyMissionContext DataContext
        {
            get { return dataContext; }
            
        }
        public DataBaseFactory()
        {
            dataContext = new PiEasyMissionContext();
        }
    }
}
