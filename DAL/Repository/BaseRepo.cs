using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public interface IbaseRepo<T> where T : class
    {
        public T Getbyid(int id);
        //public T Getbyname(string name);
       public List<T> GetAll();

        public void ADD(T t);
       public void Delete(T entity);
       
        public void update(T entity);
    }
}
