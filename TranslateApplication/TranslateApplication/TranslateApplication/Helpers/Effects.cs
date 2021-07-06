using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TranslateApplication.Helpers
{
    public class Effects
    {
        public async void sliderEffect(Label label)
        {
            uint transitionTime = 600;
            double displacement = 1000;
            await label.TranslateTo(displacement, 0, 0);
            await Task.WhenAll(
                label.FadeTo(1, transitionTime, Easing.Linear),
                label.TranslateTo(0, label.Y, transitionTime, Easing.CubicInOut));
        }

        public async void trueEffect(Label label)
        {
            await label.ScaleTo(1.5, 400, Easing.SpringIn);
            await label.ScaleTo(1.0, 100, Easing.SpringOut);
        }
        public async void falseEffect(Label label)
        {
            await label.ScaleTo(1.5, 400, Easing.CubicIn);
            await label.ScaleTo(1.0, 100, Easing.CubicOut);
        }
    }
}
