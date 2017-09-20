

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
using System.Collections;
using System.Collections.Generic;
using System.Data;
using LDP.Data;

namespace LDP.Business
{

    public class Category
    {

        #region Constructors

        public Category()
        { }


        public Category(
            int id)
        {
            GetCategory(
                id);
        }

        #endregion

        #region Private Properties

        private int id = -1;
        private Guid categoryGuid = Guid.Empty;
        private string name = string.Empty;
        private string keyMenu = string.Empty;
        private string seName = string.Empty;
        private string metaTitle = string.Empty;
        private string metaKeywords = string.Empty;
        private string metaDescription = string.Empty;
        private int status = -1;
        private int option = -1;
        private int rank = -1;
        private string icon = string.Empty;
        private string classMenu = string.Empty;
        private string classBody = string.Empty;

        #endregion

        #region Public Properties

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public Guid CategoryGuid
        {
            get { return categoryGuid; }
            set { categoryGuid = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string KeyMenu
        {
            get { return keyMenu; }
            set { keyMenu = value; }
        }
        public string SeName
        {
            get { return seName; }
            set { seName = value; }
        }
        public string MetaTitle
        {
            get { return metaTitle; }
            set { metaTitle = value; }
        }
        public string MetaKeywords
        {
            get { return metaKeywords; }
            set { metaKeywords = value; }
        }
        public string MetaDescription
        {
            get { return metaDescription; }
            set { metaDescription = value; }
        }
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        public int Option
        {
            get { return option; }
            set { option = value; }
        }
        public int Rank
        {
            get { return rank; }
            set { rank = value; }
        }
        public string Icon
        {
            get { return icon; }
            set { icon = value; }
        }
        public string ClassMenu
        {
            get { return classMenu; }
            set { classMenu = value; }
        }
        public string ClassBody
        {
            get { return classBody; }
            set { classBody = value; }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets an instance of Category.
        /// </summary>
        /// <param name="id"> id </param>
        private void GetCategory(
            int id)
        {
            using (IDataReader reader = DBCategory.GetOne(
                id))
            {
                PopulateFromReader(reader);
            }

        }


        private void PopulateFromReader(IDataReader reader)
        {
            if (reader.Read())
            {
                this.id = Convert.ToInt32(reader["Id"]);
                this.categoryGuid = new Guid(reader["CategoryGuid"].ToString());
                this.name = reader["Name"].ToString();
                this.keyMenu = reader["KeyMenu"].ToString();
                this.seName = reader["SeName"].ToString();
                this.metaTitle = reader["MetaTitle"].ToString();
                this.metaKeywords = reader["MetaKeywords"].ToString();
                this.metaDescription = reader["MetaDescription"].ToString();
                this.status = Convert.ToInt32(reader["Status"]);
                this.option = Convert.ToInt32(reader["Option"]);
                this.rank = Convert.ToInt32(reader["Rank"]);
                this.icon = reader["Icon"].ToString();
                this.classMenu = reader["ClassMenu"].ToString();
                this.classBody = reader["ClassBody"].ToString();

            }

        }

        /// <summary>
        /// Persists a new instance of Category. Returns true on success.
        /// </summary>
        /// <returns></returns>
        private bool Create()
        {
            int newID = 0;

            newID = DBCategory.Create(
                this.categoryGuid,
                this.name,
                this.keyMenu,
                this.seName,
                this.metaTitle,
                this.metaKeywords,
                this.metaDescription,
                this.status,
                this.option,
                this.rank,
                this.icon,
                this.classMenu,
                this.classBody);

            this.id = newID;

            return (newID > 0);

        }


        /// <summary>
        /// Updates this instance of Category. Returns true on success.
        /// </summary>
        /// <returns>bool</returns>
        private bool Update()
        {

            return DBCategory.Update(
                this.id,
                this.categoryGuid,
                this.name,
                this.keyMenu,
                this.seName,
                this.metaTitle,
                this.metaKeywords,
                this.metaDescription,
                this.status,
                this.option,
                this.rank,
                this.icon,
                this.classMenu,
                this.classBody);

        }





        #endregion

        #region Public Methods

        /// <summary>
        /// Saves this instance of Category. Returns true on success.
        /// </summary>
        /// <returns>bool</returns>
        public bool Save()
        {
            if (this.id > 0)
            {
                return Update();
            }
            else
            {
                return Create();
            }
        }




        #endregion

        #region Static Methods

        /// <summary>
        /// Deletes an instance of Category. Returns true on success.
        /// </summary>
        /// <param name="id"> id </param>
        /// <returns>bool</returns>
        public static bool Delete(
            int id)
        {
            return DBCategory.Delete(
                id);
        }


        /// <summary>
        /// Gets a count of Category. 
        /// </summary>
        public static int GetCount()
        {
            return DBCategory.GetCount();
        }

        private static List<Category> LoadListFromReader(IDataReader reader)
        {
            List<Category> categoryList = new List<Category>();
            try
            {
                while (reader.Read())
                {
                    Category category = new Category();
                    category.id = Convert.ToInt32(reader["Id"]);
                    category.categoryGuid = new Guid(reader["CategoryGuid"].ToString());
                    category.name = reader["Name"].ToString();
                    category.keyMenu = reader["KeyMenu"].ToString();
                    category.seName = reader["SeName"].ToString();
                    category.metaTitle = reader["MetaTitle"].ToString();
                    category.metaKeywords = reader["MetaKeywords"].ToString();
                    category.metaDescription = reader["MetaDescription"].ToString();
                    category.status = Convert.ToInt32(reader["Status"]);
                    category.option = Convert.ToInt32(reader["Option"]);
                    category.rank = Convert.ToInt32(reader["Rank"]);
                    category.icon = reader["Icon"].ToString();
                    category.classMenu = reader["ClassMenu"].ToString();
                    category.classBody = reader["ClassBody"].ToString();
                    categoryList.Add(category);

                }
            }
            finally
            {
                reader.Close();
            }

            return categoryList;

        }

        /// <summary>
        /// Gets an IList with all instances of Category.
        /// </summary>
        public static List<Category> GetAll()
        {
            IDataReader reader = DBCategory.GetAll();
            return LoadListFromReader(reader);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Category> GetByStatus(int status)
        {
            IDataReader reader = DBCategory.GetByStatus(status);
            return LoadListFromReader(reader);

        }

        /// <summary>
        /// Gets an IList with page of instances of Category.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalPages">total pages</param>
        public static List<Category> GetPage(int pageNumber, int pageSize, out int totalPages)
        {
            totalPages = 1;
            IDataReader reader = DBCategory.GetPage(pageNumber, pageSize, out totalPages);
            return LoadListFromReader(reader);
        }



        #endregion


    }

}





