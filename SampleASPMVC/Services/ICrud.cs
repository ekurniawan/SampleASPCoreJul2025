using System;

namespace SampleASPMVC.Services;

public interface ICrud<T>
{
    T Create(T item);
    T Read(int id);
    T Update(T item);
    void Delete(int id);
    IEnumerable<T> GetAll();
}
