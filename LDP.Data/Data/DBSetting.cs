// Author:					fanvc261@gmail.com
// Created:					2017-9-13
// Last Modified:			2017-9-13
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

    public static class DBSetting
    {


        /// <summary>
        /// Inserts a row in the Setting table. Returns new integer id.
        /// </summary>
        /// <param name="settingGuid"> settingGuid </param>
        /// <param name="name"> name </param>
        /// <param name="content"> content </param>
        /// <param name="option"> option </param>
        /// <returns>int</returns>
        public static int Create(
            Guid settingGuid,
            string name,
            string content,
            int option)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetWriteConnectionString(), "Setting_Insert", 4);
            sph.DefineSqlParameter("@SettingGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, settingGuid);
            sph.DefineSqlParameter("@Name", SqlDbType.NVarChar, 1000, ParameterDirection.Input, name);
            sph.DefineSqlParameter("@Content", SqlDbType.NText, ParameterDirection.Input, content);
            sph.DefineSqlParameter("@Option", SqlDbType.Int, ParameterDirection.Input, option);
            int newID = Convert.ToInt32(sph.ExecuteScalar());
            return newID;
        }


        /// <summary>
        /// Updates a row in the Setting table. Returns true if row updated.
        /// </summary>
        /// <param name="id"> id </param>
        /// <param name="settingGuid"> settingGuid </param>
        /// <param name="name"> name </param>
        /// <param name="content"> content </param>
        /// <param name="option"> option </param>
        /// <returns>bool</returns>
        public static bool Update(
            int id,
            Guid settingGuid,
            string name,
            string content,
            int option)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetWriteConnectionString(), "Setting_Update", 5);
            sph.DefineSqlParameter("@Id", SqlDbType.Int, ParameterDirection.Input, id);
            sph.DefineSqlParameter("@SettingGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, settingGuid);
            sph.DefineSqlParameter("@Name", SqlDbType.NVarChar, 1000, ParameterDirection.Input, name);
            sph.DefineSqlParameter("@Content", SqlDbType.NText, ParameterDirection.Input, content);
            sph.DefineSqlParameter("@Option", SqlDbType.Int, ParameterDirection.Input, option);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);

        }

        /// <summary>
        /// Deletes a row from the Setting table. Returns true if row deleted.
        /// </summary>
        /// <param name="id"> id </param>
        /// <returns>bool</returns>
        public static bool Delete(
            int id)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetWriteConnectionString(), "Setting_Delete", 1);
            sph.DefineSqlParameter("@Id", SqlDbType.Int, ParameterDirection.Input, id);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);

        }

        /// <summary>
        /// Gets an IDataReader with one row from the Setting table.
        /// </summary>
        /// <param name="id"> id </param>
        public static IDataReader GetOne(
            int id)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetReadConnectionString(), "Setting_SelectOne", 1);
            sph.DefineSqlParameter("@Id", SqlDbType.Int, ParameterDirection.Input, id);
            return sph.ExecuteReader();

        }


        public static IDataReader GetOne(
            string name)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetReadConnectionString(), "Setting_SelectOneByName", 1);
            sph.DefineSqlParameter("@Name", SqlDbType.NVarChar,1000, ParameterDirection.Input, name);
            return sph.ExecuteReader();

        }
        /// <summary>
        /// Gets a count of rows in the Setting table.
        /// </summary>
        public static int GetCount()
        {

            return Convert.ToInt32(SqlHelper.ExecuteScalar(
                ConnectionString.GetReadConnectionString(),
                CommandType.StoredProcedure,
                "Setting_GetCount",
                null));

        }

        /// <summary>
        /// Gets an IDataReader with all rows in the Setting table.
        /// </summary>
        public static IDataReader GetAll()
        {

            return SqlHelper.ExecuteReader(
                ConnectionString.GetReadConnectionString(),
                CommandType.StoredProcedure,
                "Setting_SelectAll",
                null);

        }

        /// <summary>
        /// Gets a page of data from the Setting table.
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

            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetReadConnectionString(), "Setting_SelectPage", 2);
            sph.DefineSqlParameter("@PageNumber", SqlDbType.Int, ParameterDirection.Input, pageNumber);
            sph.DefineSqlParameter("@PageSize", SqlDbType.Int, ParameterDirection.Input, pageSize);
            return sph.ExecuteReader();

        }

    }

}


