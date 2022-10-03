namespace Web.Middlewares
{
    public class TransferBasketMiddleWare
    {
        private readonly RequestDelegate _next;

        public TransferBasketMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IBasketViewModelService basketViewModelService )
        {
            await basketViewModelService.TransferBasketAsync();
            await _next(context);
        }
    }

    public static class TransferBasketMiddleWareExtensions
    {
        public static IApplicationBuilder UseTransferBasket(this IApplicationBuilder app)
        {
            return app.UseMiddleware<TransferBasketMiddleWare>();
        }
    }
}
