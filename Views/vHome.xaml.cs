namespace eguamanTareaS2.Views;

public partial class vHome : ContentPage
{
	public vHome()
	{
		InitializeComponent();
	}
    private async void OnCalcularClicked(object sender, EventArgs e)
    {
        if (pickerEstudiantes.SelectedIndex == -1 ||
            !double.TryParse(entrySeg1.Text, out double seg1) ||
            !double.TryParse(entryEx1.Text, out double ex1) ||
            !double.TryParse(entrySeg2.Text, out double seg2) ||
            !double.TryParse(entryEx2.Text, out double ex2))
        {
            await DisplayAlert("Error", "Complete correctamente los campos ", "OK");
            return;
        }

         if (seg1 > 10 || seg2 > 10 || ex1 > 10 || ex2 > 10 || seg1 < 0 || seg2 < 0 || ex1 < 0 || ex2 < 0)
        {
            await DisplayAlert("Error", "Las notas deben estar entre 0 y 10.", "OK");
            return;
        }

        double parcial1 = (seg1 * 0.3) + (ex1 * 0.2);
        double parcial2 = (seg2 * 0.3) + (ex2 * 0.2);
        double notaFinal = parcial1 + parcial2;

        string estado = notaFinal >= 7 ? "APROBADO"
                       : notaFinal >= 5 ? "COMPLEMENTARIO"
                       : "REPROBADO";

        string mensaje = $"*********************************************\n\n" +
                         $"Nombre:          {pickerEstudiantes.SelectedItem}\n" +
                         $"Fecha:             {datePicker.Date:d}\n" +
                         $"Nota Parcial 1:  {parcial1:F2}\n" +
                         $"Nota Parcial 2:  {parcial2:F2}\n" +
                         $"Nota Final:      {notaFinal:F2}\n" +
                         $"Estado:          {estado}" +
                         $"\n*********************************************";

        await DisplayAlert("Resultado", mensaje, "OK");
    }
}