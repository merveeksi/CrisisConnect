using System.Text.Json;
using Core.Application.Common;
using Core.CrossCuttingConcerns.Exceptions.Handlers;
using Core.CrossCuttingConcerns.Localizations;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Serilog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Core.CrossCuttingConcerns;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly HttpExceptionHandler _httpExceptionHandler;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly LoggerServiceBase _loggerService;
    private readonly IStringLocalizer<CommonLocalization> _localizer;


    public ExceptionMiddleware(RequestDelegate next, HttpExceptionHandler httpExceptionHandler, IHttpContextAccessor contextAccessor, LoggerServiceBase loggerService, IStringLocalizer<CommonLocalization> localizer)
    {
        _next = next;
        _httpExceptionHandler = httpExceptionHandler;
        _contextAccessor = contextAccessor;
        _loggerService = loggerService;
        _localizer = localizer;
    }

    public async Task Invoke(HttpContext context) 
    {
        try
        {
            var responseMessage = _localizer[CommonLocalizationKeys.GeneralValidationException];
            await _next(context);
        }
        catch (Exception exception)
        {
            var responseMessage = _localizer[CommonLocalizationKeys.GeneralInternalServerException];
            await LogException(context,exception);
            await HandleExceptionAsync(context.Response, exception);
        }
    
    }

    private Task LogException(HttpContext context, Exception exception)
    {
        List<LogParameter> logParameters = new()
        {
            new LogParameter{Type=context.GetType().Name, Value=exception.ToString()}
        };
    
        LogDetailWithException logDetail = new()
        {
            ExceptionMessage = exception.Message,
            MethodName = _next.Method.Name,
            Parameters = logParameters,
            User = _contextAccessor.HttpContext?.User.Identity?.Name??"?"
        };
    
        _loggerService.Error(JsonSerializer.Serialize(logDetail));
    
        return Task.CompletedTask;
    }

    private Task HandleExceptionAsync(HttpResponse response, Exception exception)
    {
        response.ContentType = "application/json";
        _httpExceptionHandler.Response = response;
        return _httpExceptionHandler.HandleExceptionAsync(exception);
    }
}
