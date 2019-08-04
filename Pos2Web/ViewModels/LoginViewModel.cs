using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Pos2Web
{
    /// <summary>
    /// login penceresi için viewModel
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {

        #region PrivateMember

        #endregion

        #region Public Properties

        public string Username { get; set; }
        public SecureString Password { get; set; }
        public string SubeID { get; set; }

        public bool LoginIsRunning { get; set; }


        #endregion

        #region Commands

        public ICommand LoginCommand { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// default constructor
        /// </summary>
        public LoginViewModel()
        {

            //Create Commands

            LoginCommand = new RelayParameterizedCommand(async (parameter) => await Login(parameter));

        }

        #endregion

        /// <summary>
        /// Login işlemi burada gerçekleşecek;
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task Login(object parameter)
        {

            await RunCommand(() => this.LoginIsRunning, async () =>
            {
                await Task.Delay(5000);

                var username = this.Username;
                var subeID = this.SubeID;
                var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
            });


        }


    }
}
