using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Contapper.DAL.Model
{
    public class Company:INotifyPropertyChanged
    {
        private string _id;
        private string _companyName;
        private string _city;
        private string _address;
        private string _phoneNumber;
        private Status _status;
        private string _firstEntryDate;
        private string _details;


        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != this._id)
                {
                    _id = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string CompanyName
        {
            get
            {
                return _companyName;
            }
            set
            {
                if (value != this._companyName)
                {
                    _companyName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                if (value != this._city)
                {
                    _city = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                if (value != this._address)
                {
                    _address = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                if (value != this._phoneNumber)
                {
                    _phoneNumber = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Status Status
        {
            get
            {
                return _status;
            }
            set
            {
                if (value != this._status)
                {
                    _status = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string FirstEntryDate
        {
            get
            {
                return _firstEntryDate;
            }
            set
            {
                if (value != this._firstEntryDate)
                {
                    _firstEntryDate = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Details
        {
            get
            {
                return _details;
            }
            set
            {
                if (value != this._details)
                {
                    _details = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
