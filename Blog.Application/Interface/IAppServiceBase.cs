using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Interface
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        TEntity GetById(string id);

        IEnumerable<TEntity> GetAll();

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();
    }
}
