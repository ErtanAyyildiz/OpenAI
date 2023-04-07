﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Entity.Repositories.IRepositories
{
    public interface IRepository<T> where T: class
    {
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);

        IEnumerable<T> GetList();
        List<T> GetListByFilter(Expression<Func<T, bool>> filter);
        T GetByID(int id);
    }
}
