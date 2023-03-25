using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public interface IABMLogic<T,ID>
    {
        List<T> GetAll();

        T GetById(int id);

        int GetLastId();

        void Add(T item);

        void Delete(ID id);

        void Update(T item);
    }
}
