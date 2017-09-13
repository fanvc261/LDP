

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
using System.Collections;
using System.Collections.Generic;
using System.Data;
using LDP.Data;

namespace LDP.Business
{

    public class Wiget
    {

        #region Constructors

        public Wiget()
        { }


        public Wiget(
            int id)
        {
            GetWiget(
                id);
        }

        #endregion

        #region Private Properties

        private int id = -1;
        private Guid wigetGuid = Guid.Empty;
        private string name = string.Empty;
        private string content = string.Empty;
        private int status = -1;
        private int option = -1;
        private int rank = -1;
        private int pageId = -1;
        private Guid containerGuid = Guid.Empty;
        private string classBody = string.Empty;

        #endregion

        #region Public Properties

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public Guid WigetGuid
        {
            get { return wigetGuid; }
            set { wigetGuid = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Content
        {
            get { return content; }
            set { content = value; }
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
        public int PageId
        {
            get { return pageId; }
            set { pageId = value; }
        }
        public Guid ContainerGuid
        {
            get { return containerGuid; }
            set { containerGuid = value; }
        }
        public string ClassBody
        {
            get { return classBody; }
            set { classBody = value; }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets an instance of Wiget.
        /// </summary>
        /// <param name="id"> id </param>
        private void GetWiget(
            int id)
        {
            using (IDataReader reader = DBWiget.GetOne(
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
                this.wigetGuid = new Guid(reader["WigetGuid"].ToString());
                this.name = reader["Name"].ToString();
                this.content = reader["Content"].ToString();
                this.status = Convert.ToInt32(reader["Status"]);
                this.option = Convert.ToInt32(reader["Option"]);
                this.rank = Convert.ToInt32(reader["Rank"]);
                this.pageId = Convert.ToInt32(reader["PageId"]);
                this.containerGuid = new Guid(reader["ContainerGuid"].ToString());
                this.classBody = reader["ClassBody"].ToString();

            }

        }

        /// <summary>
        /// Persists a new instance of Wiget. Returns true on success.
        /// </summary>
        /// <returns></returns>
        private bool Create()
        {
            int newID = 0;

            newID = DBWiget.Create(
                this.wigetGuid,
                this.name,
                this.content,
                this.status,
                this.option,
                this.rank,
                this.pageId,
                this.containerGuid,
                this.classBody);

            this.id = newID;

            return (newID > 0);

        }


        /// <summary>
        /// Updates this instance of Wiget. Returns true on success.
        /// </summary>
        /// <returns>bool</returns>
        private bool Update()
        {

            return DBWiget.Update(
                this.id,
                this.wigetGuid,
                this.name,
                this.content,
                this.status,
                this.option,
                this.rank,
                this.pageId,
                this.containerGuid,
                this.classBody);

        }





        #endregion

        #region Public Methods

        /// <summary>
        /// Saves this instance of Wiget. Returns true on success.
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
        /// Deletes an instance of Wiget. Returns true on success.
        /// </summary>
        /// <param name="id"> id </param>
        /// <returns>bool</returns>
        public static bool Delete(
            int id)
        {
            return DBWiget.Delete(
                id);
        }


        /// <summary>
        /// Gets a count of Wiget. 
        /// </summary>
        public static int GetCount()
        {
            return DBWiget.GetCount();
        }

        private static List<Wiget> LoadListFromReader(IDataReader reader)
        {
            List<Wiget> wigetList = new List<Wiget>();
            try
            {
                while (reader.Read())
                {
                    Wiget wiget = new Wiget();
                    wiget.id = Convert.ToInt32(reader["Id"]);
                    wiget.wigetGuid = new Guid(reader["WigetGuid"].ToString());
                    wiget.name = reader["Name"].ToString();
                    wiget.content = reader["Content"].ToString();
                    wiget.status = Convert.ToInt32(reader["Status"]);
                    wiget.option = Convert.ToInt32(reader["Option"]);
                    wiget.rank = Convert.ToInt32(reader["Rank"]);
                    wiget.pageId = Convert.ToInt32(reader["PageId"]);
                    wiget.containerGuid = new Guid(reader["ContainerGuid"].ToString());
                    wiget.classBody = reader["ClassBody"].ToString();
                    wigetList.Add(wiget);

                }
            }
            finally
            {
                reader.Close();
            }

            return wigetList;

        }

        /// <summary>
        /// Gets an IList with all instances of Wiget.
        /// </summary>
        public static List<Wiget> GetAll()
        {
            IDataReader reader = DBWiget.GetAll();
            return LoadListFromReader(reader);

        }

        /// <summary>
        /// Gets an IList with page of instances of Wiget.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalPages">total pages</param>
        public static List<Wiget> GetPage(int pageNumber, int pageSize, out int totalPages)
        {
            totalPages = 1;
            IDataReader reader = DBWiget.GetPage(pageNumber, pageSize, out totalPages);
            return LoadListFromReader(reader);
        }

        public static List<Wiget> GetByPageContainere(
            int pageId,
            Guid containerGuid,
            int status)
        {
            IDataReader reader = DBWiget.GetByPageContainere(pageId, containerGuid, status);
            return LoadListFromReader(reader);
        }

            #endregion


        }

}





