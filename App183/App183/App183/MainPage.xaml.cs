using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App183
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        ObservableCollection<myModel> FixtureCollection = new ObservableCollection<myModel>();
        public MainPage()
        {
            InitializeComponent();

            League LeagueOne = new League() { name = "one" };
            League LeagueTwo = new League() { name = "two" };
            League LeagueThree = new League() { name = "three" };

            HomeTeam HomeTeamOne = new HomeTeam() { team_name = "HomeTeamOne" };
            HomeTeam HomeTeamTwo = new HomeTeam() { team_name = "HomeTeamTwo" };
            HomeTeam HomeTeamThree = new HomeTeam() { team_name = "HomeTeamThree" };

            AwayTeam AwayTeamOne = new AwayTeam() { team_name = "AwayTeamOne" };
            AwayTeam AwayTeamTwo = new AwayTeam() { team_name = "AwayTeamTwo" };
            AwayTeam AwayTeamThree = new AwayTeam() { team_name = "AwayTeamThree" };


            Fixture FixtureOne = new Fixture() { league = LeagueOne, homeTeam = HomeTeamOne, awayTeam = AwayTeamOne};
            Fixture FixtureTwo = new Fixture() { league = LeagueTwo, homeTeam = HomeTeamTwo, awayTeam = AwayTeamTwo };
            Fixture FixtureThree = new Fixture() { league = LeagueThree, homeTeam = HomeTeamThree, awayTeam = AwayTeamThree };


            myModel myModelOne = new myModel(FixtureOne.league.name) { FixtureOne };
            myModel myModelTwo = new myModel(FixtureTwo.league.name) { FixtureTwo };
            myModel myModelThree = new myModel(FixtureThree.league.name) {FixtureThree };

            FixtureCollection.Add(myModelOne);
            FixtureCollection.Add(myModelTwo);
            FixtureCollection.Add(myModelThree);

            LeaguesList.ItemsSource = FixtureCollection;

            BindingContext = this;
        }
    }

    public class myModel : List<Fixture>
    {
        public string name { get; set; }
        public myModel( string Name) {
            name = Name;
        }
    }

    public class League
    {
        public string name { get; set; }
        public string country { get; set; }
        public string logo { get; set; }
        public string flag { get; set; }
    }

    public class HomeTeam
    {
        public int team_id { get; set; }
        public string team_name { get; set; }
        public string logo { get; set; }
    }

    public class AwayTeam
    {
        public int team_id { get; set; }
        public string team_name { get; set; }
        public string logo { get; set; }
    }

    public class Score
    {
        public string halftime { get; set; }
        public string fulltime { get; set; }
        public string extratime { get; set; }
        public string penalty { get; set; }
    }

    public class Fixture
    {
        public int fixture_id { get; set; }
        public int league_id { get; set; }
        public League league { get; set; }
        public DateTime event_date { get; set; }
        public int event_timestamp { get; set; }
        public int? firstHalfStart { get; set; }
        public int? secondHalfStart { get; set; }
        public string round { get; set; }
        public string status { get; set; }
        public string statusShort { get; set; }
        public int elapsed { get; set; }
        public string venue { get; set; }
        public string referee { get; set; }
        public HomeTeam homeTeam { get; set; }
        public AwayTeam awayTeam { get; set; }
        public int? goalsHomeTeam { get; set; }
        public int? goalsAwayTeam { get; set; }
        public Score score { get; set; }
    }

    public class Api
    {
        public int results { get; set; }
        public List<Fixture> Fixtures { get; set; }
    }

    public class RootFixtures
    {
        public Api api { get; set; }
    }
}
