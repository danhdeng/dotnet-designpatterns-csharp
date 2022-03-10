using BehavioralPatterns.Iterator.Aggregates;
using BehavioralPatterns.Iterator.Models;
using RealisticDependencies.Logger;

namespace ExamplePrograms.BehavioralProgams.BestRestraurantFinder {
    internal class BestRestraurantFinder {
        /// <summary>
        /// we would like to travel to find the best restraurants one by one in our city
        /// from our current location. We want to visit the "best" restraurants first, 
        /// and the "worst last. since we have to follow a complex data structure representing
        /// the traversal path in different ways. we will use the Iterator Pattern to establish 
        /// different means of traversing our aggregate object without exposing its internal
        /// representation.
        /// 
        /// </summary>
        private static void Main() {
            var logger = new ConsoleLogger();
            logger.LogInfo(" Welcome to the Restraurant Finder");
            logger.LogInfo("--------------------------------------");
            logger.LogInfo(" Enter a number of restraurants to iterator over: ");

            string userInput;
            bool isNumber;
            int totalNumber;

            while (true) { 
                userInput = Console.ReadLine();
                isNumber=int.TryParse(userInput, out totalNumber);
                if (!isNumber)
                {
                    logger.LogInfo("Please enter a valid number between 1 and 10_000.");
                    continue;
                }
                else if (totalNumber > 10_000)
                {
                    logger.LogInfo("That's a bit too much. Try something less than 10_000.");
                    continue;
                }
                else {
                    break;    
                }
            }
            bool isVisitSort = false;
            bool isRatingSort = false;

            while (true) {
                logger.LogInfo("Do you want to iterate by Visit Popularity or Rating? (v/r");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "v")
                {
                    isVisitSort = true;
                    break;
                }
                else if (userInput == "r")
                {
                    isRatingSort = true;
                    break;
                }
                else {
                    logger.LogInfo("Please enter [v] for Visit Sort or [r] for Rating Sort.");
                    continue;
                }
            }

            var rng=new Random();
            var collection = new RestraurantCollection();
            for (var i = 0; i < totalNumber; i++) {
                var name =Guid.NewGuid().ToString().Substring(0,12);    
                var rating = rng.Next(0, 100);
                var visitCount = rng.Next(0, 5_000);
                collection.AddItem(new(name, rating, visitCount));
            }
            if (isRatingSort) {
                logger.LogInfo("Sorting by Rating");
                collection.SortByRatingDescending();
            }
            if (isVisitSort)
            {
                logger.LogInfo("Sorting by Visit Count");
                collection.SortByPopularityDescending();
            }

            foreach (var element in collection) {
                var restraurant = (Restraurant)element;
                logger.LogInfo($"Rating: {restraurant.Rating}; Visit: {restraurant.VisitCount}");
            }
        }
    }
}