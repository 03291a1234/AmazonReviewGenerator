using AmazonReviewGenerator.Models;
using Newtonsoft.Json;

namespace AmazonReviewGenerator.Services
{
    public class ReviewService
    {
        private readonly MarkovChain _markovChain;

        public ReviewService()
        {
            _markovChain = new MarkovChain();
            LoadAndTrainAsync().Wait();  
        }

        private async Task LoadAndTrainAsync()
        {
            var dataPath = Path.Combine(AppContext.BaseDirectory, "Data", "amazon_reviews.json");

            if (!File.Exists(dataPath))
                throw new FileNotFoundException("Training data file not found", dataPath);

            try
            {
               
                var json = await File.ReadAllTextAsync(dataPath);
                var cleanedJson = JsonCleaner.CleanJson(json);
                var reviews = JsonConvert.DeserializeObject<List<Review>>(json);

                if (reviews == null || reviews.Count == 0)
                    throw new InvalidOperationException("No reviews found in the training data.");

                var reviewTexts = new List<string>();
                foreach (var review in reviews)
                {
                    reviewTexts.Add(review.ReviewText);
                }

                _markovChain.Train(reviewTexts);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error deserializing the JSON data.", ex);
            }
        }

        public string GenerateReviewContent()
        {
            if (!_markovChain.IsTrained)
                throw new InvalidOperationException("The Markov chain has not been trained.");

            return _markovChain.Generate();
        }

        public int GenerateStarRating()
        {            
            return new Random().Next(1, 6);
        }
    }
}
