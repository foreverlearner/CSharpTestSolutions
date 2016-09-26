using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTextboxInput
{
    class Numbers : INotifyPropertyChanged
    {
        #region Members
        int _firstNo;
        int _secondNo;
        #endregion

        #region Properties
        public int FirstNo
        {
            get { return _firstNo; }
            set
            {
                _firstNo = value;
                NotifyPropertyChange("FirstNo");
            }
        }

        public int SecondNo
        {
            get { return _secondNo; }
            set
            {
                _secondNo = value;
                NotifyPropertyChange("SecondNo");
            }
        }

        public int Answer
        {
            get { return FirstNo + SecondNo; }
        }
        #endregion

        #region NotifyPropertyChange
        /// <summary>
        /// Occurs when a property value changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raise the  <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName"></param>
        public void NotifyPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion    
    }
}
