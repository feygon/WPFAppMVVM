using PropertyChanged;
using System.ComponentModel;
using System.Threading.Tasks;

namespace FileSystemWPFApp
{

    /// <summary>
    /// A viewmodel is something that monitors its members for changes,
    ///     and shows those changes on the form.
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class FodyWeaverExample : INotifyPropertyChanged
    {
        // Looking for property to be changed.
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) =>
        { 
        
        };

        /// <summary>
        /// Self-aware property.
        /// </summary>
        public string Test {
            get; set;
        }

        public FodyWeaverExample()
        {
            Task.Run(async () =>
            {
                int i = 0;
                while (true)
                {
                    await Task.Delay(200);
                    Test = (i++).ToString();
                }
            });
        }

        public override string ToString()
        {
            { 
                return "Hello World";
            }
        }
    }
}
