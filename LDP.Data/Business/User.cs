

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

    public class User
    {

        #region Constructors

        public User()
        { }


        public User(
            int id)
        {
            GetUser(
                id);
        }

        public User(
            string userName)
        {
            GetUser(
                userName);
        }

        #endregion

        #region Private Properties

        private int id = -1;
        private Guid userGuid = Guid.Empty;
        private string userName = string.Empty;
        private string email = string.Empty;
        private int status = -1;
        private string password = string.Empty;
        private string fullName = string.Empty;
        private int option = -1;

        #endregion

        #region Public Properties

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public Guid UserGuid
        {
            get { return userGuid; }
            set { userGuid = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        public int Option
        {
            get { return option; }
            set { option = value; }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets an instance of User.
        /// </summary>
        /// <param name="id"> id </param>
        private void GetUser(
            int id)
        {
            using (IDataReader reader = DBUser.GetOne(
                id))
            {
                PopulateFromReader(reader);
            }

        }

        private void GetUser(
            string userName)
        {
            using (IDataReader reader = DBUser.GetOneByUserName(
                userName))
            {
                PopulateFromReader(reader);
            }

        }

        private void PopulateFromReader(IDataReader reader)
        {
            if (reader.Read())
            {
                this.id = Convert.ToInt32(reader["Id"]);
                this.userGuid = new Guid(reader["UserGuid"].ToString());
                this.userName = reader["UserName"].ToString();
                this.email = reader["Email"].ToString();
                this.status = Convert.ToInt32(reader["Status"]);
                this.password = reader["Password"].ToString();
                this.fullName = reader["FullName"].ToString();
                this.option = Convert.ToInt32(reader["Option"]);

            }

        }

        /// <summary>
        /// Persists a new instance of User. Returns true on success.
        /// </summary>
        /// <returns></returns>
        private bool Create()
        {
            int newID = 0;

            newID = DBUser.Create(
                this.userGuid,
                this.userName,
                this.email,
                this.status,
                this.password,
                this.fullName,
                this.option);

            this.id = newID;

            return (newID > 0);

        }


        /// <summary>
        /// Updates this instance of User. Returns true on success.
        /// </summary>
        /// <returns>bool</returns>
        private bool Update()
        {

            return DBUser.Update(
                this.id,
                this.userGuid,
                this.userName,
                this.email,
                this.status,
                this.password,
                this.fullName,
                this.option);

        }





        #endregion

        #region Public Methods

        /// <summary>
        /// Saves this instance of User. Returns true on success.
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
        /// Deletes an instance of User. Returns true on success.
        /// </summary>
        /// <param name="id"> id </param>
        /// <returns>bool</returns>
        public static bool Delete(
            int id)
        {
            return DBUser.Delete(
                id);
        }


        /// <summary>
        /// Gets a count of User. 
        /// </summary>
        public static int GetCount()
        {
            return DBUser.GetCount();
        }

        private static List<User> LoadListFromReader(IDataReader reader)
        {
            List<User> userList = new List<User>();
            try
            {
                while (reader.Read())
                {
                    User user = new User();
                    user.id = Convert.ToInt32(reader["Id"]);
                    user.userGuid = new Guid(reader["UserGuid"].ToString());
                    user.userName = reader["UserName"].ToString();
                    user.email = reader["Email"].ToString();
                    user.status = Convert.ToInt32(reader["Status"]);
                    user.password = reader["Password"].ToString();
                    user.fullName = reader["FullName"].ToString();
                    user.option = Convert.ToInt32(reader["Option"]);
                    userList.Add(user);

                }
            }
            finally
            {
                reader.Close();
            }

            return userList;

        }

        /// <summary>
        /// Gets an IList with all instances of User.
        /// </summary>
        public static List<User> GetAll()
        {
            IDataReader reader = DBUser.GetAll();
            return LoadListFromReader(reader);

        }

        /// <summary>
        /// Gets an IList with page of instances of User.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalPages">total pages</param>
        public static List<User> GetPage(int pageNumber, int pageSize, out int totalPages)
        {
            totalPages = 1;
            IDataReader reader = DBUser.GetPage(pageNumber, pageSize, out totalPages);
            return LoadListFromReader(reader);
        }



        #endregion


    }

}





