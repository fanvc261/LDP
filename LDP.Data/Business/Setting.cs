

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

    public class Setting
    {

        #region Constructors

        public Setting()
        { }


        public Setting(
            int id)
        {
            GetSetting(
                id);
        }

        #endregion

        #region Private Properties

        private int id = -1;
        private Guid settingGuid = Guid.Empty;
        private string name = string.Empty;
        private string content = string.Empty;
        private int option = -1;

        #endregion

        #region Public Properties

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public Guid SettingGuid
        {
            get { return settingGuid; }
            set { settingGuid = value; }
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
        public int Option
        {
            get { return option; }
            set { option = value; }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets an instance of Setting.
        /// </summary>
        /// <param name="id"> id </param>
        private void GetSetting(
            int id)
        {
            using (IDataReader reader = DBSetting.GetOne(
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
                this.settingGuid = new Guid(reader["SettingGuid"].ToString());
                this.name = reader["Name"].ToString();
                this.content = reader["Content"].ToString();
                this.option = Convert.ToInt32(reader["Option"]);

            }

        }

        /// <summary>
        /// Persists a new instance of Setting. Returns true on success.
        /// </summary>
        /// <returns></returns>
        private bool Create()
        {
            int newID = 0;

            newID = DBSetting.Create(
                this.settingGuid,
                this.name,
                this.content,
                this.option);

            this.id = newID;

            return (newID > 0);

        }


        /// <summary>
        /// Updates this instance of Setting. Returns true on success.
        /// </summary>
        /// <returns>bool</returns>
        private bool Update()
        {

            return DBSetting.Update(
                this.id,
                this.settingGuid,
                this.name,
                this.content,
                this.option);

        }





        #endregion

        #region Public Methods

        /// <summary>
        /// Saves this instance of Setting. Returns true on success.
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
        /// Deletes an instance of Setting. Returns true on success.
        /// </summary>
        /// <param name="id"> id </param>
        /// <returns>bool</returns>
        public static bool Delete(
            int id)
        {
            return DBSetting.Delete(
                id);
        }


        /// <summary>
        /// Gets a count of Setting. 
        /// </summary>
        public static int GetCount()
        {
            return DBSetting.GetCount();
        }

        private static List<Setting> LoadListFromReader(IDataReader reader)
        {
            List<Setting> settingList = new List<Setting>();
            try
            {
                while (reader.Read())
                {
                    Setting setting = new Setting();
                    setting.id = Convert.ToInt32(reader["Id"]);
                    setting.settingGuid = new Guid(reader["SettingGuid"].ToString());
                    setting.name = reader["Name"].ToString();
                    setting.content = reader["Content"].ToString();
                    setting.option = Convert.ToInt32(reader["Option"]);
                    settingList.Add(setting);

                }
            }
            finally
            {
                reader.Close();
            }

            return settingList;

        }

        /// <summary>
        /// Gets an IList with all instances of Setting.
        /// </summary>
        public static List<Setting> GetAll()
        {
            IDataReader reader = DBSetting.GetAll();
            return LoadListFromReader(reader);

        }

        /// <summary>
        /// Gets an IList with page of instances of Setting.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalPages">total pages</param>
        public static List<Setting> GetPage(int pageNumber, int pageSize, out int totalPages)
        {
            totalPages = 1;
            IDataReader reader = DBSetting.GetPage(pageNumber, pageSize, out totalPages);
            return LoadListFromReader(reader);
        }



        #endregion


    }

}





