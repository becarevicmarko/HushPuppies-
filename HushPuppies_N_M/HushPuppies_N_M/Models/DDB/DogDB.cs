using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;

using MySql.Data.MySqlClient;

namespace HushPuppies_N_M.Models.DDB
{
    public class DogDB
    {
        private string _connectionString = "Server=localhost;Database=db_einfuehrung; Uid=root;Pwd=root;";
        private MySqlConnection _Connection;
        
        public void Open()
        {
            if (this._Connection == null)
            {
                this._Connection = new MySqlConnection(this._connectionString);
            }
            if (this._Connection.State != ConnectionState.Open)
            {
                this._Connection.Open();
            }
        }

        public void Close()
        {
            if ((this._Connection !=  null) && (this._Connection.State != ConnectionState.Closed))
            {
                this._Connection.Close();
            }
        }

        public bool Delete(int id)
        {
            // Command erzeugen mit Parameter (SQL-Injections verhindern)
            DbCommand cmdDel =
                this._Connection.CreateCommand();
            cmdDel.CommandText = "DELETE FROM users WHERE id=@userId";

            // Parameter belegen
            DbParameter paramId = cmdDel.CreateParameter();
            paramId.ParameterName = "userId";
            paramId.Value = id;
            paramId.DbType = DbType.Int32;

            // Parameter hinzufügen
            cmdDel.Parameters.Add(paramId);

            // Commands ausführen
            return cmdDel.ExecuteNonQuery() == 1;
            // gibt true zurück falls genau 1 user gelöscht wurde ansonsten false
        }

        public bool Insert(Dog dog)
        {
            if (dog == null)
            {
                return false;
            }

            DbCommand cmdInsert = this._Connection.CreateCommand();
            cmdInsert.CommandText = "INSERT into dog value (@image, null, @name, @expirience, @birthdate, @informations, @descriptions)";

            DbParameter paramimage = cmdInsert.CreateParameter();
            paramimage.ParameterName = "Image";
            paramimage.Value = dog.Image;
            paramimage.DbType = DbType.String;

            DbParameter paramid = cmdInsert.CreateParameter();
            paramid.ParameterName = "ID";
            paramid.Value = dog.ID;
            paramid.DbType = DbType.Int32;

            DbParameter paramname = cmdInsert.CreateParameter();
            paramname.ParameterName = "Name";
            paramname.Value = dog.Name;
            paramname.DbType = DbType.String;

            DbParameter paramexpirience = cmdInsert.CreateParameter();
            paramexpirience.ParameterName = "Expirience";
            paramexpirience.Value = dog.Image;
            paramexpirience.DbType = DbType.String;

            DbParameter paramBirthdate = cmdInsert.CreateParameter();
            paramBirthdate.ParameterName = "Birthdate";
            paramBirthdate.Value = dog.Birthdate;
            paramBirthdate.DbType = DbType.Date;

        }

        public bool UpdateDogData(int id, User newUserData)
        {
            DbCommand cmdup = this._Connection.CreateCommand();
            cmdup.CommandText = "Update users SET firstname=@firstname, lastname=@lastname" +
            "gender=@gender, birthdate=@birthdate, username=@username, password=sha2(@password, 512)" +
            "WHERE id=@uid";

            DbParameter paramFirstname = cmdup.CreateParameter();
            paramFirstname.ParameterName = "firstname";
            paramFirstname.Value = newUserData.Firstname;
            paramFirstname.DbType = DbType.String;


            cmdup.Parameters.Add(paramFirstname);

            DbParameter paramLastname = cmdup.CreateParameter();
            paramLastname.ParameterName = "lastname";
            paramLastname.Value = newUserData.Lastname;
            paramLastname.DbType = DbType.String;

            cmdup.Parameters.Add(paramLastname);

            DbParameter paramGedner = cmdup.CreateParameter();
            paramGedner.ParameterName = "gender";
            paramGedner.Value = newUserData.Gender;
            paramGedner.DbType = DbType.String;

            cmdup.Parameters.Add(paramGedner);


            return cmdup.ExecuteNonQuery() == 1;
        }

        public Dog GetDog(int id)
        {
            DbCommand cmdGetUser = this._Connection.CreateCommand();
            cmdGetUser.CommandText = "SELECT * FROM users where id=@id";

            DbParameter paramId = cmdGetUser.CreateParameter();
            paramId.ParameterName = "id";
            paramId.Value = id;
            paramId.DbType = DbType.Int32;

            cmdGetUser.Parameters.Add(paramId);
            using (DbDataReader reader = cmdGetUser.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    return null;
                }
                reader.Read();
                return new Dog
                {
                    Image = Convert.ToString(reader["Image"]),
                    Name = Convert.ToString(reader["Name"]),
                    Expirience = Convert.ToInt32(reader["Expirience"]),
                    Birthdate = Convert.ToDateTime(reader["Birthdate"]),
                    Informations = Convert.ToString(reader["Informtaion:"]),
                    Description = ""
                };

            }

        }

    }
}