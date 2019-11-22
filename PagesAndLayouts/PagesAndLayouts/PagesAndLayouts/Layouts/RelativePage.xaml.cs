using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PagesAndLayouts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RelativePage : ContentPage
    {
        public RelativePage()
        {
            InitializeComponent();
            RelativeLayout.SetYConstraint(LabelUnderlineBoxView, Constraint.RelativeToView(CenterLabel, (r, v) =>
            {
                return v.Y + v.Height;
            }));
        }
    }
}