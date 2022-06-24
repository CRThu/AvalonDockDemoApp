using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AvalonDockMVVM.ViewModel
{
  public abstract class DockWindowAnchorableViewModel : BaseViewModel
  {
    #region Properties

    #region Title
    private string _Title;
    public string Title
    {
      get { return _Title; }
      set
      {
        if (_Title != value)
        {
          _Title = value;
          OnPropertyChanged(nameof(Title));
        }
      }
    }
    #endregion

    #endregion
  }
}
