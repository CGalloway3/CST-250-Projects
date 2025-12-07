namespace Quiz_question_4
{
    public partial class FrmMain : Form
    {
        // Class variables
        int _endNumber;
        int _count;
        
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnStartClickEH(object sender, EventArgs e)
        {
            // Initialize
            _endNumber = int.Parse(txtNumber.Text);
            _count = 0;

            // Start counting
            tmrCounter.Start();
        }

        private void TmrCounterTickEH(object sender, EventArgs e)
        {
            if (_count >= _endNumber)
            {
                tmrCounter.Stop();
            }
            else
            {
                _count++;
                lblCount.Text = _count.ToString();
            }               
        }
    }
}
