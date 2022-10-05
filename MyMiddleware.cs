using Microsoft.AspNetCore.Http;

public class MyMiddleware{
    private readonly RequestDelegate __next;

    public MyMiddleware(RequestDelegate next){
        __next = next;
    }

    public async Task InvokeAsync(HttpContext context){
        Console.WriteLine("\n\r --- antes --- \n\r");
        await __next(context);
        Console.WriteLine("\n\r --- depois --- \n\r");
    }
}

public static class MyMiddlewareExtension{
    public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder Builder){
        return Builder.UseMiddleware<MyMiddleware>();
    }
}