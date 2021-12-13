using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace AdoDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(Configuration.CONNECTION_STRING);
            int id = int.Parse(Console.ReadLine());

            await connection.OpenAsync();

            await using (connection)
            {
                await PrintVillainsWithMoreThan3MinionsAsync(connection);

                await PrintVillainMinionsInfoByIdAsync(connection, id);
            }
        }

        private static async Task PrintVillainsWithMoreThan3MinionsAsync(SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand(Queries.VILLAINS_WITH_MORE_THAN_3_MINIONS, connection);

            SqlDataReader reader = await cmd.ExecuteReaderAsync();

            await using (reader)
            {
                while (await reader.ReadAsync())
                {
                    string villain = reader.GetString(0);
                    int minions = reader.GetInt32(1);

                    Console.WriteLine($"{villain} - {minions}");
                }
            }
        }

        private static async Task PrintVillainMinionsInfoByIdAsync(SqlConnection connection, int villainId)
        {
            SqlCommand villainNameCmd = new SqlCommand(Queries.VILLAIN_NAME_BY_ID, connection);

            //Prevents SQL Injection
            SqlParameter idParameter = new SqlParameter("@Id", SqlDbType.Int);
            idParameter.Value = villainId;
            villainNameCmd.Parameters.Add(idParameter);

            object villainNameObj = await villainNameCmd.ExecuteScalarAsync();

            if (villainNameObj == null)
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                return;
            }

            string villainName = (string)villainNameObj;

            SqlCommand villainInfoMinionsCmd = new SqlCommand(Queries.VILLAINS_WITH_MINIONS_INFO_BY_ID, connection);

            villainInfoMinionsCmd.Parameters.AddWithValue("@Id", villainId);

            SqlDataReader reader = await villainInfoMinionsCmd.ExecuteReaderAsync();
            await using (reader)
            {
                Console.WriteLine($"Villain: {villainName}");

                if (reader.HasRows == false)
                {
                    Console.WriteLine("(no minions)");
                    return;
                }

                while (await reader.ReadAsync())
                {
                    long rowNumber = reader.GetInt64(0);
                    string minionName = reader.GetString(1);
                    int minionAge = reader.GetInt32(2);

                    Console.WriteLine($"{rowNumber}. {minionName} {minionAge}");
                }
            }
        }
    }
}
