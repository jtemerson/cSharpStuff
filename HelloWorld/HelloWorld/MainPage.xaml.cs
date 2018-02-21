using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HelloWorld
{
    public sealed partial class MainPage : Page
    {
        double width, height, woodLength, glassArea;
        int quantity;
        string tint;
        const double MIN_WIDTH = 0.5;
        const double MAX_WIDTH = 5.0;
        const double MIN_HEIGHT = 0.75;
        const double MAX_HEIGHT = 3.0;
        DateTime orderDate;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //width validation
            string message;

            if (widthInput.Text == "")
            {
                message = "Please enter a width.";
            }
            else if (Double.TryParse(widthInput.Text, out width))
            {

                if (Convert.ToDouble(widthInput.Text) < MIN_WIDTH || Convert.ToDouble(widthInput.Text) > MAX_WIDTH)
                {
                    message = "Width must be between " + MIN_WIDTH + " and " + MAX_WIDTH + " meters.";
                }
                else
                {
                    message = "Good Job :)";
                }
            }
            else
            {
                message = "Width field must be a number.";
            }

            error.Text = message;


            //validate Height

            if (heightInput.Text == "")
            {
                message = "Please enter a Height.";
            }
            else if (Double.TryParse(heightInput.Text, out width))
            {

                if (Convert.ToDouble(heightInput.Text) < MIN_HEIGHT || Convert.ToDouble(heightInput.Text) > MAX_HEIGHT)
                {
                    message = "Height must be between " + MIN_HEIGHT +
                    " and " + MAX_HEIGHT + " meters.";
                }
                else
                {
                    message = "";
                }
            }
            else
            {
                message = "Height field must be a number.";
            }

            error.Text = message;

            if (error.Text == "" && widthInput.Text != "" && heightInput.Text != "")
            {
                orderDate = DateTime.Now;
                width = Convert.ToDouble(widthInput.Text);
                height = Convert.ToDouble(heightInput.Text);

                if (blackInput.IsChecked == true)
                {
                    tint = blackInput.Content.ToString();

                }
                else if (brownInput.IsChecked == true)
                {
                    tint = brownInput.Content.ToString();

                }
                else if (blueInput.IsChecked == true)
                {
                    tint = blueInput.Content.ToString();

                }

                quantity = Convert.ToInt32(sliderInput.Value);


                woodLength = 2 * (width + height) * 3.25;
                glassArea = 2 * (width * height);

                var dialog = new MessageDialog("\nOrder Date: " + orderDate.ToString("dd MMM yyyy") + "\nWidth: " + width + " meter(s) \nHeight: " + height + " meter(s) \nTint: " + tint + "\nQuantity: " + quantity + "\n\nWood required: " + woodLength + " feet. \nGlass required: " + glassArea + " square meters.", "Order Details");
                await dialog.ShowAsync();

            }
            else
            {
                if (widthInput.Text == "")
                {
                    error.Text = "Width field can't be empty.";
                }

                if (heightInput.Text == "")
                {
                    error.Text = "Height field can't be empty.";
                }
            }
        }
    }
}
