using Newtonsoft.Json;
using SampleEcommerce.Moblie.Abstractions;
using SampleEcommerce.Moblie.Data;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;

namespace SampleEcommerce.Moblie.Helper
{
    public class AppSettings : IAppSettings
    {
        public Customer Customer
        {
            get => GetValue<Customer>();
            set => SetValue(value);
        }


        private T GetValue<T>([CallerMemberName] string key = "")
        {
            var json = Preferences.Get(key, string.Empty);
            return JsonConvert.DeserializeObject<T>(json);
        }

        private void SetValue(object source, [CallerMemberName] string key = "")
        {
            var json = JsonConvert.SerializeObject(source);
            Preferences.Set(key, json);
        }
    }
}
