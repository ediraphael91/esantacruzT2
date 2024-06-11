using static System.Runtime.InteropServices.JavaScript.JSType;

namespace esantacruzT2.Views;

public partial class sistemaCalificaciones : ContentPage
{
    public sistemaCalificaciones()
    {
        InitializeComponent();
    }

    private void btnCalcular_Clicked(object sender, EventArgs e)
    {
        if (pkeEstudiantes.SelectedIndex < 0)
            DisplayAlert("ERROR:", "SELECCIONE UN ESTUDIANTE", "OK");
        else
        {

            double seg1Temp = Convert.ToDouble(txtSeguimiento1.Text);
            double seg1 = seg1Temp * 0.030;
            double examTemp = Convert.ToDouble(txtExamen1.Text);
            double exam1 = examTemp * 0.020;
            double parcial1 = seg1 + exam1;

            double seg2Temp = Convert.ToDouble(txtSeguimiento2.Text);
            double seg2 = seg2Temp * 0.030;
            double examTemp2 = Convert.ToDouble(txtExamen2.Text);
            double exam2 = examTemp2 * 0.020;
            double parcial2 = seg2 + exam2;

            double notaf = parcial1 + parcial2;

            string nombre = pkeEstudiantes.Items[pkeEstudiantes.SelectedIndex].ToString();
            string fecha = dpFecha.Date.ToString();

            string estado = ObtenerEstado(notaf);

            DisplayAlert("RESULTADO:",
                "ESTUDIANTE : " + nombre + "\n" +
                "FECHA: " + fecha + "\n" +
                "NOTA PARCIAL 1 : " + parcial1 + "\n" +
                "NOTA PARCIAL 2 : " + parcial2 + "\n" +
                "NOTA FINAL : " + notaf + "\n" +
                "ESTADO: " + estado,
                "SALIR");

        }
    }

    public string ObtenerEstado(double nota)
    {
        if (nota <= 4.9)
        {
            return "REPROBADO";
        }
        else if (nota >= 5 && nota <= 6.9)
        {
            return "COMPLEMENTARIO";
        }
        else
        {
            return "APROBADO";
        }
       
        
    }

    private void btnLimpiar_Clicked(object sender, EventArgs e)
    {
        txtSeguimiento1.Text = string.Empty;
        txtExamen1.Text = string.Empty;
        txtSeguimiento2.Text = string.Empty;
        txtExamen2.Text = string.Empty;
        pkeEstudiantes.SelectedIndex = -1;
        dpFecha.Date = DateTime.Now;
    }
}
