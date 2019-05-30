using GoT;
using GoT.GoTTypes.Castles;
using GoT.GoTTypes.Character;
using GoT.GoTTypes.Houses;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace dotnet
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();
            //var foo = new GoTData();
            //services.AddSingleton<StarWarsData>();
            services.AddSingleton<GoTData>();
            services.AddSingleton<GotQuery>();
            services.AddSingleton<GotMutation>();
            services.AddSingleton<CharacterInputType>();
            //services.AddSingleton<StarWarsMutation>();
            services.AddSingleton<CharacterType>();
            services.AddSingleton<HouseType>();
            services.AddSingleton<CastleType>();
            services.AddSingleton<ISchema, GoTSchema>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();

            app.UseMiddleware<GraphQLMiddleware>(new GraphQLSettings
            {
                BuildUserContext = ctx => new GraphQLUserContext
                {
                    User = ctx.User
                }
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}
