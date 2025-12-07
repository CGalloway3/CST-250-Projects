using Quiz_question_1.Services.DataAccessLayer;

namespace Quiz_question_1.Services.BusinessLogicLayer
{
    public class UserLogic
    {
        public UserDAO Users { get; set; }
        public UserLogic() 
        {
            Users = new UserDAO();
        }

        public void SaveUsers()
        {
            Users.SaveUsers();
        }

        public void LoadUsers() 
        {
            Users.LoadUsers();
        }
    }
}
