using Gymate7.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using SQLite;
using Gymate7.Services;
using System.Xml.Serialization;
using System.Net.Http;
using Xamarin.Essentials;

namespace Gymate7
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
           
        }
        public static ExerciseRecord LoadFromXMLString(string xmlText)
        {
            var stringReader = new System.IO.StringReader(xmlText);
            var serializer = new XmlSerializer(typeof(ExerciseRecord));
            return serializer.Deserialize(stringReader) as ExerciseRecord;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GymPage());
            App.PhoneNumber = EntryMobile.Text;
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<UserTable>();

            var item = new UserTable()
            {
                Mobile = EntryMobile.Text
            };

            db.Insert(item);
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Congratulation", "Mobile Registred", "Yes", "Cancel");
            });
        }
    }
}
