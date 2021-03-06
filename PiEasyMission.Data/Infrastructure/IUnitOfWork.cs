﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiEasyMission.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        IRepositoryBase<T> getRepository<T>() where T : class;
        void Commit();
        void Dispose();
    }
}
