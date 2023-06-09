using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOperation
{
    public interface IOperation<T>
    {
        public void AddObj(T obj);
        public void RemoveObj(T obj);
        public T GetObj(int id);
        public void EditObj(T oldObj ,T newObj);
    }
}
