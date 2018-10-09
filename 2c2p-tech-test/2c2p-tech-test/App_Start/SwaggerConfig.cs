using System.Web.Http;
using WebActivatorEx;
using _2c2p_tech_test;
using Swashbuckle.Application;
using System.Configuration;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace _2c2p_tech_test
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["BaseURl"]))
                        {
                            c.RootUrl(req => GetRootUrlFromAppConfig());
                        }
                        c.SingleApiVersion("v1", "_2c2p_tech_test");

                        c.IncludeXmlComments(GetXmlCommentsPath());

                    })
                .EnableSwaggerUi(c =>
                    {
                      
                    });
        }
        private static string GetRootUrlFromAppConfig()
        {
            var baseUrl = ConfigurationManager.AppSettings["BaseUrl"];
            if (baseUrl.IndexOf("//") == 0)
            {
                baseUrl = "http:" + baseUrl;
            }
            return baseUrl; 
        }

        protected static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\2c2p-tech-test.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
