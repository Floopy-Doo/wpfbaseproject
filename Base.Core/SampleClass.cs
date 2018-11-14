namespace Base.Core
{
    using System.ComponentModel;

    public class SampleClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int SampleProperty { get; set; }
    }
}