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

namespace film

{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dodawanieFilmuOpis.Content = "Tytuł    Rok produkcji    Nagrody \n Kategoria    Główny aktor    Reżyser";
            dodawanieFilmuOpis.VerticalContentAlignment = VerticalAlignment.Center;
            dodawanieFilmuOpis.HorizontalContentAlignment = HorizontalAlignment.Center;
        }

        private void przyciskDodajAktora_Click(object sender, RoutedEventArgs e)
        {
            using (var ctx = new bazaEntities())
            {
                bool czyPoprawne = true;
                var nazwaAktora = inputDodajAktora.Text;
                var dane = nazwaAktora.Split(' ');

                string imie = "";
                string nazwisko = "";

                if (dane.Length != 2 )
                {
                    MessageBox.Show("Niewłaściwe dane aktor");
                    czyPoprawne = false;
                }
                else
                {
                    imie = dane[0];
                    nazwisko = dane[1];
                }
                if (imie == "" || nazwisko == "")
                {
                    MessageBox.Show("Niewłaściwe dane aktor");
                    czyPoprawne = false;
                }

                if (czyPoprawne)
                {
                    ctx.Actor.Add(new Actor
                    {
                        FirstName = imie,
                        LastName = nazwisko,
                    });

                    ctx.SaveChanges();
                    MessageBox.Show("Dodano aktora");
                }
            }
        }

        private void przyciskDodajReżysera_Click(object sender, RoutedEventArgs e)
        {
            using (var ctx = new bazaEntities())
            {
                bool czyPoprawne = true;
                var daneRezysera = inputDodajRezysera.Text;
                var dane = daneRezysera.Split(' ');
                if(dane.Length != 3)
                {
                    czyPoprawne = false;
                    MessageBox.Show("Niewłaściwe dane reżyser");
                }
                    string imie = "";
                string nazwisko = "";
                string rodzaj = "";

                imie = dane[0];
                nazwisko = dane[1];
                rodzaj = "Rezyser " + dane[2];

                if (imie == "" || nazwisko == "" || rodzaj == "")
                {
                    czyPoprawne = false;
                    MessageBox.Show("Niewłaściwe dane reżyser");
                }

                if (czyPoprawne)
                {
                    ctx.Director.Add(new Director
                    {
                        FirstName = imie,
                        LastName = nazwisko,
                        DirectorType = rodzaj,
                    });

                    ctx.SaveChanges();
                    MessageBox.Show("Dodano reżysera");
                }
            }
        }

        private void przyciskDodajKategorie_Click(object sender, RoutedEventArgs e)
        {
            using (var ctx = new bazaEntities())
            {
                bool czyPoprawna = true;
                var nazwa = inputDodajKategorie.Text;

                if (nazwa == "")
                {
                    czyPoprawna = false;
                    MessageBox.Show("Nie podano nazwy");
                }

                if (czyPoprawna)
                {
                    ctx.Category.Add(new Category
                    {
                        Name = nazwa,
                    });

                    ctx.SaveChanges();
                    MessageBox.Show("Dodano kategorię");
                }
            }
        }

        private void przyciskDodajFilm_Click(object sender, RoutedEventArgs e)
        {
            bool czyPoprawny = true;
            string tytulFilmu = inputFilmTytul.Text;
            string dataFilmu = inputFilmRokProduckji.SelectedDate.Value.ToShortDateString();
            string nagrodyFilmu = inputFilmNagrody.Text;
            string kategoriaFilmu = inputFilmKategoria.Text;
            string glownyAktorFilmu = inputFilmAktor.Text;
            string rezyserFilmu = inputFilmRezyser.Text;

            if (tytulFilmu == "" || dataFilmu == "" || nagrodyFilmu == "" || kategoriaFilmu == "" ||
                glownyAktorFilmu == "" || rezyserFilmu == "")
            {
                czyPoprawny = false;
                MessageBox.Show("Nie wypełniono wszystkich wymaganych pól");
            }

            string imieAktor = "";
            string nazwiskoAktor = "";

            string[] daneAktora = glownyAktorFilmu.Split(' ');
            if (daneAktora.Length == 2)
            {
                imieAktor = daneAktora[0];
                nazwiskoAktor = daneAktora[1];
            }
            else
            {
                MessageBox.Show("Nieprawidłowy aktor");
            }

            string imieRezyser = "";
            string nazwiskoRezyser = "";
            string rodzajRezyser = "";

            string[] daneRezysera = rezyserFilmu.Split(' ');
            if (daneRezysera.Length == 3)
            {
                imieRezyser = daneRezysera[0];
                nazwiskoRezyser = daneRezysera[1];
                rodzajRezyser = "Rezyser " + daneRezysera[2];
            }

            if (czyPoprawny)
            {
                using (var ctx = new bazaEntities())
                {
                    bool czyJestPowiazanie = true;

                    var kategoria = ctx.Category.SingleOrDefault(x => x.Name == kategoriaFilmu);
                    var aktor = ctx.Actor.SingleOrDefault(x => x.FirstName == imieAktor && x.LastName == nazwiskoAktor);
                    var rezyser = ctx.Director.SingleOrDefault(x => x.FirstName == imieRezyser && x.LastName == nazwiskoRezyser &&
                    x.DirectorType == rodzajRezyser);

                    if (kategoria == null || aktor == null || rezyser == null) czyJestPowiazanie = false;

                    if (czyJestPowiazanie)
                    {
                        ctx.Film.Add(new Film
                        {
                            Title = tytulFilmu,
                            ProductionYear = Convert.ToDateTime(dataFilmu),
                            Prizes = nagrodyFilmu,
                            CategoryID = kategoria.ID,
                            ActorID = aktor.ID,
                            DirectorID = rezyser.ID,
                        });

                        ctx.SaveChanges();
                        MessageBox.Show("Dodano nowy film do bazy");
                    }

                }
            }
        }

        private void przyciskFilmy_Click(object sender, RoutedEventArgs e)
        {
            filmyWindow oknoFilmy = new filmyWindow();
            oknoFilmy.Show();
        }

        private void przyciskWyjscie_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
