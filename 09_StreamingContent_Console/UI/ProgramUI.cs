using _07_RepositoryPattern_Repository;
using _08_StreamingContent_Inheritance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_StreamingContent_Console.UI
{
    public class ProgramUI
    {
        private readonly StreamingRepository _streamingRepo = new StreamingRepository();
        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine(
                    "Enter the number of the option you'd like to select: \n" +
                    "1. Show all streaming content \n" +
                    "2. Find streaming content by title \n" +
                    "3. Add new streaming content \n" +
                    "4. remove streaming content \n" +
                    "5. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //show all
                        ShowAllContent();
                        break;
                    case "2":
                        //find by title
                        ShowContentByTitle();
                        break;
                    case "3":
                        //Add new 
                        CreateNewContent();
                        break;
                    case "4":
                        //remove
                        RemoveContentFromList();
                        break;
                    case "5":
                        //exit
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 5. \n" +
                            "Press any key to continue....");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void CreateNewContent()
        {
            Console.Clear();
            StreamingContent content = new StreamingContent();
            // title
            Console.WriteLine("Please enter the title of the content: ");
            content.Title = Console.ReadLine();

            //description
            Console.WriteLine("Please enter the description: ");
            content.Description = Console.ReadLine();

            //MRating 
            Console.WriteLine("Select a Maturity Rating: \n" +
                "1) G \n" +
                "2) PG \n" +
                "3) PG 13 \n" +
                "4) R \n" +
                "5) NC 17 \n" +
                "6) TV MA");
            string maturityString = Console.ReadLine();
            switch (maturityString)
            {
                case "1":
                    content.MaturityRating = MaturityRating.G;
                    break;
                case "2":
                    content.MaturityRating = MaturityRating.PG;
                    break;
                case "3":
                    content.MaturityRating = MaturityRating.PG_13;
                    break;
                case "4":
                    content.MaturityRating = MaturityRating.R;
                    break;
                case "5":
                    content.MaturityRating = MaturityRating.NC_17;
                    break;
                case "6":
                    content.MaturityRating = MaturityRating.TV_MA;
                    break;
            }
            //star rating
            Console.WriteLine("Please enter the star-rating (1-5): ");
            content.StarRating = int.Parse(Console.ReadLine());
            //type of genre

            Console.WriteLine("Select a Genre: \n" +
                "1: Horror \n" +
                "2: Sci-Fi \n" +
                "3: Drama \n" +
                "4: Action \n" +
                "5: Comedy \n" +
                "6: Anime \n" +
                "7: Documentary \n" +
                "8: Thriller \n" +
                "9: Romance");
            string genreInput = Console.ReadLine();
            int genreID = int.Parse(genreInput);
            content.TypeOfGenre = (GenreType)genreID;
            _streamingRepo.AddContentToDirectory(content);
        }
        private void ShowAllContent()
        {
            Console.Clear();
            List<StreamingContent> listOfContent = _streamingRepo.GetContents();

            foreach (StreamingContent contentVariable in listOfContent)
            {
                DisplayContent(contentVariable);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void ShowContentByTitle()
        {
            Console.Clear();
            Console.WriteLine("Enter a title");
            string title = Console.ReadLine();
            StreamingContent foundTitle = _streamingRepo.GetContentByTitle(title);
            if (foundTitle != null)
            {
                DisplayContent(foundTitle);
            }
            else
            {
                Console.WriteLine("Invalid title. Cound not find any results.");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        private void RemoveContentFromList()
        {
            Console.WriteLine("Which item would you like to remove?");
            List<StreamingContent> contentList = _streamingRepo.GetContents();
            int count = 0;
            foreach (StreamingContent content in contentList)
            {
                count++;
                Console.WriteLine($"{count}. {content.Title}");
            }

            int targetContentId = int.Parse(Console.ReadLine());
            int targetIndex = targetContentId - 1;
            if(targetIndex >= 0 && targetIndex < contentList.Count)
            {
                StreamingContent desiredContent = contentList[targetIndex];
                if (_streamingRepo.DeleteExistingContent(desiredContent))
                {
                    Console.WriteLine($"{desiredContent.Title} successfully removed.");
                }
                else
                {
                    Console.WriteLine("I'm sorry, Dave. I'm afraid I can't do that.");
                }
            }
            else
            {
                Console.WriteLine("No content has that ID");
            }
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }
        private void DisplayContent(StreamingContent content)
        {
            Console.WriteLine($"Title: {content.Title} \n" +
                $"Description: {content.Description} \n" +
                $"Genre: {content.TypeOfGenre} \n" +
                $"Stars: {content.StarRating} \n" +
                $"Family Friendly: {content.IsFamilyFriendly} \n" +
                $"Rating: {content.MaturityRating}");
        }
    }
}
