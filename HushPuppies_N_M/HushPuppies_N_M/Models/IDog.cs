using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HushPuppies_N_M.Models.DB
{
    interface IDog
    {
        void Open();

        void Close();

        bool Insert(Dog dog);

        bool Delete(int id);

        bool UpdateDogData(int id,Dog newDogData);

        List<Dog> GetAllDogs();

        Dog GetDog(int id);
    }
}
