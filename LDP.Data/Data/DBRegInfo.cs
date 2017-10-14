
// Author:					fanvc261@gmail.com
// Created:					2017-10-5
// Last Modified:			2017-10-5
// 
// The use and distribution terms for this software are covered by the 
// Common Public License 1.0 (http://opensource.org/licenses/cpl.php)  
// which can be found in the file CPL.TXT at the root of this distribution.
// By using this software in any fashion, you are agreeing to be bound by 
// the terms of this license.
//
// You must not remove this notice, or any other, from this software.

using System;
using System.IO;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using LDP.Lib.Data;


namespace LDP.Data
{

    public static class DBRegInfo
    {


        /// <summary>
        /// Inserts a row in the RegInfo table. Returns new integer id.
        /// </summary>
        /// <param name="field1"> field1 </param>
        /// <param name="field2"> field2 </param>
        /// <param name="field3"> field3 </param>
        /// <param name="field4"> field4 </param>
        /// <param name="field5"> field5 </param>
        /// <param name="field6"> field6 </param>
        /// <param name="field7"> field7 </param>
        /// <param name="createdOn"> createdOn </param>
        /// <returns>int</returns>
        public static int Create(
            string field1,
            string field2,
            string field3,
            string field4,
            string field5,
            string field6,
            string field7,
            DateTime createdOn)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetWriteConnectionString(), "RegInfo_Insert", 8);
            sph.DefineSqlParameter("@Field1", SqlDbType.NVarChar, 500, ParameterDirection.Input, field1);
            sph.DefineSqlParameter("@Field2", SqlDbType.NVarChar, 500, ParameterDirection.Input, field2);
            sph.DefineSqlParameter("@Field3", SqlDbType.NVarChar, 500, ParameterDirection.Input, field3);
            sph.DefineSqlParameter("@Field4", SqlDbType.NVarChar, 500, ParameterDirection.Input, field4);
            sph.DefineSqlParameter("@Field5", SqlDbType.NVarChar, 500, ParameterDirection.Input, field5);
            sph.DefineSqlParameter("@Field6", SqlDbType.NVarChar, 500, ParameterDirection.Input, field6);
            sph.DefineSqlParameter("@Field7", SqlDbType.NVarChar, 2000, ParameterDirection.Input, field7);
            sph.DefineSqlParameter("@CreatedOn", SqlDbType.DateTime, ParameterDirection.Input, createdOn);
            int newID = Convert.ToInt32(sph.ExecuteScalar());
            return newID;
        }


        /// <summary>
        /// Updates a row in the RegInfo table. Returns true if row updated.
        /// </summary>
        /// <param name="id"> id </param>
        /// <param name="field1"> field1 </param>
        /// <param name="field2"> field2 </param>
        /// <param name="field3"> field3 </param>
        /// <param name="field4"> field4 </param>
        /// <param name="field5"> field5 </param>
        /// <param name="field6"> field6 </param>
        /// <param name="field7"> field7 </param>
        /// <param name="createdOn"> createdOn </param>
        /// <returns>bool</returns>
        public static bool Update(
            int id,
            string field1,
            string field2,
            string field3,
            string field4,
            string field5,
            string field6,
            string field7,
            DateTime createdOn)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetWriteConnectionString(), "RegInfo_Update", 9);
            sph.DefineSqlParameter("@Id", SqlDbType.Int, ParameterDirection.Input, id);
            sph.DefineSqlParameter("@Field1", SqlDbType.NVarChar, 500, ParameterDirection.Input, field1);
            sph.DefineSqlParameter("@Field2", SqlDbType.NVarChar, 500, ParameterDirection.Input, field2);
            sph.DefineSqlParameter("@Field3", SqlDbType.NVarChar, 500, ParameterDirection.Input, field3);
            sph.DefineSqlParameter("@Field4", SqlDbType.NVarChar, 500, ParameterDirection.Input, field4);
            sph.DefineSqlParameter("@Field5", SqlDbType.NVarChar, 500, ParameterDirection.Input, field5);
            sph.DefineSqlParameter("@Field6", SqlDbType.NVarChar, 500, ParameterDirection.Input, field6);
            sph.DefineSqlParameter("@Field7", SqlDbType.NVarChar, 2000, ParameterDirection.Input, field7);
            sph.DefineSqlParameter("@CreatedOn", SqlDbType.DateTime, ParameterDirection.Input, createdOn);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);

        }

        /// <summary>
        /// Deletes a row from the RegInfo table. Returns true if row deleted.
        /// </summary>
        /// <param name="id"> id </param>
        /// <returns>bool</returns>
        public static bool Delete(
            int id)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetWriteConnectionString(), "RegInfo_Delete", 1);
            sph.DefineSqlParameter("@Id", SqlDbType.Int, ParameterDirection.Input, id);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);

        }

        /// <summary>
        /// Gets an IDataReader with one row from the RegInfo table.
        /// </summary>
        /// <param name="id"> id </param>
        public static IDataReader GetOne(
            int id)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetReadConnectionString(), "RegInfo_SelectOne", 1);
            sph.DefineSqlParameter("@Id", SqlDbType.Int, ParameterDirection.Input, id);
            return sph.ExecuteReader();

        }

        /// <summary>
        /// Gets a count of rows in the RegInfo table.
        /// </summary>
        public static int GetCount()
        {

            return Convert.ToInt32(SqlHelper.ExecuteScalar(
                ConnectionString.GetReadConnectionString(),
                CommandType.StoredProcedure,
                "RegInfo_GetCount",
                null));

        }

        /// <summary>
        /// Gets an IDataReader with all rows in the RegInfo table.
        /// </summary>
        public static IDataReader GetAll()
        {

            return SqlHelper.ExecuteReader(
                ConnectionString.GetReadConnectionString(),
                CommandType.StoredProcedure,
                "RegInfo_SelectAll",
                null);

        }

        /// <summary>
        /// Gets a page of data from the RegInfo table.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalPages">total pages</param>
        public static IDataReader GetPage(
            int pageNumber,
            int pageSize,
            out int totalPages)
        {
            totalPages = 1;
            int totalRows
                = GetCount();

            if (pageSize > 0) totalPages = totalRows / pageSize;

            if (totalRows <= pageSize)
            {
                totalPages = 1;
            }
            else
            {
                int remainder;
                Math.DivRem(totalRows, pageSize, out remainder);
                if (remainder > 0)
                {
                    totalPages += 1;
                }
            }

            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetReadConnectionString(), "RegInfo_SelectPage", 2);
            sph.DefineSqlParameter("@PageNumber", SqlDbType.Int, ParameterDirection.Input, pageNumber);
            sph.DefineSqlParameter("@PageSize", SqlDbType.Int, ParameterDirection.Input, pageSize);
            return sph.ExecuteReader();

        }

    }

}


