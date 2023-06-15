using SimpleMvvm.Messaging;
namespace SimpleMvvm
{
    public static class StandardMauiBootstrapper
    {
        public static void AddSimpleMvvm(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<IMessenger, Messenger>();
        }
    }
}
