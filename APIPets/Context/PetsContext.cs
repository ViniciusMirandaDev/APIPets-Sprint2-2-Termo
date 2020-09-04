﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIPets.Context
{
    public class PetsContext
    {
        SqlConnection con = new SqlConnection();

        public PetsContext()
        {
            con.ConnectionString = @"Data Source=LAB107201\SQLEXPRESS2;Initial Catalog=PetShop;User ID=sa;Password=sa132";
        }
        public SqlConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            return con;
        }

        public void Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }

    }
}
