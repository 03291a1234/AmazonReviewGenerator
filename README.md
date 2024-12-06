Amazon Review Generator

This project is an ASP.NET Core application that generates product reviews using a Markov chain model. The application reads training data from Amazon product reviews and produces a random review along with a star rating.

**Features**

Generates random product reviews based on training data.
Assigns a random star rating between 1 and 5.
Uses a Markov chain to create realistic review content.
Training data is ingested from a JSON file during application startup.
Prerequisites

.NET SDK installed (version 6.0 or higher).
Git installed for cloning the repository.
A JSON file (amazon_reviews.json) containing Amazon product reviews placed in the Data folder.
(Optional) Visual Studio or any IDE that supports .NET for development purposes.


**Getting Started**

Clone the Repository
git clone https://github.com/<your-repository>amazon-review-generator.git
cd amazon-review-generator
Setup Data
Place the amazon_reviews.json file in the Data folder.
Ensure the JSON structure matches the expected format:
{
    "overall": 5.0,
    "verified": true,
    "reviewTime": "09 4, 2015",
    "reviewerID": "ALJ66O1Y6SLHA",
    "asin": "B000K2PJ4K",
    "style": {
        "Size:": " Big Boys",
        "Color:": " Blue/Orange"
    },
    "reviewerName": "Tonya B.",
    "reviewText": "Great product and price!",
    "summary": "Five Stars",
    "unixReviewTime": 1441324800
}

**Build the Project**
Navigate to the root directory of the project.
Run the following command:
dotnet build
Run the Application
Use the following command:
dotnet run --project AmazonReviewGenerator
The application will start, and the API will be available at https://localhost:5001/api/review/generate.

**Usage**

Open a browser or API client (like Postman).
Send a GET request to:
https://localhost:5001/api/review/generate
The API will respond with a JSON object containing a randomly generated review and a star rating:
{
    "review": "This product is absolutely amazing and works great!",
    "rating": 5
}

**Running Tests**

Navigate to the Tests folder.
Run the tests using the following command:
dotnet test

**Troubleshooting**

File Not Found Exception: Ensure the amazon_reviews_2.json file is in the Data folder and matches the required structure.
Training Error: Verify the training data contains valid reviewText entries.
Markov Chain Not Trained: Make sure the LoadAndTrainAsync method completes successfully.

**Future Enhancements**

Add a front-end interface for easier interaction.
Implement sentiment analysis for more accurate star ratings.
Dockerize the application for deployment.
Contributing

Pull requests are welcome! For significant changes, please open an issue to discuss your ideas.

## **Author**
- [UDAY KIRAN CHINTHA](https://github.com/03291a1234)  
  Creator and maintainer of the Amazon Review Generator.


