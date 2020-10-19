using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MultipleScreen.Common
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
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

    }
}
