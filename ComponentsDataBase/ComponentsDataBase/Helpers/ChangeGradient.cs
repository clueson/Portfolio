using System;
using System.Windows;
using System.Windows.Media;

/// <summary>
/// This helper changes a background gradient on any control that calls it.
/// accessable via an interface
/// </summary>
namespace ComponentsDataBase.Helpers
{
    interface IChangeGradient
    {
        LinearGradientBrush CreateLinearGradientFill(SolidColorBrush g1, SolidColorBrush g2);
    }
    internal class ChangeGradient : IChangeGradient
    {
        #region Fields
        private Color _gradstop1 = Colors.Gray;
        private Color _gradstop2 = Colors.LightGray;
        #endregion

        #region Properties
        LinearGradientBrush LineargradientBr { get; set; }
        #endregion

        #region Methods
        public LinearGradientBrush CreateLinearGradientFill(SolidColorBrush grad1, SolidColorBrush grad2)
        {
            //Assigns the property the lineargradient object
            LineargradientBr = SetLinearBrush(grad1, grad2);
            
            //returns the object
            return LineargradientBr;
        }
        private LinearGradientBrush SetLinearBrush(SolidColorBrush g1, SolidColorBrush g2)
        {
            // Create a custom linear gradient with two stops.   
            LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush();

            //assigns the solidcolour brushes to the gradient stop colours
            _gradstop1 = g1.Color;
            _gradstop2 = g2.Color;

            //sets the start and stop points of the gradient
            myLinearGradientBrush.StartPoint = new Point(1.003, 0.438);
            myLinearGradientBrush.EndPoint = new Point(-0.155, 0.445);
            myLinearGradientBrush.GradientStops.Add(new GradientStop(_gradstop1, 0.0));
            myLinearGradientBrush.GradientStops.Add(new GradientStop(_gradstop2, 1));

            //returns the new gradient to the caller
            return myLinearGradientBrush;
        }
        #endregion

    }
}
