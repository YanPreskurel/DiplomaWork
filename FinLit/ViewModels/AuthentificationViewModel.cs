namespace FinLit.ViewModels
{
    public class AuthentificationViewModel
    {
        public LoginViewModel Login { get; set; } = new();
        public RegisterViewModel Register { get; set; } = new();
    }
}
