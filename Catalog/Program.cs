using Catalog.Repositories;

using MongoDB.Driver;

using MongoDB.Bson.Serialization;

using MongoDB.Bson.Serialization.Serializers;

using MongoDB.Bson;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));

BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));


builder.Services.Configure<MongoDatabaseSettings>(builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<IInMemItemsRepository, InMemItemsRepository>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
