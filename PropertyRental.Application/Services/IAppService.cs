using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRental.Application.Services
{
    internal interface IAppService<TEntity> where TEntity : class
    {
        bool Commit();
        bool Delete(int id);
        List<TEntity> GetAll();
        TEntity GetById(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity,int id);
    }
}
