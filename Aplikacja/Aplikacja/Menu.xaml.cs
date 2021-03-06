﻿using System;
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
using System.Windows.Shapes;

namespace Aplikacja
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {

        BazaDanychEntities db = new BazaDanychEntities();
        int id = Sesja.ZwrocId();
        Uzytkownicy uzytkownik = new Uzytkownicy();
        Diety dieta = new Diety();
        Treningi trening = new Treningi();
        DateTime data = new DateTime();

        public Menu()
        {
            InitializeComponent();
            uzytkownik = db.Uzytkownicy.Where(m => m.ID.Equals(id)).FirstOrDefault();
        }

       

        private void wylogujButton_Click(object sender, RoutedEventArgs e)
        {
            Intro intro = new Intro();
            intro.Show();
            this.Close();
        }

        private void zakonczButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult wynik = MessageBox.Show("Czy na pewno chcesz zakończyć działanie programu?", "Appka", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (wynik == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void oprogramieButton_Click(object sender, RoutedEventArgs e)
        {
            Informacje informacje = new Informacje();
            informacje.Show();
        }

        private void oautorachButton_Click(object sender, RoutedEventArgs e)
        {
            Autorzy okno = new Autorzy();
            okno.Show();
        }

        private void kalkulatoryButton_Click(object sender, RoutedEventArgs e)
        {
            Kalkulatory okno = new Kalkulatory();
            okno.Show();
        }

        private void dietaButton_Click(object sender, RoutedEventArgs e)
        {
            Dieta okno = new Dieta();
            okno.Show();
        }

        private void suplementacjaButton_Click(object sender, RoutedEventArgs e)
        {
            Suplementacja okno = new Suplementacja();
            okno.Show();
        }

        private void profilButton_Click(object sender, RoutedEventArgs e)
        {
            Profil okno = new Profil();
            okno.Show();
        }

        private void treningButton_Click(object sender, RoutedEventArgs e)
        {
            Trening okno = new Trening();
            okno.Show();
        }

        private void statystykiButton_Click(object sender, RoutedEventArgs e)
        {
            Statystyki okno = new Statystyki();
            okno.Show();
        }

        private void produktySpozywczeButton_Click(object sender, RoutedEventArgs e)
        {
            TabelaProduktow okno = new TabelaProduktow();
            okno.Show();
        }

        private void dziennikButton_Click(object sender, RoutedEventArgs e)
        {
            Dziennik okno = new Dziennik();
            okno.Show();
        }

        private void planDniaButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime now = DateTime.Now;
            TimeSpan time = new TimeSpan(0,0,0);
            now = now.Date + time;
            data = now;

            dieta = null;
            trening = null;
            znajdzDiete();
            znajdzTrening();

            if (dieta == null && trening == null)
            {
                string msg = "Brak diety lub treningu na dany dzień, przejdź do odpowiednich modułów, aby ustalić plan na diete lub trening.";
                MessageBox.Show(msg, "Uwaga", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                PlanDnia okno = new PlanDnia();
                okno.przekazDane(data);
                okno.Show();
            }
        }


        private void znajdzDiete()
        {
            var diety = uzytkownik.Diety.ToList();
            foreach (Diety szukana in diety)
            {
                if (szukana.Data_Rozpoczecia <= data && szukana.Data_Zakonczenia >= data)
                {
                    dieta = szukana;
                }
            }
        }

        private void znajdzTrening()
        {
            var treningi = uzytkownik.Treningi.ToList();
            foreach (Treningi szukany in treningi)
            {
                if (szukany.Data_Rozpoczecia <= data && szukany.Data_Zakonczenia >= data)
                {
                    trening = szukany;
                }
            }
        }

   
    }
}
