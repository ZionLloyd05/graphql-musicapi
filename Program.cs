using musicapi.Data;
using Microsoft.EntityFrameworkCore;
using musicapi.GraphQL;
using GraphQL.Server.Ui.Voyager;
using musicapi.Models.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<MusicDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MusicAppConnString")));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddProjections();

var app = builder.Build();

app.MapGraphQL();
app.UseGraphQLVoyager("/graphql-voyager", new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql"
});

app.Run();