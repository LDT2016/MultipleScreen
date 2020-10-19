﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MultipleScreen
{
    [Serializable]

    public class Notify : INotifyPropertyChanged
    {
        private string _deviceStatus = string.Empty;
        public string DeviceStatus
        {
            get
            {
                return _deviceStatus;
            }
            set
            {
                if (_deviceStatus != value)
                {
                    _deviceStatus = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("DeviceStatus"));
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
