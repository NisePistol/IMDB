using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Text.Json;

namespace IMDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void KlickSökFilm(object sender, RoutedEventArgs e)
        {
            //Url till adressen
            string url = "https://www.omdbapi.com/?apikey=c2aada75&t=" + rutaFilmNamn.Text;

            //Skapar Web klient
            WebClient klient = new WebClient();

            //Laddar ner informationen
            string json = klient.DownloadString(url);
            
            //Skapar instans av film och fyller den med informationen från APIn
            Film söktFilm = JsonSerializer.Deserialize<Film>(json);

            rutaFilmTitel.Text = söktFilm.Title;
            rutaFilmÅr.Text = söktFilm.Year;
            rutaFilmDirektör.Text = söktFilm.Director;
            rutaFilmRating.Text = söktFilm.imdbRating;
        }

        private void KlickÅterställ(object sender, RoutedEventArgs e)
        {
            rutaFilmTitel.Text = "";
            rutaFilmÅr.Text = "";
            rutaFilmDirektör.Text = "";
            rutaFilmRating.Text = "";
            rutaFilmNamn.Text = "";
        }
    }

    class Film
    {
        public string Title {get; set;}
        public string Year {get; set;}
        public string Director {get; set;}
        public string imdbRating {get; set;}
    }
}
