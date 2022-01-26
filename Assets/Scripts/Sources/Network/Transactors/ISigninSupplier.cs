namespace MatoApp.Eleven.Network
{
    public interface ISigninSupplier
    {
        string Username { set; }

        void Signin();
    }
}