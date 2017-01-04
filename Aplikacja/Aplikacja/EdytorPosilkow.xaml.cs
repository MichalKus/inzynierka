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
    /// Interaction logic for EdytorDnia.xaml
    /// </summary>
    public partial class EdytorPosilkow : Window
    {

        BazaDanychEntities db = new BazaDanychEntities();
        int id = Sesja.ZwrocId();
        Uzytkownicy uzytkownik = new Uzytkownicy();
        Diety dieta = new Diety();
        DateTime wybranaData = new DateTime();
        int ilosc_wybranych = 0;
        bool walidacja = true;

        public EdytorPosilkow()
        {
            InitializeComponent();
        }

        public void przekazDane(DateTime data)
        {
            wybranaData = data;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource posilekViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("posilekViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // posilekViewSource.Source = [generic data source]
            posilekViewSource.Source = db.Posilki.ToList();
            uzytkownik = db.Uzytkownicy.Where(m => m.ID.Equals(id)).FirstOrDefault();
            znajdzDiete();

            kalorieLabel.Content = dieta.Zapotrzebowanie;
            bialkoLabel.Content = ((int)dieta.Bialko).ToString();
            weglowodanyLabel.Content = ((int)dieta.Weglowodany).ToString();
            tluszczeLabel.Content = ((int)dieta.Tluszcz).ToString();
            posilkiLabel.Content = dieta.Ilosc_Posilkow.ToString();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs  e)
        {
            ilosc_wybranych = 0;
            int kalorie = (int)dieta.Zapotrzebowanie;
            int bialko = (int)dieta.Bialko;
            int weglowodany = (int) dieta.Weglowodany;
            int tluszcz = (int)dieta.Tluszcz;
            foreach (Posilki posilek in potrawyBox.SelectedItems)
            {
                kalorie = kalorie - (int)posilek.Kalorycznosc;
                bialko = bialko - (int)posilek.Bialko;
                weglowodany = weglowodany - (int)posilek.Weglowodany;
                tluszcz = tluszcz - (int)posilek.Tluszcz;
                ilosc_wybranych++;
            }

            if (kalorie < 0 || bialko < 0 || weglowodany < 0 || tluszcz < 0)
                walidacja = false;
            else
                walidacja = true;

            kalorieLabel.Content = kalorie.ToString();
            bialkoLabel.Content = bialko.ToString();
            weglowodanyLabel.Content = weglowodany.ToString();
            tluszczeLabel.Content = tluszcz.ToString();

            if (ilosc_wybranych <= dieta.Ilosc_Posilkow)
                posilkiLabel.Content = (dieta.Ilosc_Posilkow - ilosc_wybranych).ToString();
        }

        private void zapiszButton_Click(object sender, RoutedEventArgs e)
        {
            if (walidacja == false)
            {
                string msg = "Przekroczyłeś dopuszczalne progi swojej diety. Zmień posiłki, tak aby wszystkie wartości były większe od zera.";
                MessageBox.Show(msg, "Uwaga", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if(potrawyBox.SelectedItems.Count == 0)
            {
                string msg = "Nie wybrano żadnych posiłków.";
                MessageBox.Show(msg, "Uwaga", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if(ilosc_wybranych > dieta.Ilosc_Posilkow)
            {
                string msg = "Przekroczyłeś dopuszczalną ilość posiłków. Wybierz ich mniejszą ilość.";
                MessageBox.Show(msg, "Uwaga", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
               /* db.Spis_Posilkow.RemoveRange(db.Spis_Posilkow.Where(m => m.Data == wybranaData));

                foreach (Posilek posilek in potrawyBox.SelectedItems)
                {
                    spis.Data = wybranaData;
                    spis.ID_Diety = dieta.Id;
                    spis.ID_Posilku = posilek.Id;
                    db.Spis_Posilkow.Add(spis);
                    db.SaveChanges();
                }*/
                string msg = "Posiłki zostały poprawnie zapisane.";
                MessageBox.Show(msg, "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void znajdzDiete()
        {
            var diety = uzytkownik.Diety.ToList();
            foreach (Diety szukana in diety)
            {
                if (szukana.Data_Rozpoczecia <= wybranaData && szukana.Data_Zakonczenia >= wybranaData)
                {
                    dieta = szukana;
                }
            }

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            PlanDnia plan = new PlanDnia();
            plan.przekazDane(wybranaData);
            plan.Show();
        }

    }
}
