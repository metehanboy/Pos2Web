﻿using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pos2Web
{
    /// <summary>
    /// A base view model that fires Property Changed events as needed
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #region Komut Çalıştırıcıları için yardımcı fonksiyonlar

        protected async Task RunCommand(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {
            if (updatingFlag.GetPropertyValue())
                return;

            updatingFlag.SetPropertyValue(true);

            try
            {
                await action();
            }
            finally
            {
                updatingFlag.SetPropertyValue(false);
            }
        }

        #endregion
    }
}
