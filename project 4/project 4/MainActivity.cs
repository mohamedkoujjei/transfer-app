using System;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;

namespace project_4
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{
        #DATABAS
        private static MainActivity _instance;
        private readonly MySqlConnection _connection;

        private const string Server = "localhost";
        private const string Database = "project4";
        private const string User = "root";
        private const string Password = "admin";

        public static MainActivity Get();

        private MainActivity()
        {
            StringBuilder connectionString = new StringBuilder();
            connectionString.Append("SERVER=" + Server + ";");
            connectionString.Append("DATABASE=" + Database + ";");
            connectionString.Append("UID=" + User + ";");
            connectionString.Append("PASSWORD=" + Password + ";");

            _connection = new MySqlConnection(connectionString.ToString());
        }

        public void OpenConnection();

        public void CloseConnection();

        public MySqlConnection GetConnection();
  

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.activity_main);

			Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

			FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
	}
}

