using System;
using System.Drawing;

namespace MultipleScreen.Common
{
    [Serializable]
    public class Notify
    {
        #region properties

        public int Command { get; set; } = -1;
        public Image ImageUrl { get; set; }
        public string VideoUrl { get; set; } = string.Empty;

        #endregion
    }
}
