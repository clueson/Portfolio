using Expenses.UWP.CustomRenderers;
using Windows.UI.Xaml;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

//[assembly: ExportRenderer(typeof(TextCell), typeof(CustomTextCell))]
namespace Expenses.UWP.CustomRenderers
{
    public class CustomTextCell// : TextCellRenderer
    {
        //public override Windows.UI.Xaml.DataTemplate GetTemplate(Cell cell)
        //{
        //    base.GetTemplate(cell);

        //    //extracts the passed in parameter from the StyleId property and sets the background of the cell
        //    switch (cell.StyleId)
        //    {
        //        //Possible datatemplate object to be created for UWP?
        //        case "none": ; break;
        //        case "checkmark": ; break;
        //        case "detail-button": ; break;
        //        case "disclosure": ; break;
        //        default:
        //            break;
        //    }

        //    //returns the TextCell object to caller
        //    return new Windows.UI.Xaml.DataTemplate();

        //}
    }
}
