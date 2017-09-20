// Author:					fanvc261@gmail.com
// Created:					2017-9-20
// Last Modified:			2017-9-20
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

    public static class DBCategory
    {


        /// <summary>
        /// Inserts a row in the Category table. Returns new integer id.
        /// </summary>
        /// <param name="categoryGuid"> categoryGuid </param>
        /// <param name="name"> name </param>
        /// <param name="keyMenu"> keyMenu </param>
        /// <param name="seName"> seName </param>
        /// <param name="metaTitle"> metaTitle </param>
        /// <param name="metaKeywords"> metaKeywords </param>
        /// <param name="metaDescription"> metaDescription </param>
        /// <param name="status"> status </param>
        /// <param name="option"> option </param>
        /// <param name="rank"> rank </param>
        /// <param name="icon"> icon </param>
        /// <param name="classMenu"> classMenu </param>
        /// <param name="classBody"> classBody </param>
        /// <returns>int</returns>
        public static int Create(
            Guid categoryGuid,
            string name,
            string keyMenu,
            string seName,
            string metaTitle,
            string metaKeywords,
            string metaDescription,
            int status,
            int option,
            int rank,
            string icon,
            string classMenu,
            string classBody)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetWriteConnectionString(), "Category_Insert", 13);
            sph.DefineSqlParameter("@CategoryGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, categoryGuid);
            sph.DefineSqlParameter("@Name", SqlDbType.NVarChar, 1000, ParameterDirection.Input, name);
            sph.DefineSqlParameter("@KeyMenu", SqlDbType.NVarChar, 1000, ParameterDirection.Input, keyMenu);
            sph.DefineSqlParameter("@SeName", SqlDbType.NVarChar, 1000, ParameterDirection.Input, seName);
            sph.DefineSqlParameter("@MetaTitle", SqlDbType.NText, ParameterDirection.Input, metaTitle);
            sph.DefineSqlParameter("@MetaKeywords", SqlDbType.NText, ParameterDirection.Input, metaKeywords);
            sph.DefineSqlParameter("@MetaDescription", SqlDbType.NText, ParameterDirection.Input, metaDescription);
            sph.DefineSqlParameter("@Status", SqlDbType.Int, ParameterDirection.Input, status);
            sph.DefineSqlParameter("@Option", SqlDbType.Int, ParameterDirection.Input, option);
            sph.DefineSqlParameter("@Rank", SqlDbType.Int, ParameterDirection.Input, rank);
            sph.DefineSqlParameter("@Icon", SqlDbType.NVarChar, 250, ParameterDirection.Input, icon);
            sph.DefineSqlParameter("@ClassMenu", SqlDbType.NVarChar, 250, ParameterDirection.Input, classMenu);
            sph.DefineSqlParameter("@ClassBody", SqlDbType.NVarChar, 250, ParameterDirection.Input, classBody);
            int newID = Convert.ToInt32(sph.ExecuteScalar());
            return newID;
        }


        /// <summary>
        /// Updates a row in the Category table. Returns true if row updated.
        /// </summary>
        /// <param name="id"> id </param>
        /// <param name="categoryGuid"> categoryGuid </param>
        /// <param name="name"> name </param>
        /// <param name="keyMenu"> keyMenu </param>
        /// <param name="seName"> seName </param>
        /// <param name="metaTitle"> metaTitle </param>
        /// <param name="metaKeywords"> metaKeywords </param>
        /// <param name="metaDescription"> metaDescription </param>
        /// <param name="status"> status </param>
        /// <param name="option"> option </param>
        /// <param name="rank"> rank </param>
        /// <param name="icon"> icon </param>
        /// <param name="classMenu"> classMenu </param>
        /// <param name="classBody"> classBody </param>
        /// <returns>bool</returns>
        public static bool Update(
            int id,
            Guid categoryGuid,
            string name,
            string keyMenu,
            string seName,
            string metaTitle,
            string metaKeywords,
            string metaDescription,
            int status,
            int option,
            int rank,
            string icon,
            string classMenu,
            string classBody)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetWriteConnectionString(), "Category_Update", 14);
            sph.DefineSqlParameter("@Id", SqlDbType.Int, ParameterDirection.Input, id);
            sph.DefineSqlParameter("@CategoryGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, categoryGuid);
            sph.DefineSqlParameter("@Name", SqlDbType.NVarChar, 1000, ParameterDirection.Input, name);
            sph.DefineSqlParameter("@KeyMenu", SqlDbType.NVarChar, 1000, ParameterDirection.Input, keyMenu);
            sph.DefineSqlParameter("@SeName", SqlDbType.NVarChar, 1000, ParameterDirection.Input, seName);
            sph.DefineSqlParameter("@MetaTitle", SqlDbType.NText, ParameterDirection.Input, metaTitle);
            sph.DefineSqlParameter("@MetaKeywords", SqlDbType.NText, ParameterDirection.Input, metaKeywords);
            sph.DefineSqlParameter("@MetaDescription", SqlDbType.NText, ParameterDirection.Input, metaDescription);
            sph.DefineSqlParameter("@Status", SqlDbType.Int, ParameterDirection.Input, status);
            sph.DefineSqlParameter("@Option", SqlDbType.Int, ParameterDirection.Input, option);
            sph.DefineSqlParameter("@Rank", SqlDbType.Int, ParameterDirection.Input, rank);
            sph.DefineSqlParameter("@Icon", SqlDbType.NVarChar, 250, ParameterDirection.Input, icon);
            sph.DefineSqlParameter("@ClassMenu", SqlDbType.NVarChar, 250, ParameterDirection.Input, classMenu);
            sph.DefineSqlParameter("@ClassBody", SqlDbType.NVarChar, 250, ParameterDirection.Input, classBody);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);

        }

        /// <summary>
        /// Deletes a row from the Category table. Returns true if row deleted.
        /// </summary>
        /// <param name="id"> id </param>
        /// <returns>bool</returns>
        public static bool Delete(
            int id)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetWriteConnectionString(), "Category_Delete", 1);
            sph.DefineSqlParameter("@Id", SqlDbType.Int, ParameterDirection.Input, id);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);

        }

        /// <summary>
        /// Gets an IDataReader with one row from the Category table.
        /// </summary>
        /// <param name="id"> id </param>
        public static IDataReader GetOne(
            int id)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetReadConnectionString(), "Category_SelectOne", 1);
            sph.DefineSqlParameter("@Id", SqlDbType.Int, ParameterDirection.Input, id);
            return sph.ExecuteReader();

        }

        /// <summary>
        /// Gets a count of rows in the Category table.
        /// </summary>
        public static int GetCount()
        {

            return Convert.ToInt32(SqlHelper.ExecuteScalar(
                ConnectionString.GetReadConnectionString(),
                CommandType.StoredProcedure,
                "Category_GetCount",
                null));

        }

        /// <summary>
        /// Gets an IDataReader with all rows in the Category table.
        /// </summary>
        public static IDataReader GetAll()
        {

            return SqlHelper.ExecuteReader(
                ConnectionString.GetReadConnectionString(),
                CommandType.StoredProcedure,
                "Category_SelectAll",
                null);

        }


        public static IDataReader GetByStatus(
            int status)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetReadConnectionString(), "Category_SelectByStatus", 1);
            sph.DefineSqlParameter("@Status", SqlDbType.Int, ParameterDirection.Input, status);
            return sph.ExecuteReader();

        }

        /// <summary>
        /// Gets a page of data from the Category table.
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

            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetReadConnectionString(), "Category_SelectPage", 2);
            sph.DefineSqlParameter("@PageNumber", SqlDbType.Int, ParameterDirection.Input, pageNumber);
            sph.DefineSqlParameter("@PageSize", SqlDbType.Int, ParameterDirection.Input, pageSize);
            return sph.ExecuteReader();

        }

    }

}


