﻿using Spaghetti_Coders.Data;
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

namespace Spaghetti_Coders.Controls
{
    /// <summary>
    /// Interaction logic for OrderList.xaml
    /// </summary>
    public partial class OrderList : UserControl
    {
        public delegate void UpdateOrderPageDelegate( );

        public event UpdateOrderPageDelegate UpdateOrderPage;

        public OrderList()
        {
            InitializeComponent();
            Loaded += OrderList_Loaded;
        }

        private void OrderList_Loaded( object sender, RoutedEventArgs e )
        {
            List<OrderItem> orderItemList = OrderItemData.GetOrderItems();

            OrderItemList.Children.Clear();

            foreach(OrderItem item in orderItemList)
            {
                item.UpdateOrderPage += new OrderItem.UpdateDelegate( Update );
                OrderItemList.Children.Add( item );
            }
        }

        public void Order()
        {
            var collection = OrderItemList.Children.GetEnumerator();

            while(collection.MoveNext())
            {
                OrderItem item = collection.Current as OrderItem;
                item.Ordered = true;
            }
        }

        private void Update()
        {
            UpdateOrderPage.Invoke();
        }
    }
}
