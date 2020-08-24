using System;
using Xamarin.Forms;

namespace SampleEcommerce.Mobile.Components
{
    public class RatingView : StackLayout
    {
        public RatingView()
        {
            Orientation = StackOrientation.Horizontal;
        }

        public static readonly BindableProperty RateProperty = BindableProperty
         .Create(nameof(Rate), typeof(double), typeof(RatingView));

        public double Rate
        {
            get => (double)GetValue(RateProperty);
            set => SetValue(RateProperty, value);
        }

        public static readonly BindableProperty CanEditProperty = BindableProperty
        .Create(nameof(CanEdit), typeof(bool), typeof(RatingView));

        public bool CanEdit
        {
            get => (bool)GetValue(CanEditProperty);
            set => SetValue(RateProperty, value);
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (RateProperty.PropertyName == propertyName)
            {
                GenerateStarsToShow();
            }
            else if (CanEditProperty.PropertyName == propertyName)
            {
                GenerateStarsToSet();
            }
        }

        private void GenerateStarsToShow()
        {
            for (int i = 1; i <= 5; i++)
            {
                Image image = new Image();
                if (Rate < 1)
                {
                    image.Source = "star_off.png";
                }
                else if (Rate >= i)
                {
                    image.Source = "star_on.png";
                }
                else
                {
                    if (Math.Ceiling(Rate) == i)
                        image.Source = "star_half.png";
                    else
                        image.Source = "star_off.png";
                }
                Children.Add(image);
            }
        }
        private void GenerateStarsToSet(int rate = 0)
        {
            for (int i = 0; i < 5; i++)
            {
                Image image = new Image
                {
                    ClassId = i.ToString()
                };
                if (rate > i)
                {
                    image.Source = "star_on.png";
                }
                else
                {
                    image.Source = "star_off.png";
                }
                TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
                image.GestureRecognizers.Add(tapGestureRecognizer);
                tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
                Children.Add(image);
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (sender is Image image)
            {
                int rate = int.Parse(image.ClassId) + 1;
                for (int i = 1; i <= 5; i++)
                {
                    Image img = Children[i - 1] as Image;
                    if (rate >= i)
                    {
                        img.Source = "star_on.png";
                    }
                    else
                    {
                        img.Source = "star_off.png";
                    }
                }
            }
        }
    }
}
