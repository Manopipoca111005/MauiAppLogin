namespace MauiAppLogin;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
    }

    async private void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            List<DadosUsuario> lista_usuarios = new List<DadosUsuario>
            {
                new DadosUsuario
                {
                    Usuario = "user1",
                    Senha = "pass1"
                },
                new DadosUsuario
                {
                    Usuario = "user2",
                    Senha = "pass2"
                }
            };

            DadosUsuario dados_digitados = new DadosUsuario()
            {
                Usuario = txtUsuario.Text,
                Senha = txtSenha.Text
            };

            if (lista_usuarios.Any(
                i => dados_digitados.Usuario == i.Usuario &&
                dados_digitados.Senha == i.Senha))
            {
                await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.Usuario);
                App.Current.MainPage = new Protegida();
            }
            else
            {
                throw new Exception("Usuário ou senha inválidos");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Fechar");
        }
    }
}
