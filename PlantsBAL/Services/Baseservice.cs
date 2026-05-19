using System;
using System.Collections.Generic;
using System.Text;

namespace PlantsBAL.Services
{
    public interface IBaseservice<T> where T : class
    {
		List<T> Getall();
		void ADD(T t);
		void Delete(T t);
		void Edit(T t);
        T Getbyid(int id);
		//T Getbyname(string name);
    }
}
