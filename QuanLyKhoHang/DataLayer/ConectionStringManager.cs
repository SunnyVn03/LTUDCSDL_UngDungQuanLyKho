using System;
using System.Data.SqlClient;
using System.IO;

namespace QuanLyKhoHang.DataLayer
{
    public class ConnectionStringManager
    {
        private SqlConnectionStringBuilder _sqlConnectionStringBuilder;

        public SqlConnectionStringBuilder _SqlConnectionStringBuilder
        {
            get
            {
                return _sqlConnectionStringBuilder;
            }
            set
            {
                _sqlConnectionStringBuilder = value;
            }
        }

        public ConnectionStringManager()
        {
            _sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
        }

        public void ReadConnectionString(string path)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    string empty = string.Empty;
                    while ((empty = streamReader.ReadLine()) != null)
                    {
                        empty = empty.Trim();
                        string[] array = empty.Split(':');
                        switch (array[0].ToLower().Trim())
                        {
                            case "server":
                                sqlConnectionStringBuilder.DataSource = array[1];
                                break;
                            case "database":
                                sqlConnectionStringBuilder.InitialCatalog = array[1];
                                break;
                            case "winnt":
                                sqlConnectionStringBuilder.IntegratedSecurity = Convert.ToBoolean(array[1]);
                                break;
                            case "uid":
                                sqlConnectionStringBuilder.UserID = array[1];
                                break;
                            case "pwd":
                                sqlConnectionStringBuilder.Password = array[1];
                                break;
                        }
                    }
                }
            }
        }

        public SqlConnectionStringBuilder ReadConnectionString(ref string err, string path)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    string empty = string.Empty;
                    while ((empty = streamReader.ReadLine()) != null)
                    {
                        empty = empty.Trim();
                        string[] array = empty.Split(':');
                        switch (array[0].ToLower().Trim())
                        {
                            case "server":
                                _sqlConnectionStringBuilder.DataSource = array[1];
                                break;
                            case "database":
                                _sqlConnectionStringBuilder.InitialCatalog = array[1];
                                break;
                            case "winnt":
                                _sqlConnectionStringBuilder.IntegratedSecurity = Convert.ToBoolean(array[1]);
                                break;
                            case "uid":
                                _sqlConnectionStringBuilder.UserID = array[1];
                                break;
                            case "pwd":
                                _sqlConnectionStringBuilder.Password = array[1];
                                break;
                        }
                    }
                }
            }
            return sqlConnectionStringBuilder;
        }

        public void WriteConnectionString(string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.CreateNew, FileAccess.Write, FileShare.Write))
            {
                using (StreamWriter streamWriter = new StreamWriter(stream))
                {
                    streamWriter.WriteLine($"server:{_sqlConnectionStringBuilder.DataSource}");
                    streamWriter.WriteLine($"database:{_sqlConnectionStringBuilder.InitialCatalog}");
                    streamWriter.WriteLine($"winnt:{_sqlConnectionStringBuilder.IntegratedSecurity.ToString()}");
                    streamWriter.WriteLine($"uid:{_sqlConnectionStringBuilder.UserID}");
                    streamWriter.WriteLine($"pwd:{_sqlConnectionStringBuilder.Password}");
                }
            }
        }

        public void WriteConnectionString(string path, SqlConnectionStringBuilder _sqlConnectionStringBuilder)
        {
            using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                using (StreamWriter streamWriter = new StreamWriter(stream))
                {
                    streamWriter.WriteLine($"server:{_sqlConnectionStringBuilder.DataSource}");
                    streamWriter.WriteLine($"database:{_sqlConnectionStringBuilder.InitialCatalog}");
                    streamWriter.WriteLine($"winnt:{_sqlConnectionStringBuilder.IntegratedSecurity.ToString()}");
                    streamWriter.WriteLine($"uid:{_sqlConnectionStringBuilder.UserID}");
                    streamWriter.WriteLine($"pwd:{_sqlConnectionStringBuilder.Password}");
                }
            }
        }
    }
}
