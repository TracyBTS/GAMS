using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Security.Cryptography.X509Certificates;

namespace GAMS.Data
{
    public class BNALocalDatabase
    {
        SQLiteConnection connection;

        public BNALocalDatabase(string dbPath)
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            connection = new SQLiteConnection("data source="+dbPath);
            connection.Open();

            CreateDatabase();
        }

        public void CleanUpDatabaseStuff(DateTime dateTimeToEraseTo, string username = "")
        {
            using (var command = new SQLiteCommand(connection))
            {
                // Create the tables
                command.CommandText = "DELETE FROM UserTrackedInterests where DateTimeLastVisited < @DateTime and Pinned = 0" + (username != "" ? " and Username = " + username : "");
                command.Parameters.AddWithValue("@DateTimeCreated", dateTimeToEraseTo);
                command.ExecuteNonQuery();
            }
        }

        public void CreateDatabase()
        {
            string CreateUserSettingTableQuery =
            @"CREATE TABLE IF NOT EXISTS [UserSettings] (
                [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                [Username] NVARCHAR(2048)  NULL,
                [SettingController] NVARCHAR(2048)  NULL,
                [SettingProperty] VARCHAR(2048)  NULL,
                [SettingValue] VARCHAR(2048)  NULL,
                [DateTimeCreated] DATETIME  NULL,
                [DateTimeModified] DATETIME  NULL
            )";

            string CreateDataCacheEntryTableQuery =
            @"CREATE TABLE IF NOT EXISTS [DataEntryCache] (
                [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                [Key] NVARCHAR(2048) NULL,
                [Username] NVARCHAR(2048) NULL,
                [ControlType] NVARCHAR(2048) NULL,
                [PropertyName] NVARCHAR(2048) NULL,
                [Value] NVARCHAR(2048) NULL,
                [DateTimeCreated] DATETIME  NULL
            )";

            string CreateUserTrackedInterestesQuery =
            @"CREATE TABLE IF NOT EXISTS [UserTrackedInterests] (
                Username NVARCHAR(2048) NULL,
                SettingController NVARCHAR(2048) NULL,
                Value nvarchar(2048) NULL,
                DateTimeLastVisited DATETIME NULL,
                DateTimeFirstRegistered DATETIME NULL,
                TimesVisited INT NULL,
                Pinned BIT NULL,
                Notes NVARCHAR(2048) NULL
            )";

            // Create a database command
            using (var command = new SQLiteCommand(connection))
            {
                // Create the tables
                command.CommandText = CreateUserSettingTableQuery;
                command.ExecuteNonQuery(); 
                command.CommandText = CreateDataCacheEntryTableQuery;
                command.ExecuteNonQuery(); 
                command.CommandText = CreateUserTrackedInterestesQuery;
                command.ExecuteNonQuery();
            }
        }

        public List<UserSettings> getLocalDatabase_UserSetting(string username, string settingController, string settngProperty)
        {
            List<UserSettings> UserSettingValues = new List<UserSettings>();

            using (var command = new SQLiteCommand(connection))
            {
                // Select and display database entries
                command.CommandText =
                    "Select * " +
                     "FROM UserSettings " +
                     "WHERE [Username] = " + username + " and " +
                     "[SettingController] = " + settingController + " and " +
                     "[SettingProperty] = " + settngProperty;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UserSettingValues.Add(new UserSettings()
                        {
                            DateTimeCreated = Convert.ToDateTime(reader["DateTimeCreated"]),
                            DateTimeModified = Convert.ToDateTime(reader["DateTimeModified"]),
                            SettingController = reader["SettingController"].ToString(),
                            SettingProperty = reader["SettingProperty"].ToString(),
                            SettingValue = reader["SettingValue"].ToString(),
                            Username = reader["Username"].ToString(),
                            ID = Convert.ToInt32(reader["ID"]),
                        });
                    }
                }
            }

            return UserSettingValues;
        }

        public void setLocalDatabase_UserSetting(string username, string settingController, string settngProperty, string value, int iD = -1)
        {
            if (iD == -1)
            {
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "INSERT INTO UserSettings(DateTimeCreated, DateTimeModified, Username, SettingController, SettingProperty, SettingValue) " +
                        "VALUES(@DateTimeCreated, @DateTimeModified, @Username, @SettingController, @SettingProperty, @SettingValue)";

                    command.Parameters.AddWithValue("@DateTimeCreated", DateTime.Now);
                    command.Parameters.AddWithValue("@DateTimeModified", DateTime.Now);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@SettingController", settingController);
                    command.Parameters.AddWithValue("@SettingProperty", settngProperty);
                    command.Parameters.AddWithValue("@SettingValue", value);
                    command.Prepare();

                    command.ExecuteNonQuery();
                }
            }
            else
            {
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText =
                      "update UserSettings" +
                      "set DateTimeModified = @DateTimeModified, SettingValue = @SettingValue " +
                      "where ID = @iD";

                    command.Parameters.AddWithValue("@DateTimeModified", DateTime.Now);
                    command.Parameters.AddWithValue("@iD", iD);
                    command.Parameters.AddWithValue("@SettingValue", value);
                    command.Prepare();

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<DataEntryCache> getLocalDatabase_DataEntryCache(string username, string settingController, string key)
        {
            List<DataEntryCache> DataEntryCache = new List<DataEntryCache>();

            using (var command = new SQLiteCommand(connection))
            {
                // Select and display database entries
                command.CommandText =
                    "Select * " +
                     "FROM DataEntryCache " +
                     "WHERE [Username] = " + username + " and " +
                     "[SettingController] = " + settingController + " and " +
                    // "[PropertyName] = " + settingController + " and " + dont need this as we can bring the full set info to populate control
                     "[Key] = " + key;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DataEntryCache.Add(new DataEntryCache()
                        {
                            DateTimeCreated = Convert.ToDateTime(reader["DateTimeCreated"]),
                            Key = reader["SettingController"].ToString(),
                            Username = reader["Username"].ToString(),
                            ControlType = reader["ControlType"].ToString(),
                            PropertyName = reader["PropertyName"].ToString(),
                            Value = reader["SettingValue"].ToString()
                        });
                    }
                }
            }

            return DataEntryCache;
        }

        public void setLocalDatabase_DataEntryCache(string username, string propertyName, string controlType, string value, string key)
        {
            using (var command = new SQLiteCommand(connection))
            {
                //blindly delete anything that was entered
                command.CommandText = "DELETE FROM DataEntryCache where WHERE Username = '" + username  + "' AND Key = '" + key + "' AND ControlType = '" + controlType  + "' AND PropertyName = '" + propertyName +"'";
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO DataEntryCache(Key, Username, ControlType, PropertyName, Value, DateTimeCreated) " +
                    "VALUES(@key, @Username, @controlType, @propertyName, @value, @vateTimeCreated)";

                command.Parameters.AddWithValue("@DateTimeCreated", DateTime.Now);
                command.Parameters.AddWithValue("@value", value);
                command.Parameters.AddWithValue("@propertyName", propertyName);
                command.Parameters.AddWithValue("@controlType", controlType);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@key", key);
                command.Prepare();

                command.ExecuteNonQuery();
            }
        }

        public List<UserTrackedInterests> getLocalDatabase_UserTrackedInterests(string username, string settingController, string key)
        {
            List<UserTrackedInterests> UserTrackedInterestesList = new List<UserTrackedInterests>();

            using (var command = new SQLiteCommand(connection))
            {
                // Select and display database entries
                command.CommandText =
                    "Select * " +
                     "FROM UserTrackedInterestes " +
                     "WHERE [Username] = " + username + " and " +
                     "[SettingController] = " + settingController;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UserTrackedInterestesList.Add(new UserTrackedInterests()
                        {
                            Username = reader["Username"].ToString(),
                            SettingController = reader["SettingController"].ToString(),
                            DateTimeLastVisited = Convert.ToDateTime(reader["DateTimeLast"]),
                            DateTimeFirstRegistered = Convert.ToDateTime(reader["DateTimeFirstRegistered"]),
                            TimesVisited = Convert.ToInt32(reader["TimesVisited"]),
                            Pinned = Convert.ToBoolean(reader["Pinned"]),
                            Notes = reader["Notes"].ToString()
                        });
                    }
                }
            }

            return UserTrackedInterestesList;
        }

        public void setLocalDatabase_UserTrackedInterests(string username, string settingController, string value, bool isPinned, string notes = "")
        {
            //set the pinned status and notes

            using (var command = new SQLiteCommand(connection))
            {
                //blindly delete anything that was entered
                command.CommandText = "SELECT COUNT(*) FROM UserTrackedInterests WHERE Username = '" + username + "' AND SettingController = '" + settingController + "' AND Value = '" + value + "'";
                command.CommandType = System.Data.CommandType.Text;
                int RowCount = 0;
                RowCount = Convert.ToInt32(command.ExecuteScalar());

                if (RowCount > 0)
                {
                    command.CommandText = 
                        "UPDATE UserTrackedInterests" +
                        "SET DateTimeLast = @DateTimeLast = , Pinned = @isPinned, TimesVisited = TimesVisited + 1, Notes = @notes) " +
                        "WHERE Username = @username AND SetttingController = @settingController AND Value = @value";

                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@settingController", settingController);
                    command.Parameters.AddWithValue("@value", value);
                    command.Parameters.AddWithValue("@DateTimeLastVisited", DateTime.Now);
                    command.Parameters.AddWithValue("@isPinned", isPinned);
                    command.Parameters.AddWithValue("@notes", notes);
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO UserTrackedInterests (Username, SettingController, Value, DateTimeLastVisited, DateTimeFirstRegistered, TimesVisited, Pinned, Notes) " +
                        "VALUES(@username, @settingController, @value, @dateTimeLastVisited, @dateTimeFirstRegistered, @times, @isPinned, @notes)";

                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@settingController", settingController);
                    command.Parameters.AddWithValue("@value", value);
                    command.Parameters.AddWithValue("@dateTimeLastVisited", DateTime.Now);
                    command.Parameters.AddWithValue("@dateTimeFirstRegistered", DateTime.Now);
                    command.Parameters.AddWithValue("@times", 1); 
                    command.Parameters.AddWithValue("@isPinned", isPinned);
                    command.Parameters.AddWithValue("@notes", notes);
                    command.Prepare();

                    command.ExecuteNonQuery();
                }
            }
        }
    }

    public class UserSettings
    {
        public DateTime DateTimeCreated;
        public DateTime DateTimeModified;

        public int ID;
        public string Username;
        public string SettingController;
        public string SettingProperty;
        public string SettingValue;
    }

    public class DataEntryCache
    {
        public DateTime DateTimeCreated;

        public string Key;
        public string ControlType;
        public string Username;
        public string PropertyName;
        public string Value;
    }

    public class UserTrackedInterests
    {
        public string Username;
        public string SettingController;
        public DateTime DateTimeLastVisited;
        public DateTime DateTimeFirstRegistered;
        public string Value;
        public int TimesVisited;
        public bool Pinned;
        public string Notes;
    }
}
