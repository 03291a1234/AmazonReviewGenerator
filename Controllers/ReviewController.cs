using AmazonReviewGenerator.Services;
using Microsoft.AspNetCore.Mvc;

namespace AmazonReviewGenerator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewService _reviewService;

        public ReviewController(ReviewService reviewService)
        { 
            _reviewService = reviewService;
        }

        [HttpGet("generate")]
        public IActionResult GenerateReview()
        {
            var reviewContent = _reviewService.GenerateReviewContent();
            var starRating = _reviewService.GenerateStarRating();

            return Ok(new { Review = reviewContent, Rating = starRating });
        }
    }
}
