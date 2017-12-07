using System;
using System.Collections.Generic;
using System.Text;
using Applicanty.Data.UnitOfWork.Interface;
using Applicanty.Data.Repositories;

namespace Applicanty.Data.UnitOfWork.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private AtsDbContext _dbContext;

        public AtsDbContext DbContext => _dbContext;

        public UnitOfWork()
        {
                _dbContext = new AtsDbContext();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }

        public void Commit()=>
            _dbContext.SaveChanges();

    }
}
