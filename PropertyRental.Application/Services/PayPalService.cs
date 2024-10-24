using Microsoft.Extensions.Configuration;
using PayPal.Api;
using Payment = PayPal.Api.Payment;

public class PayPalService
{
    private readonly string _clientId;
    private readonly string _clientSecret;
    private readonly string _mode;

    public PayPalService(IConfiguration configuration)
    {
        _clientId = configuration["PayPal:ClientId"];
        _clientSecret = configuration["PayPal:ClientSecret"];
        _mode = configuration["PayPal:Mode"];
    }

    public APIContext GetAPIContext()
    {
        var config = new Dictionary<string, string> { { "mode", _mode } };
        var accessToken = new OAuthTokenCredential(_clientId, _clientSecret, config).GetAccessToken();
        return new APIContext(accessToken) { Config = config };
    }

    public Payment CreatePayment(decimal amount, string currency, string returnUrl, string cancelUrl)
    {
        var apiContext = GetAPIContext();

        var payment = new Payment
        {
            intent = "sale",
            payer = new Payer { payment_method = "paypal" },
            transactions = new List<Transaction>
            {
                new Transaction
                {
                    amount = new Amount { total = amount.ToString(), currency = currency },
                    description = "Rental Payment"
                }
            },
            redirect_urls = new RedirectUrls
            {
                return_url = returnUrl,
                cancel_url = cancelUrl
            }
        };

        return payment.Create(apiContext);
    }
   
    public Payment ExecutePayment(string paymentId, string payerId)
    {
        var apiContext = GetAPIContext();
        var paymentExecution = new PaymentExecution { payer_id = payerId };
        var payment = new Payment { id = paymentId };
        return payment.Execute(apiContext, paymentExecution);
    }
}
