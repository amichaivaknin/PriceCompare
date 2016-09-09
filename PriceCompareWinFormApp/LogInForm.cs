using System;
using System.ComponentModel;
using System.Windows.Forms;
using PriceCompareControl;
using PriceCompareControl.Strings;

namespace PriceCompareWinFormApp
{
    public sealed partial class LogInForm : Form
    {
        private readonly IUsersManager _usersManager;

        public LogInForm()
        {
            InitializeComponent();
            Text=Strings.LoginWindowName;
            HelloLabel.Text=Strings.WellcomeMessage;
            UserNameLabel.Text = Strings.UserNameMessage;
            PasswordLabel.Text = Strings.PasswordMessage;
            LoginButton.Text = Strings.LoginButton;
            SignupButton.Text = Strings.SignUpButton;
            UnregisteredButton.Text = Strings.UnRegisteredButton;
            _usersManager=new UsersManager();
            LoginWorker.RunWorkerCompleted +=LoginWorker_RunWorkerCompleted;
            NewUserWorker.RunWorkerCompleted+= NewUserWorker_RunWorkerCompleted;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var username = UserNameTextBox.Text;
            var password = PasswordTextBox.Text;
            if (CheckUserNameAndPassword(username,password))
            {
                var data = new[] {username, password};
               LoginWorker.RunWorkerAsync(data); 
            }
            else
            {
                MessageBox.Show(Strings.InvalidUserNameOrPassword);
            }    
        }

        private void UnregisteredButton_Click(object sender, EventArgs e)
        {
          OpenItemsSelectionWindow("Unregistered User");
        }

        private void SignupButton_Click(object sender, EventArgs e)
        {
            var username = UserNameTextBox.Text;
            var password = PasswordTextBox.Text;
            if (CheckUserNameAndPassword(username, password))
            {
                var data = new[] { username, password };
                NewUserWorker.RunWorkerAsync(data);
            }
            else
            {
                MessageBox.Show(Strings.InvalidUserNameOrPassword);
            }
        }

        private void OpenItemsSelectionWindow(string username)
        {
            var itemsSelectionFrom=new ItemsSelectionFrom(username);
            itemsSelectionFrom.Show();
            Hide();
        }

        private static bool CheckUserNameAndPassword(string username, string password)
        {
            return username.Length != 0 && password.Length != 0;
        }

        private void LoginWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var data = e.Argument as string[];
            e.Result = _usersManager.CheckUserNameAndPassword(data?[0], data?[1]);
        }

        private void LoginWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var result = (bool) e.Result;
            if (result)
            {
              OpenItemsSelectionWindow(UserNameTextBox.Text);  
            }
            else
            {
                MessageBox.Show(Strings.WorngUserNameOrPassword);
            }
        }

        private void NewUserWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var data = e.Argument as string[];
            e.Result = _usersManager.AddNewUser(data?[0], data?[1]);
        }

        private static void NewUserWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var result = (bool)e.Result;
            MessageBox.Show(result ? Strings.NewUser : Strings.UserAllreadyExists);
        }
    }
}
