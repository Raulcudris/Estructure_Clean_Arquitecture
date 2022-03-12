using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using ProyectoEstructura.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace ProyectoEstructura.WebExceptionsPresenter
{
    public class ValidationExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handle(ExceptionContext context)
        {
            var Exception = context.Exception as ValidationException;
            StringBuilder Builder = new StringBuilder();
            foreach (var Failure in Exception.Errors)
            {
                Builder.AppendLine(
                    String.Format("Propiedad: {0}. Error: {1}",
                    Failure.PropertyName, Failure.ErrorMessage));
            }

            return SetResult(context, StatusCodes.Status400BadRequest,
                "Error en los datos de entrada.",Builder.ToString());

        }
    }
}

