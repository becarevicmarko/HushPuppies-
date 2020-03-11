using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;

using MySql.Data.MySqlClient;

namespace HushPuppies_N_M.Models.DB
{
    public class DogDB
    {
        private string _connectionString = "Server=localhost;Database=db_einfuehrung; Uid=root;Pwd=root;";
        private MySqlConnection _connection;

        public void Open()
        {
            if (this._connection == null)
            {
                this._connection = new MySqlConnection(this._connectionString);
            }
            if (this._connection.State != ConnectionState.Open)
            {
                this._connection.Open();
            }

        }
        public void Close()
        {
            if ((this._connection != null) && (this._connection.State != ConnectionState.Closed))
            {
                this._connection.Close();
            }
        }

        public bool Insert(Dog dog)
        {
            if(dog == null)
            {
                return false;
            }

            DbCommand cmdInsert = this._connection.CreateCommand();
            cmdInsert.CommandText = "INSERT INTO dogs Values(@image, null, @name, @expirience, @birthdate, @information, @description)";

            DbParameter paramImg = cmdInsert.CreateParameter();
            paramImg.ParameterName = "image";
            paramImg.Value = dog.Image;
            paramImg.DbType = DbType.String;

            DbParameter paramName = cmdInsert.CreateParameter();
            paramName.ParameterName = "name";
            paramName.Value = dog.Name;
            paramName.DbType = DbType.String;

            DbParameter paramExcp = cmdInsert.CreateParameter();
            paramExcp.ParameterName = "expirience";
            paramExcp.Value = dog.Expirience;
            paramExcp.DbType = DbType.Int32;

            DbParameter paramBirth = cmdInsert.CreateParameter();
            paramBirth.ParameterName = "birthdate";
            paramBirth.Value = dog.Birthdate;
            paramBirth.DbType = DbType.Date;

            DbParameter paramInfo = cmdInsert.CreateParameter();
            paramInfo.ParameterName = "information";
            paramInfo.Value = dog.Information;
            paramInfo.DbType = DbType.String;

            DbParameter paramDesc = cmdInsert.CreateParameter();
            paramDesc.ParameterName = "description";
            paramDesc.Value = dog.Description;
            paramDesc.DbType = DbType.String;

            cmdInsert.Parameters.Add(paramImg);
            cmdInsert.Parameters.Add(paramName);
            cmdInsert.Parameters.Add(paramExcp);
            cmdInsert.Parameters.Add(paramBirth);
            cmdInsert.Parameters.Add(paramInfo);
            cmdInsert.Parameters.Add(paramDesc);


            return cmdInsert.ExecuteNonQuery() == 1;
        }

        List<Dog> GetAllDogs()
        {
            List<Dog> dogs = new List<Dog>();

            DbCommand cmdSelect = this._connection.CreateCommand();
            cmdSelect.CommandText = "SELECT * FROM dogs ";

            using (DbDataReader reader = cmdSelect.ExecuteReader())
            {
                while (reader.Read())
                {
                    dogs.Add(
                        new Dog
                        {
                            Id = Convert.ToString(reader["id"]),
                            Image = Convert.ToString(reader["image"]),
                            Name = Convert.ToString(reader["name"]),
                            Expirience = Convert.ToInt32(reader["expirience"]),
                            Birthdate = Convert.ToDateTime(reader["birthdate"]),
                            Information = Convert.ToString(reader["information"]),
                            Description = Convert.ToString(reader["description"])
                        });

                }
            }

            return dogs;
        }



    }
}