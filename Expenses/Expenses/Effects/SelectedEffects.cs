using Xamarin.Forms;

namespace Expenses.Effects
{
    /// <summary>
    /// Definition to define an effect on any control
    /// </summary>
    public class SelectedEffects : RoutingEffect
    {

        #region Contructors
        /// <summary>
        /// 1st overloaded constructor
        /// Calls the base class and passes an "effects ID"
        /// </summary>
        public SelectedEffects() : base("LPA.SelectedEffect")
        {
            //the effects id would be your company name etc

        }
        #endregion
    }
}
