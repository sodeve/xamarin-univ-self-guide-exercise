using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Android.App;
using Android.OS;

namespace MyTunes
{
	[Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : ListActivity
	{
		protected async override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			//ListAdapter = new ListAdapter<string>() {
			//	DataSource = new[] { "One", "Two", "Three" }
			//};
		    var songs = await SongLoader.Load();
		    var songList = songs.ToList();
		    var adapter = new ListAdapter<Song>
		    {
		        DataSource = songList,
		        TextProc = song => song.Name,
		        DetailTextProc = song => song.Artist + " - " + song.Album
		    };
		    ListAdapter = adapter;
		}
	}
}


