using AmazonReviewGenerator.Data;
using AmazonReviewGenerator.Services;

var builder = WebApplication.CreateBuilder(args);

// Dependency Injection
builder.Services.AddSingleton<MarkovChain>();
builder.Services.AddSingleton<ReviewService>();

// Load and train data
var markovChain = new MarkovChain();
var filePath = Path.Combine(AppContext.BaseDirectory, "Data", "amazon_reviews.json");

ReviewDataLoader.LoadAndTrain(filePath, markovChain);

builder.Services.AddSingleton(markovChain);

builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    // Default route to ReviewController's "generate" action
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "",
        defaults: new { controller = "Review", action = "GenerateReview" }
    );

    endpoints.MapControllers();
});

app.Run();
