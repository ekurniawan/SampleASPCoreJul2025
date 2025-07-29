using System;

namespace SampleAspMvcEF.DAL;

public interface ICrud<T>
{
    T Create(T item);
    T GetById(int id);
    T Update(T item);
    void Delete(int id);
    IEnumerable<T> GetAll();
}
