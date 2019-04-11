using Expenses.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TextCell), typeof(CustomTextCell))]
namespace Expenses.iOS.CustomRenderers
{
    public class CustomTextCell : TextCellRenderer
    {
        /// <summary>
        /// Receives the TextCell object and alters it style
        /// CustomTextCell obj receives a text parameter from the styleId property in Xaml
        /// Which identifyies which type of accessory button is requested.
        /// The button will be diplayed on the extreme right of the
        /// TextCell object.
        /// The TextCell obj is then exported back into the Xaml control
        /// where it originated from.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="reusableCell"></param>
        /// <param name="tv"></param>
        /// <returns></returns>
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var thecell = base.GetCell(item, reusableCell, tv);

            switch (item.StyleId)
            {
                case "none": thecell.Accessory = UITableViewCellAccessory.None; break;
                case "checkmark": thecell.Accessory = UITableViewCellAccessory.Checkmark; break;
                case "detail-button": thecell.Accessory = UITableViewCellAccessory.DetailButton; break;
                case "disclosure": thecell.Accessory = UITableViewCellAccessory.DisclosureIndicator; break;
                default:
                    break;
            }

            return thecell;
        }
    }
}