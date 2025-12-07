using Quiz_question_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Quiz_question_1.Services.DataAccessLayer
{
    public class UserDAO
    {
    public List<UserModel> _users;

        public UserDAO()
        {
            _users = new List<UserModel>();
        }

        public void SaveUsers()
        {
            string serialized = JsonSerializer.Serialize(_users);
            File.WriteAllText("saveFile", serialized);
        }

        public void LoadUsers()
        {
            string serialized = File.ReadAllText("saveFile");
            _users = JsonSerializer.Deserialize<List<UserModel>>(serialized);
        }
    }
}
