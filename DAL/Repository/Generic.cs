using System;
using System.Collections.Generic;
using System.Text;
using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class Generic<T>:IbaseRepo<T> where T : class
    {
        private readonly Plantscontext plantscontext;
        private readonly DbSet<T>dbset;

        public Generic(Plantscontext _plantscontext)
        {
            plantscontext = _plantscontext;
            dbset=plantscontext.Set<T>();
        }


        public  List<T> GetAll()
        {
            return dbset.ToList();
        }
        public T? Getbyid(int id)
        {
            return dbset.Find(id);
        }

        public void ADD(T t)
        {
            dbset.Add(t);
            plantscontext.SaveChanges();
        }

        public void Delete(T t)
        {
            dbset.Remove(t);
            plantscontext.SaveChanges();

        }
        public void update(T t)
        {
            dbset.Update(t);
            plantscontext.SaveChanges();
        }

        
    }
}
