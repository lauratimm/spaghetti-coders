using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Spaghetti_Coders.Controls;
using Spaghetti_Coders.Data;
using Spaghetti_Coders.Popups;

namespace Spaghetti_Coders.Pages
{
    /// <summary>
    /// Interaction logic for OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {

        public static readonly DependencyProperty SubtotalProperty =
            DependencyProperty.Register( "Subtotal", typeof( string ), typeof( OrderPage ), new PropertyMetadata( "$-" ) );

        public float Subtotal
        {
            get { return PriceStringToFloat( (string)GetValue( SubtotalProperty ) ); }
            set { 
                SetValue( SubtotalProperty, FloatToPriceString( value ) );
                GST = value * 5 / 100;
                Total = value + GST;
            }
        }

        public static readonly DependencyProperty GSTProperty =
            DependencyProperty.Register( "GST", typeof( string ), typeof( OrderPage ), new PropertyMetadata( "$-" ) );

        public float GST
        {
            get { return PriceStringToFloat( (string)GetValue( GSTProperty ) ); }
            set { SetValue( GSTProperty, FloatToPriceString( value ) ); }
        }

        public static readonly DependencyProperty TotalProperty =
            DependencyProperty.Register( "Total", typeof( string ), typeof( OrderPage ), new PropertyMetadata( "$-" ) );

        public float Total
        {
            get { return PriceStringToFloat((string)GetValue( TotalProperty ) ); }
            set { SetValue( TotalProperty, FloatToPriceString(value) ); }
        }

        private float PriceStringToFloat(string s)
        {
            if ( s.Equals( "$-" ) )
                return 0;
            return float.Parse( s.Replace( "$", "" ) );
        }

        private string FloatToPriceString(float f)
        {
            if ( f == 0  )
                return "$-";
            return $"${f:0.00}";
        }

        public OrderPage()
        {
            InitializeComponent();
            Loaded += OrderPage_Loaded;
        }

        private void OrderPage_Loaded( object sender, RoutedEventArgs e )
        {
            UpdatePage();

            OrderList.UpdateOrderPage += new OrderList.UpdateOrderPageDelegate( UpdatePage );
        }

        private void UpdatePage()
        {
            EmptyOrderMessage.Visibility = OrderItemData.Count == 0 ? Visibility.Visible : Visibility.Hidden;
            OrderButton.IsEnabled = OrderItemData.CanOrder();
            PayButton.IsEnabled = OrderItemData.CanPay();
            Subtotal = OrderItemData.GetTotalOrderItemPrice();
        }

        private void OrderButton_Click( object sender, RoutedEventArgs e )
        {
            OrderItemData.Order();
            OrderList.Order();
            OrderButton.IsEnabled = false;
            PayButton.IsEnabled = true; 
            OrderPopup orderPopup = new OrderPopup();
            orderPopup.Show();
        }

        private void PayButton_Click( object sender, RoutedEventArgs e )
        {
            NavigationService.Navigate( new PaymentPage
            {
                Subtotal = OrderItemData.GetPaymentPrice()
            } ) ;
        }

        private void BackButton_Click( object sender, RoutedEventArgs e )
        {
            NavigationService.GoBack();
        }
    }
}
