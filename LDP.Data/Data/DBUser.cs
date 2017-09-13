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

    public static class DBUser
    {


        /// <summary>
        /// Inserts a row in the User table. Returns new integer id.
        /// </summary>
        /// <param name="userGuid"> userGuid </param>
        /// <param name="userName"> userName </param>
        /// <param name="email"> email </param>
        /// <param name="status"> status </param>
        /// <param name="password"> password </param>
        /// <param name="fullName"> fullName </param>
        /// <param name="option"> option </param>
        /// <returns>int</returns>
        public static int Create(
            Guid userGuid,
            string userName,
            string email,
            int status,
            string password,
            string fullName,
            int option)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetWriteConnectionString(), "User_Insert", 7);
            sph.DefineSqlParameter("@UserGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, userGuid);
            sph.DefineSqlParameter("@UserName", SqlDbType.NVarChar, 1000, ParameterDirection.Input, userName);
            sph.DefineSqlParameter("@Email", SqlDbType.NVarChar, 1000, ParameterDirection.Input, email);
            sph.DefineSqlParameter("@Status", SqlDbType.Int, ParameterDirection.Input, status);
            sph.DefineSqlParameter("@Password", SqlDbType.NVarChar, 400, ParameterDirection.Input, password);
            sph.DefineSqlParameter("@FullName", SqlDbType.NVarChar, 1000, ParameterDirection.Input, fullName);
            sph.DefineSqlParameter("@Option", SqlDbType.Int, ParameterDirection.Input, option);
            int newID = Convert.ToInt32(sph.ExecuteScalar());
            return newID;
        }


        /// <summary>
        /// Updates a row in the User table. Returns true if row updated.
        /// </summary>
        /// <param name="id"> id </param>
        /// <param name="userGuid"> userGuid </param>
        /// <param name="userName"> userName </param>
        /// <param name="email"> email </param>
        /// <param name="status"> status </param>
        /// <param name="password"> password </param>
        /// <param name="fullName"> fullName </param>
        /// <param name="option"> option </param>
        /// <returns>bool</returns>
        public static bool Update(
            int id,
            Guid userGuid,
            string userName,
            string email,
            int status,
            string password,
            string fullName,
            int option)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetWriteConnectionString(), "User_Update", 8);
            sph.DefineSqlParameter("@Id", SqlDbType.Int, ParameterDirection.Input, id);
            sph.DefineSqlParameter("@UserGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, userGuid);
            sph.DefineSqlParameter("@UserName", SqlDbType.NVarChar, 1000, ParameterDirection.Input, userName);
            sph.DefineSqlParameter("@Email", SqlDbType.NVarChar, 1000, ParameterDirection.Input, email);
            sph.DefineSqlParameter("@Status", SqlDbType.Int, ParameterDirection.Input, status);
            sph.DefineSqlParameter("@Password", SqlDbType.NVarChar, 400, ParameterDirection.Input, password);
            sph.DefineSqlParameter("@FullName", SqlDbType.NVarChar, 1000, ParameterDirection.Input, fullName);
            sph.DefineSqlParameter("@Option", SqlDbType.Int, ParameterDirection.Input, option);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);

        }

        /// <summary>
        /// Deletes a row from the User table. Returns true if row deleted.
        /// </summary>
        /// <param name="id"> id </param>
        /// <returns>bool</returns>
        public static bool Delete(
            int id)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetWriteConnectionString(), "User_Delete", 1);
            sph.DefineSqlParameter("@Id", SqlDbType.Int, ParameterDirection.Input, id);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);

        }

        /// <summary>
        /// Gets an IDataReader with one row from the User table.
        /// </summary>
        /// <param name="id"> id </param>
        public static IDataReader GetOne(
            int id)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetReadConnectionString(), "User_SelectOne", 1);
            sph.DefineSqlParameter("@Id", SqlDbType.Int, ParameterDirection.Input, id);
            return sph.ExecuteReader();

        }

        public static IDataReader GetOneByUserName(
            string userName)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetReadConnectionString(), "User_SelectOneByUserName", 1);
            sph.DefineSqlParameter("@UserName", SqlDbType.NVarChar,1000, ParameterDirection.Input, userName);
            return sph.ExecuteReader();

        }
        /// <summary>
        /// Gets a count of rows in the User table.
        /// </summary>
        public static int GetCount()
        {

            return Convert.ToInt32(SqlHelper.ExecuteScalar(
                ConnectionString.GetReadConnectionString(),
                CommandType.StoredProcedure,
                "User_GetCount",
                null));

        }

        /// <summary>
        /// Gets an IDataReader with all rows in the User table.
        /// </summary>
        public static IDataReader GetAll()
        {

            return SqlHelper.ExecuteReader(
                ConnectionString.GetReadConnectionString(),
                CommandType.StoredProcedure,
                "User_SelectAll",
                null);

        }

        /// <summary>
        /// Gets a page of data from the User table.
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

            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetReadConnectionString(), "User_SelectPage", 2);
            sph.DefineSqlParameter("@PageNumber", SqlDbType.Int, ParameterDirection.Input, pageNumber);
            sph.DefineSqlParameter("@PageSize", SqlDbType.Int, ParameterDirection.Input, pageSize);
            return sph.ExecuteReader();

        }

    }

}


