using proiect.proiectClasses;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace proiect
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

   

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        ContactClass c = new ContactClass();


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

       }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
           //get values from INPUT fields
            c.Cod_Tipologie = cmbCategorie.Text;
            c.Nume = txtNume.Text;
            c.Prenume = txtPrenume.Text;
            c.Tel = txtTel.Text;
            c.Email = txtEmail.Text;

            //insert data into database
            bool success  = c.Insert(c);
            if (success == true)
            {
                //succesfully inserted
                MessageBox.Show("Ati introdus cu succes un abonat nou!");
            }
            else
            {
                //failed insertion
                MessageBox.Show("Nu ati reusit sa adaugati un nou abonat! Incercati din nou.");
                //metoda clear apelata aici
                Clear();
            }


            //Load Data on Data gridview
            DataTable dt = c.Select();
            tbtSearch.DataContext = dt;
            
   
        }

        private void tbtSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Load Data on Data gridview
            DataTable dt = c.Select();
            tbtSearch.DataContext = dt;
        }

        //Method to CLEAR fields
        public void Clear()
        {
            cmbCategorie.Text = "";
            txtNume.Text = "";
            txtPrenume.Text = "";
            txtTel.Text = "";
            txtEmail.Text = "";

        }

        //Method to UPDATE data
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //get data from textboxes
            c.IdAbonat = int.Parse(txtIdAbonat.Text);
            c.Cod_Tipologie = cmbCategorie.Text;
            c.Nume = txtNume.Text;
            c.Prenume = txtPrenume.Text;
            c.Tel = txtTel.Text;
            c.Email = txtEmail.Text;

            //UPDATE data  in db
            bool success = c.Update(c);
            if (success == true)
            {
                //succesful update
                MessageBox.Show("Actualizare reusita!");
                DataTable dt = c.Select();

            }
            else
            {
                //failed update
                MessageBox.Show("Actualizare esuata");
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Clear();

        }

    }
}
