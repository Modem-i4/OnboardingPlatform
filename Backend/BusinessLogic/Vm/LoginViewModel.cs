
namespace BusinessLogic.Vm
{
    public class LoginViewModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public int UserId { get; set; }

        public bool IsEmailConfirmed { get; set; }
    }
}
