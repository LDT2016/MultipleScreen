using System.Windows.Forms;

namespace MultipleScreen.Control
{
    public partial class FormBase : Form
    {
        #region constructors

        public FormBase()
        {
            InitializeComponent();
        }

        #endregion

        #region methods

        public virtual void CloseForm() { }

        #endregion
    }
}
