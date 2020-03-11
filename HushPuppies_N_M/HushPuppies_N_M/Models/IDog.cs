using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HushPuppies_N_M.Models
{
    interface IDog
    {
        void Open();

        void Close();

        bool Insert(User user);

        bool Delete(int id);

        void UpdateDogData(int id, User newUserData);

        List<Dog> GetAllDogs();

        Dog GetDog(int id);
    }
}