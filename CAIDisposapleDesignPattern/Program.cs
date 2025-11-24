namespace CAIDisposapleDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1)not recommended
            
            //CurrencyService currencyServicedService = new CurrencyService();
            //var result = currencyServicedService.GerCurrencies();
            //currencyServicedService.Dispose();
            //Console.WriteLine(result);

            // 2) Recommended
            
            //CurrencyService currencyServicedService = null;
            //try
            //{
            //    currencyServicedService = new CurrencyService();
            //    var result = currencyServicedService.GerCurrencies();
            //    Console.WriteLine(result);
            //}
            //catch
            //{
            //    Console.WriteLine("Error");
            //}
            //finally
            //{
            //    currencyServicedService?.Dispose();
            //}

            //// 3) more recommmended using .net framework 2+
            
             // using CurrencyService currencyServicedService = new CurrencyService();
             // var result = currencyServicedService.GerCurrencies();
             // Console.WriteLine(result);
           
            // 4) using without blocks C# 8.0
            
           using (CurrencyService currencyServicedService = new CurrencyService()) 
            {
               var result = currencyServicedService.GerCurrencies();
               Console.WriteLine(result);
            }

            Console.ReadKey();
        }
        
        class CurrencyService : IDisposable
        {
            private readonly HttpClient _httpClient;
            private bool _disposed = false;
            public CurrencyService()
            {
                _httpClient = new HttpClient();
            }

            ~CurrencyService()
            {
                Dispose(false);
            }
            //disposing : true (dispose manged + unmanaged)
            //disposing : true (dispos unmanaged + large fields)
            protected virtual void Dispose(bool disposing)
            {
                if (_disposed)
                    return;
                if (disposing)
                {
                    _httpClient.Dispose();
                }
            }
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            public string GerCurrencies()
            {
                string url = "https://coinbase.com/api/v2/currencies";
                var result = _httpClient.GetStringAsync(url).Result;
                return result;
            }
        }
    }
}
