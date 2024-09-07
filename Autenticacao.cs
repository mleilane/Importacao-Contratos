
// definindo a classe para armazenar a credencial de acesso 
public class User
{
    public string Username { get; set; }
    public string Password { get; set; } 
}


public class AutenticacaoServico
{
    //  credenciais de usuário e senha 
    private readonly User _validUser = new User { Username = "admin", Password = "123" };

    public bool Authenticate(string username, string password)
    {
        return username == _validUser.Username && password == _validUser.Password;
    }
}