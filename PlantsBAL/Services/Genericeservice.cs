using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repository;

namespace PlantsBAL.Services
{
    public  class Genericeservice<T>:IBaseservice<T> where T : class

    {
        private readonly IbaseRepo<T> repo;

        public Genericeservice(IbaseRepo<T> _repo)
        {
            repo = _repo;
            
        }

        //public T Getbyname(string name)
        //{
        //    return repo.Getbyname(name);
        //}

        void IBaseservice<T>.ADD(T t)
        {
            repo.ADD(t);
        }

        void IBaseservice<T>.Delete(T t)
        {
            repo.Delete(t);
        }

        void IBaseservice<T>.Edit(T t)
        {
            repo.update(t);
            
        }

        List<T> IBaseservice<T>.Getall()
        {
            return repo.GetAll();
        }

        T IBaseservice<T>.Getbyid(int id)
        {
			var t = repo.Getbyid(id);
			if (t != null)
				return t;
			else
				return null;
		}
    }
}
