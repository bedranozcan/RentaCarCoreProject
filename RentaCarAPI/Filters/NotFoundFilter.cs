﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RentaCar.Core.Dtos;
using RentaCar.Core.Services;

namespace RentaCar.API.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : class
    {
        private readonly IService<T> _service;
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            var idValue=context.ActionArguments.Values.FirstOrDefault();
            if (idValue == null)
            {
               await next.Invoke();
                return;
            }

            var id = (int)idValue;

            var anyEntity = await _service.GetByIdAsync(id);

            if (anyEntity != null)
            {
                await next.Invoke();
                return;
            }
            context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(404, $"{typeof(T).Name}({id}) not found"));

        }
    }
}
