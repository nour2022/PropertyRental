using PayPal.Api;
using PropertyRental.Application.DTOs;
using PropertyRental.Infrastructure.Data;

namespace PropertyRental.Application.Services
{
    public class PaymentService
    {
        private PayPalService _paypalService;
        private AppDbContext _appDbContext;

      
        public PaymentService(PayPalService paypalService,AppDbContext appDbContext)
        {
            _paypalService = paypalService;
            _appDbContext = appDbContext;
        }
        //public void AddPayment(string paymentId, string TenantId)
        //{
        //    var payment = new PaymentDTO
        //    {
        //        Id = paymentId,
        //        PaymentDate
        //    }

        //}
        public  Payment ExecutePaymentAsync(string paymentId, string payerId)
{
    var apiContext =_paypalService.GetAPIContext();
    var paymentExecution = new PaymentExecution { payer_id = payerId };
    var payment = new Payment { id = paymentId };
    
    
    return  payment.Execute(apiContext, paymentExecution);
}

    }
}
