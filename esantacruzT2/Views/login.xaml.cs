
namespace esantacruzT2.Views;
public partial class login : ContentPage
{

    private readonly string[] user = { "Carlos", "Ana", "Jose" };
    private readonly string[] passw = { "carlos123", "ana123", "jose123" };
    public login()
    {
        InitializeComponent();
    }

       private void OnLoginButtonClicked(object sender, EventArgs e)
    {
        string username = txtUsuario.Text;
        string password = txtContraseña.Text;
        string result = Login(username, password);
        resultLabel.Text = result;

        if (result == "Login exitoso")
        {
            Navigation.PushAsync(new sistemaCalificaciones(username));
        }
    }

    private string Login(string username, string password)
    {
        if (user.Contains(username))
        {
            int index = Array.IndexOf(user, username);
            if (passw[index] == password)
            {
                return "Login exitoso";
            }
            else
            {
                return "Contraseña incorrecta";
            }
        }
        else
        {
            return "Usuario no encontrado";
        }
    }
}
