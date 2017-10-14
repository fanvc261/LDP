


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
using System.Collections;
using System.Collections.Generic;
using System.Data;
using LDP.Data;

namespace LDP.Business
{

    public class RegInfo
    {

        #region Constructors

        public RegInfo()
        { }


        public RegInfo(
            int id)
        {
            GetRegInfo(
                id);
        }

        #endregion

        #region Private Properties

        private int id = -1;
        private string field1 = string.Empty;
        private string field2 = string.Empty;
        private string field3 = string.Empty;
        private string field4 = string.Empty;
        private string field5 = string.Empty;
        private string field6 = string.Empty;
        private string field7 = string.Empty;
        private DateTime createdOn = DateTime.UtcNow;

        #endregion

        #region Public Properties

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Field1
        {
            get { return field1; }
            set { field1 = value; }
        }
        public string Field2
        {
            get { return field2; }
            set { field2 = value; }
        }
        public string Field3
        {
            get { return field3; }
            set { field3 = value; }
        }
        public string Field4
        {
            get { return field4; }
            set { field4 = value; }
        }
        public string Field5
        {
            get { return field5; }
            set { field5 = value; }
        }
        public string Field6
        {
            get { return field6; }
            set { field6 = value; }
        }
        public string Field7
        {
            get { return field7; }
            set { field7 = value; }
        }
        public DateTime CreatedOn
        {
            get { return createdOn; }
            set { createdOn = value; }
        }

        public string StringDate
        {
            get { return createdOn.ToString("dd/MM/yyy HH:mm:ss"); }
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Gets an instance of RegInfo.
        /// </summary>
        /// <param name="id"> id </param>
        private void GetRegInfo(
            int id)
        {
            using (IDataReader reader = DBRegInfo.GetOne(
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
                this.field1 = reader["Field1"].ToString();
                this.field2 = reader["Field2"].ToString();
                this.field3 = reader["Field3"].ToString();
                this.field4 = reader["Field4"].ToString();
                this.field5 = reader["Field5"].ToString();
                this.field6 = reader["Field6"].ToString();
                this.field7 = reader["Field7"].ToString();
                this.createdOn = Convert.ToDateTime(reader["CreatedOn"]);

            }

        }

        /// <summary>
        /// Persists a new instance of RegInfo. Returns true on success.
        /// </summary>
        /// <returns></returns>
        private bool Create()
        {
            int newID = 0;

            newID = DBRegInfo.Create(
                this.field1,
                this.field2,
                this.field3,
                this.field4,
                this.field5,
                this.field6,
                this.field7,
                this.createdOn);

            this.id = newID;

            return (newID > 0);

        }


        /// <summary>
        /// Updates this instance of RegInfo. Returns true on success.
        /// </summary>
        /// <returns>bool</returns>
        private bool Update()
        {

            return DBRegInfo.Update(
                this.id,
                this.field1,
                this.field2,
                this.field3,
                this.field4,
                this.field5,
                this.field6,
                this.field7,
                this.createdOn);

        }





        #endregion

        #region Public Methods

        /// <summary>
        /// Saves this instance of RegInfo. Returns true on success.
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
        /// Deletes an instance of RegInfo. Returns true on success.
        /// </summary>
        /// <param name="id"> id </param>
        /// <returns>bool</returns>
        public static bool Delete(
            int id)
        {
            return DBRegInfo.Delete(
                id);
        }


        /// <summary>
        /// Gets a count of RegInfo. 
        /// </summary>
        public static int GetCount()
        {
            return DBRegInfo.GetCount();
        }

        private static List<RegInfo> LoadListFromReader(IDataReader reader)
        {
            List<RegInfo> regInfoList = new List<RegInfo>();
            try
            {
                while (reader.Read())
                {
                    RegInfo regInfo = new RegInfo();
                    regInfo.id = Convert.ToInt32(reader["Id"]);
                    regInfo.field1 = reader["Field1"].ToString();
                    regInfo.field2 = reader["Field2"].ToString();
                    regInfo.field3 = reader["Field3"].ToString();
                    regInfo.field4 = reader["Field4"].ToString();
                    regInfo.field5 = reader["Field5"].ToString();
                    regInfo.field6 = reader["Field6"].ToString();
                    regInfo.field7 = reader["Field7"].ToString();
                    regInfo.createdOn = Convert.ToDateTime(reader["CreatedOn"]);
                    regInfoList.Add(regInfo);

                }
            }
            finally
            {
                reader.Close();
            }

            return regInfoList;

        }

        /// <summary>
        /// Gets an IList with all instances of RegInfo.
        /// </summary>
        public static List<RegInfo> GetAll()
        {
            IDataReader reader = DBRegInfo.GetAll();
            return LoadListFromReader(reader);

        }

        /// <summary>
        /// Gets an IList with page of instances of RegInfo.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalPages">total pages</param>
        public static List<RegInfo> GetPage(int pageNumber, int pageSize, out int totalPages)
        {
            totalPages = 1;
            IDataReader reader = DBRegInfo.GetPage(pageNumber, pageSize, out totalPages);
            return LoadListFromReader(reader);
        }



        #endregion


    }

}





