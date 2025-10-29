using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace CustomeApp {
    public partial class MainWindow : Window {
        public ObservableCollection<Person> People { get; set; }
        private string selectedImagePath;

        public MainWindow() {
            InitializeComponent();
            People = new ObservableCollection<Person>();
            PersonListView.ItemsSource = People;
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog {
                Filter = "画像ファイル (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp"
            };

            if (openFileDialog.ShowDialog() == true) {
                selectedImagePath = openFileDialog.FileName;
                PreviewImage.Source = new BitmapImage(new Uri(selectedImagePath));
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text)) return;

            People.Add(new Person {
                Id = People.Count + 1,
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Address = AddressTextBox.Text,
                ImagePath = selectedImagePath
            });

            ClearInputs();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            if (PersonListView.SelectedItem is Person selected) {
                People.Remove(selected);
                PreviewImage.Source = null;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e) {
            if (PersonListView.SelectedItem is Person selected) {
                selected.Name = NameTextBox.Text;
                selected.Phone = PhoneTextBox.Text;
                selected.Address = AddressTextBox.Text;
                selected.ImagePath = selectedImagePath;

                PersonListView.Items.Refresh();
            }
        }

        private void SearchTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) {
            string keyword = SearchTextBox.Text.ToLower();
            PersonListView.ItemsSource = string.IsNullOrEmpty(keyword)
                ? People
                : new ObservableCollection<Person>(
                    People.Where(p => p.Name.ToLower().Contains(keyword) || p.Phone.Contains(keyword)));
        }

        private void PersonListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
            if (PersonListView.SelectedItem is Person selected) {
                NameTextBox.Text = selected.Name;
                PhoneTextBox.Text = selected.Phone;
                AddressTextBox.Text = selected.Address;
                selectedImagePath = selected.ImagePath;

                if (File.Exists(selected.ImagePath))
                    PreviewImage.Source = new BitmapImage(new Uri(selected.ImagePath));
                else
                    PreviewImage.Source = null;
            }
        }

        private void ClearInputs() {
            NameTextBox.Clear();
            PhoneTextBox.Clear();
            AddressTextBox.Clear();
            selectedImagePath = null;
            PreviewImage.Source = null;
        }
    }

    public class Person {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
    }
}