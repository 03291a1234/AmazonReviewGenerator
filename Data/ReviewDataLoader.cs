using AmazonReviewGenerator.Models;
using AmazonReviewGenerator.Services;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace AmazonReviewGenerator.Data
{
    public class ReviewDataLoader
    {
        // Load and train the MarkovChain with review data
        public static List<Review> LoadAndTrain(string filePath, MarkovChain markovChain)
        {
            // Read the JSON file containing the reviews
            var json = File.ReadAllText(filePath);

            // Deserialize JSON into a list of reviews
            var reviews = JsonConvert.DeserializeObject<List<Review>>(json);

            // Check if reviews are loaded correctly
            if (reviews == null || reviews.Count == 0)
                throw new InvalidOperationException("No reviews found in the training data.");

            // Train the MarkovChain with review content
            foreach (var review in reviews)
            {
                // Ensure the review has text content and train the MarkovChain with it
                if (!string.IsNullOrEmpty(review.ReviewText))
                {
                    // Train Markov Chain with the content of each review
                    markovChain.Train(new List<string> { review.ReviewText });
                }
            }

            // Return the list of reviews
            return reviews;
        }
    }
}
