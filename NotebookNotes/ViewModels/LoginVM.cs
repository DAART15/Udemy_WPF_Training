using NotebookNotes.Models;
using NotebookNotes.ViewModels.Commands;

namespace NotebookNotes.ViewModels
{
    public class LoginVM
    {
		private User _User;

		public User User
		{
			get { return _User; }
			set { _User = value; }
		}
		public RegisterCommand RegisterCommand { get; set; }
        public LoginCommand LoginCommand { get; set; }
        public LoginVM()
        {
            RegisterCommand = new RegisterCommand(this);
            LoginCommand = new LoginCommand(this);
        }

    }
}
