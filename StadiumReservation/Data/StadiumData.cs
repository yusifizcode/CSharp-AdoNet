using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using StadiumReservation.Models;

namespace StadiumReservation.Data
{
    internal class StadiumData
    {
        public void Add(Stadium stadium)
        {
            using (SqlConnection con = new SqlConnection(Sql.ConnectionString))
            {
                string query = $"INSERT INTO Stadiums (Name,HourPrice,Capacity) VALUES ('{stadium.Name}',{stadium.HourPrice},{stadium.Capacity})";

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
        }
        public List<Stadium> GetAll()
        {
            List<Stadium> stadiums = new List<Stadium>();
            using (SqlConnection con = new SqlConnection(Sql.ConnectionString))
            {
                string query = "SELECT * FROM Stadiums";

                con.Open();
                SqlCommand cmd = new SqlCommand(query,con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Stadium stadium = new Stadium
                        {
                            Id = dr.GetInt32(0),
                            Name = dr.GetString(1),
                            HourPrice = dr.GetDecimal(2),
                            Capacity = dr.GetInt32(3),
                        };
                        stadiums.Add(stadium);
                    }
                }
            }
            return stadiums;
        } 
    }
}
