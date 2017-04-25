using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using BookStoreT3.DataAccess.DbInitializer;
using System.Net.Http.Headers;
using LightInject;
using BookStoreT3.DataAccess.Entities;
using BookStoreT3.Operations.Abstraction;
using BookStoreT3.Operations.Implementations;

namespace BookStoreT3
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            Database.SetInitializer(new BookStoreT3DbInitializer());
            // Конфигурация и службы веб-API

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = new ServiceContainer();

            container.Register<BookStoreT3ModelContainer, BookStoreT3ModelContainer>();
            container.Register<IBooksOperaton, BookOperations>(new PerRequestLifeTime());

            container.EnableWebApi(config);




        }
    }
}
