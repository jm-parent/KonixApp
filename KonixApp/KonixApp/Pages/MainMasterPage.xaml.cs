using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonixApp.MenuItems;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KonixApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMasterPage : MasterDetailPage
    {
		public MainMasterPage()
		{

			InitializeComponent();

			menuList = new List<MasterPageMenuItem>();
			//this are for android Icons you can download from android asset studio and include in Your Project Resources Folder
			// Creating our pages for menu navigation
			// Here you can define title for item, 
			// icon on the left side, and page that you want to open after selection
			//var page1 = new MasterPageMenuItem() { Title = "FastDelivery", Icon = "ic_local_shipping_black_24dp.png", TargetType = typeof(View1) };
			//var page2 = new MasterPageMenuItem() { Title = "Menus", Icon = "ic_restaurant_black_24dp", TargetType = typeof(View2) };
			//var page3 = new MasterPageMenuItem() { Title = "Free Pizza", Icon = "ic_local_pizza_black_24dp.png", TargetType = typeof(View3) };
			//var page4 = new MasterPageMenuItem() { Title = "Dining", Icon = "ic_local_dining_black_24dp.png", TargetType = typeof(View4) };
			//var page5 = new MasterPageMenuItem() { Title = "Parking", Icon = "ic_local_parking_black_24dp.png", TargetType = typeof(View3) };
			//var page6 = new MasterPageMenuItem() { Title = "LocateUs", Icon = "ic_my_location_black_24dp.png", TargetType = typeof(View2) };

			//Fot Ios icons
			var page1 = new MasterPageMenuItem() { Title = "FastDelivery", Icon = "ic_local_shipping.png", TargetType = typeof(DeliveryPage) };
			var page2 = new MasterPageMenuItem() { Title = "Menus", Icon = "ic_restaurant.png", TargetType = typeof(TestPage2) };
			var page3 = new MasterPageMenuItem() { Title = "Free Pizza", Icon = "ic_local_pizza.png", TargetType = typeof(DeliveryPage) };
			var page4 = new MasterPageMenuItem() { Title = "Dining", Icon = "ic_local_dining.png", TargetType = typeof(TestPage2) };
			var page5 = new MasterPageMenuItem() { Title = "Parking", Icon = "ic_local_parking.png", TargetType = typeof(TestPage2) };
			var page6 = new MasterPageMenuItem() { Title = "LocateUs", Icon = "ic_my_location.png", TargetType = typeof(DeliveryPage) };
			// Adding menu items to menuList
			menuList.Add(page1);
			menuList.Add(page2);
			menuList.Add(page3);
			menuList.Add(page4);
			menuList.Add(page5);
			menuList.Add(page6);


			// Setting our list to be ItemSource for ListView in MainPage.xaml
			navigationDrawerList.ItemsSource = menuList;
			// Initial navigation, this can be used for our home page
			Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(DeliveryPage)));
			this.BindingContext = new
			{
				Header = "",
				Image = "http://www3.hilton.com/resources/media/hi/GSPSCHF/en_US/img/shared/full_page_image_gallery/main/HH_food_22_675x359_FitToBoxSmallDimension_Center.jpg",
				//Footer = "         -------- Welcome To HotelPlaza --------           "
				Footer = "Welcome To Hotel Plaza"
			};
		}

	    public List<MasterPageMenuItem> menuList { get; set; }


	    private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
		{

			var item = (MasterPageMenuItem)e.SelectedItem;
			Type page = item.TargetType;
			Detail = new NavigationPage((Page)Activator.CreateInstance(page));
			IsPresented = false;
		}
	}

}
