using MySql.Data.MySqlClient;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Data.Entity;
using System.Text;

namespace WebApplication5
{

    public class FormattersController : ApiController
    {
        public IEnumerable<string> Get()
        {
            IList<string> formatters = new List<string>();

            foreach (var item in GlobalConfiguration.Configuration.Formatters)
            {
                formatters.Add(item.ToString());
            }

            return formatters.AsEnumerable<string>();
        }
    }
    public class Global : System.Web.HttpApplication
    {
        public static void Register(HttpConfiguration configuration)
        {


            configuration.Routes.MapHttpRoute("API Default", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
            // Web API routes
            configuration.MapHttpAttributeRoutes();

            configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}",
                defaults: new { id = RouteParameter.Optional }
               );


            
            JsonMediaTypeFormatter jsonFormatter = configuration.Formatters.JsonFormatter;

            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            configuration.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));

            configuration.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));

            configuration.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/octet-stream"));






            configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;


           // configuration.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            
        }
        public static async Task<string> HttpClient(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                client.DefaultRequestHeaders
                      .Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json")); // ACCEPT header


                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "");
                request.Content = new StringContent("{\"id\" : 1}",
                                    Encoding.UTF8,
                                    "application/json"); // REQUEST header


                HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
        }

        public static MySqlConnection conn()
        {
            string conn_string = "server =localhost; Uid=root; password = ; persistsecurityinfo = True; database =zavod; SslMode = none";


            MySqlConnection conn = new MySqlConnection(conn_string);

            return conn;
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
        protected void Application_Start()
        {
            
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            Register(GlobalConfiguration.Configuration);
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            GlobalConfiguration.Configuration.EnsureInitialized();
            //GlobalConfiguration.Configure(Register);
            //RegisterRoutes(RouteTable.Routes);



        }


        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            try
            {
                //ловим последнее возникшее исключение
                Exception lastError = Server.GetLastError();

                if (lastError != null)
                {
                    //Записываем непосредственно исключение, вызвавшее данное, в
                    //Session для дальнейшего использования
                    Session["ErrorException"] = lastError.InnerException;
                }

                // Обнуление ошибки на сервере
                Server.ClearError();

                // Перенаправление на свою страницу отображения ошибки
                Response.Redirect("404.html");
            }
            catch (Exception)
            {
                // если мы всёже приходим сюда - значит обработка исключения 
                // сама сгенерировала исключение, мы ничего не делаем, чтобы
                // не создать бесконечный цикл
                Response.Write("К сожалению произошла критическая ошибка. Нажмите кнопку 'Назад' в браузере и попробуйте ещё раз. ");
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }


    }
}