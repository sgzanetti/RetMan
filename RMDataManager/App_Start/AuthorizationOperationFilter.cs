using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace RMDataManager.App_Start
{
    public class AuthorizationOperationFilter : IOperationFilter
    {
        /// <summary>
        /// Esto agrega un parámetro a cada operación
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="schemaRegistry"></param>
        /// <param name="apiDescription"></param>
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            //Ojo que no es lo mismo que no tenga parámetros a que los parámetros sean null
            if (operation.parameters == null)
            {
                operation.parameters = new List<Parameter>();
            }
            operation.parameters.Add(new Parameter
            {
                name = "Authorization",
                @in = "header",
                description = "access token",
                required = false,
                type="string"
            });
        }
    }
}