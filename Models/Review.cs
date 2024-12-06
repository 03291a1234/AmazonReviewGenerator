using Newtonsoft.Json;

namespace AmazonReviewGenerator.Models;
// Review model to deserialize the JSON structure
public class Review
{
    public string ReviewerName { get; set; }
    public string ReviewText { get; set; }
    public double Overall { get; set; }
    public bool Verified { get; set; }
    public string ReviewTime { get; set; }
    public string ReviewerID { get; set; }
    public string Asin { get; set; }
    public Style Style { get; set; }
    public string Summary { get; set; }
    public long UnixReviewTime { get; set; }
}

// Style model to deserialize the style object in the review
public class Style
{
    public string Size { get; set; }
    public string Color { get; set; }
}
