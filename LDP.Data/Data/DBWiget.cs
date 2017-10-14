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

    public static class DBWiget
    {


        /// <summary>
        /// Inserts a row in the Wiget table. Returns new integer id.
        /// </summary>
        /// <param name="wigetGuid"> wigetGuid </param>
        /// <param name="name"> name </param>
        /// <param name="content"> content </param>
        /// <param name="status"> status </param>
        /// <param name="option"> option </param>
        /// <param name="rank"> rank </param>
        /// <param name="pageId"> pageId </param>
        /// <param name="containerGuid"> containerGuid </param>
        /// <param name="classBody"> classBody </param>
        /// <returns>int</returns>
        public static int Create(
            Guid wigetGuid,
            string name,
            string content,
            int status,
            int option,
            int rank,
            int pageId,
            Guid containerGuid,
            string classBody)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetWriteConnectionString(), "Wiget_Insert", 9);
            sph.DefineSqlParameter("@WigetGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, wigetGuid);
            sph.DefineSqlParameter("@Name", SqlDbType.NVarChar, 1000, ParameterDirection.Input, name);
            sph.DefineSqlParameter("@Content", SqlDbType.NText, ParameterDirection.Input, content);
            sph.DefineSqlParameter("@Status", SqlDbType.Int, ParameterDirection.Input, status);
            sph.DefineSqlParameter("@Option", SqlDbType.Int, ParameterDirection.Input, option);
            sph.DefineSqlParameter("@Rank", SqlDbType.Int, ParameterDirection.Input, rank);
            sph.DefineSqlParameter("@PageId", SqlDbType.Int, ParameterDirection.Input, pageId);
            sph.DefineSqlParameter("@ContainerGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, containerGuid);
            sph.DefineSqlParameter("@ClassBody", SqlDbType.NVarChar, 250, ParameterDirection.Input, classBody);
            int newID = Convert.ToInt32(sph.ExecuteScalar());
            return newID;
        }


        /// <summary>
        /// Updates a row in the Wiget table. Returns true if row updated.
        /// </summary>
        /// <param name="id"> id </param>
        /// <param name="wigetGuid"> wigetGuid </param>
        /// <param name="name"> name </param>
        /// <param name="content"> content </param>
        /// <param name="status"> status </param>
        /// <param name="option"> option </param>
        /// <param name="rank"> rank </param>
        /// <param name="pageId"> pageId </param>
        /// <param name="containerGuid"> containerGuid </param>
        /// <param name="classBody"> classBody </param>
        /// <returns>bool</returns>
        public static bool Update(
            int id,
            Guid wigetGuid,
            string name,
            string content,
            int status,
            int option,
            int rank,
            int pageId,
            Guid containerGuid,
            string classBody)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetWriteConnectionString(), "Wiget_Update", 10);
            sph.DefineSqlParameter("@Id", SqlDbType.Int, ParameterDirection.Input, id);
            sph.DefineSqlParameter("@WigetGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, wigetGuid);
            sph.DefineSqlParameter("@Name", SqlDbType.NVarChar, 1000, ParameterDirection.Input, name);
            sph.DefineSqlParameter("@Content", SqlDbType.NText, ParameterDirection.Input, content);
            sph.DefineSqlParameter("@Status", SqlDbType.Int, ParameterDirection.Input, status);
            sph.DefineSqlParameter("@Option", SqlDbType.Int, ParameterDirection.Input, option);
            sph.DefineSqlParameter("@Rank", SqlDbType.Int, ParameterDirection.Input, rank);
            sph.DefineSqlParameter("@PageId", SqlDbType.Int, ParameterDirection.Input, pageId);
            sph.DefineSqlParameter("@ContainerGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, containerGuid);
            sph.DefineSqlParameter("@ClassBody", SqlDbType.NVarChar, 250, ParameterDirection.Input, classBody);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);

        }

        /// <summary>
        /// Deletes a row from the Wiget table. Returns true if row deleted.
        /// </summary>
        /// <param name="id"> id </param>
        /// <returns>bool</returns>
        public static bool Delete(
            int id)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetWriteConnectionString(), "Wiget_Delete", 1);
            sph.DefineSqlParameter("@Id", SqlDbType.Int, ParameterDirection.Input, id);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);

        }

        /// <summary>
        /// Gets an IDataReader with one row from the Wiget table.
        /// </summary>
        /// <param name="id"> id </param>
        public static IDataReader GetOne(
            int id)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetReadConnectionString(), "Wiget_SelectOne", 1);
            sph.DefineSqlParameter("@Id", SqlDbType.Int, ParameterDirection.Input, id);
            return sph.ExecuteReader();

        }

        /// <summary>
        /// Gets a count of rows in the Wiget table.
        /// </summary>
        public static int GetCount()
        {

            return Convert.ToInt32(SqlHelper.ExecuteScalar(
                ConnectionString.GetReadConnectionString(),
                CommandType.StoredProcedure,
                "Wiget_GetCount",
                null));

        }

        /// <summary>
        /// Gets an IDataReader with all rows in the Wiget table.
        /// </summary>
        public static IDataReader GetAll()
        {

            return SqlHelper.ExecuteReader(
                ConnectionString.GetReadConnectionString(),
                CommandType.StoredProcedure,
                "Wiget_SelectAll",
                null);

        }

        /// <summary>
        /// Gets a page of data from the Wiget table.
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

            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetReadConnectionString(), "Wiget_SelectPage", 2);
            sph.DefineSqlParameter("@PageNumber", SqlDbType.Int, ParameterDirection.Input, pageNumber);
            sph.DefineSqlParameter("@PageSize", SqlDbType.Int, ParameterDirection.Input, pageSize);
            return sph.ExecuteReader();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageId"></param>
        /// <param name="containerGuid"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static IDataReader GetByPageContainere(
            int pageId,
            Guid containerGuid,
            int status)
        {

            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetReadConnectionString(), "Wiget_SelectByPageContainer", 3);
            sph.DefineSqlParameter("@PageId", SqlDbType.Int, ParameterDirection.Input, pageId);
            sph.DefineSqlParameter("@ContainerGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, containerGuid);
            sph.DefineSqlParameter("@Status", SqlDbType.Int, ParameterDirection.Input, status);
            return sph.ExecuteReader();

        }

        public static IDataReader GetByPage(
            int pageId,
            int status)
        {

            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetReadConnectionString(), "Wiget_SelectByPage", 2);
            sph.DefineSqlParameter("@PageId", SqlDbType.Int, ParameterDirection.Input, pageId);
            sph.DefineSqlParameter("@Status", SqlDbType.Int, ParameterDirection.Input, status);
            return sph.ExecuteReader();

        }

    }

}


