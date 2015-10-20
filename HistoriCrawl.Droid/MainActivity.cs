using Android.App;
using Android.OS;
using Android.Widget;
using HistoriCrawl.Portable;

namespace HistoriCrawl.Droid
{
	[Activity(Label = "HistoriCrawl", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);

			// Get a handle on the list
			var markerList = FindViewById<ListView>(Resource.Id.markerListView);

			// Set the list adapter
			markerList.Adapter = new MarkerAdapter(this, MarkerData.Markers);

			// Set the list ItemClick handler
			markerList.ItemClick += OnItemClick;
		}


		void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			var marker = MarkerData.Markers[e.Position];

			var dialog = new AlertDialog.Builder(this);
			dialog.SetMessage(marker.Title);
			dialog.SetNeutralButton("OK", delegate { });
			dialog.Show();
		}
	}
}