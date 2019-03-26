﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.Controls.GalleryPages.CollectionViewGalleries.EmptyViewGalleries
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmptyViewSwapGallery : ContentPage
	{
		readonly DemoFilteredItemSource _demoFilteredItemSource = new DemoFilteredItemSource();

		public EmptyViewSwapGallery()
		{
			InitializeComponent();

			CollectionView.ItemTemplate = ExampleTemplates.PhotoTemplate();

			CollectionView.ItemsSource = _demoFilteredItemSource.Items;

			SearchBar.SearchCommand = new Command(() =>
			{
				_demoFilteredItemSource.FilterItems(SearchBar.Text);
			});

			EmptyViewSwitch.Toggled += EmptyViewSwitchToggled;

			SwitchEmptyView();
		}

		private void EmptyViewSwitchToggled(object sender, ToggledEventArgs e)
		{
			SwitchEmptyView();
		}

		void SwitchEmptyView()
		{
			CollectionView.EmptyView = EmptyViewSwitch.IsToggled
			   ? Resources["EmptyView1"]
			   : Resources["EmptyView2"];
		}
	}
}