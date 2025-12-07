using Quiz_question_1.Models;

namespace Quiz_question_1.PresentationLayer
{
    public partial class FrmUserInfo : Form
    {
        private UserModel _user;
        public FrmUserInfo()
        {
            InitializeComponent();
            _user = new UserModel();
        }

        private void BtnAcceptClickEH(object sender, EventArgs e)
        {
            _user.Name = txtName.Text;
            _user.Age = int.Parse(TxtAge.Name);
        }
    }
}
