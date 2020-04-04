using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileChallenge
{
    class TextFileParser
    {
        private string _fileName;

        private string[] _colNames;

        public TextFileParser(string fileName)
        {
            _fileName = fileName;

            SetColNames();
        }

        private void SetColNames()
        {
            using (StreamReader file = new StreamReader(_fileName))
            {
                _colNames = file.ReadLine().Split(',');
                file.Close();
            }
        }

        public List<UserModel> ParseFile()
        {
            var users = new List<UserModel>();

            using (StreamReader file = new StreamReader(_fileName))
            {
                string line;

                //Skip headers
                file.ReadLine();
                while ((line = file.ReadLine()) != null)
                {
                    UserModelBuilder userBuilder = new UserModelBuilder();
                    string[] values = line.Split(',');

                    for (int i = 0;i < _colNames.Length;i++)
                    {
                        userBuilder.AddProperty(_colNames[i], values[i]);
                    }

                    users.Add(userBuilder.Build());
                }
            file.Close();
            }

            return users;
        }

        public void SaveFile(List<UserModel> users)
        {
            using (StreamWriter file = new StreamWriter(_fileName, false))
            {
                file.WriteLine(string.Join(",", _colNames));

                foreach (var user in users)
                {
                    var values = new List<string>();
                    foreach(var colName in _colNames)
                    {
                        switch (colName)
                        {
                            case "FirstName":
                                values.Add(user.FirstName);
                                break;
                            case "LastName":
                                values.Add(user.LastName);
                                break;
                            case "Age":
                                values.Add(user.Age.ToString());
                                break;
                            case "IsAlive":
                                values.Add(user.IsAlive ? "1" : "0");
                                break;
                            default:
                                throw new Exception($"Failed to parse file. Invalid Column Name: {colName}.");
                        }
                    }
                    file.WriteLine(string.Join(",", values));
                }
                file.Close();
            }
        }

        /* //Not sure if multiple file parsing is part of challenge?
        public void ParseFiles(string[] files)
        {
            foreach (var file in files)
                ParseFile(file);
        }
        */

    }
}
