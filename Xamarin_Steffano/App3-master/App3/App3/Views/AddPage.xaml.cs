using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App3.Models;
using App3.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
        }
        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var item = new CV
                {
                    Name = Nombre.Text,
                    Ocupacion = Ocupacion.Text,
                    Contacto = Contacto.Text,
                    Correo = Correo.Text,
                    Idiomas = Idiomas.Text,
                    Aptitudes = Aptitudes.Text,
                    Habilidades = Habilidades.Text,
                    Experiencia = Experiencia.Text,
                    //Formacion = Formacion.Text

                };
                var result = await App.Context.InsertItemASync(item);
                if (result == 1)
                {
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "No se puedo guardar", "Aceptar");
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }
    }
}