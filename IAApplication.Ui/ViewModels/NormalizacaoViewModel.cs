using System.ComponentModel;
using System.Runtime.CompilerServices;
using IAApplication.Ui.Annotations;

namespace IAApplication.Ui.ViewModels
{
    public class NormalizacaoViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _pathBase;

        public string PathBase
        {
            get { return _pathBase; }
            set
            {
                if (value != _pathBase)
                {
                    _pathBase = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}