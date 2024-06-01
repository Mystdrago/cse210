using System;
using System.Collections.Generic;

namespace YouTubeVideoTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Video> videos = new List<Video>();

            // Create 3-4 instances of Video and add comments
            Video video1 = new Video("Exploring the Mountains", "NatureLover", 420);
            video1.AddComment(new Comment("Alice", "Amazing view!"));
            video1.AddComment(new Comment("Bob", "Wish I was there!"));
            video1.AddComment(new Comment("Charlie", "Breathtaking scenery."));
            videos.Add(video1);

            Video video2 = new Video("Cooking Pasta", "ChefJohn", 300);
            video2.AddComment(new Comment("David", "Great recipe!"));
            video2.AddComment(new Comment("Eva", "Tried it, and it was delicious."));
            video2.AddComment(new Comment("Frank", "Can you make a vegetarian version?"));
            videos.Add(video2);

            Video video3 = new Video("Tech Review: Latest Smartphone", "TechGuru", 600);
            video3.AddComment(new Comment("Grace", "Very informative."));
            video3.AddComment(new Comment("Hank", "I love the new features."));
            video3.AddComment(new Comment("Ivy", "Thanks for the detailed review."));
            videos.Add(video3);

            // Iterate through the list of videos and display details
            foreach (var video in videos)
            {
                Console.WriteLine($"Title: {video.Title}, Author: {video.Author}, Length: {video.Length} seconds");
                Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");

                foreach (var comment in video.Comments)
                {
                    Console.WriteLine($"Comment by {comment.CommenterName}: {comment.CommentText}");
                }
                Console.WriteLine();
            }
        }
    }

    class Video
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int Length { get; private set; } // Length in seconds
        public List<Comment> Comments { get; private set; }

        public Video(string title, string author, int length)
        {
            Title = title;
            Author = author;
            Length = length;
            Comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public int GetNumberOfComments()
        {
            return Comments.Count;
        }
    }

    class Comment
    {
        public string CommenterName { get; private set; }
        public string CommentText { get; private set; }

        public Comment(string commenterName, string commentText)
        {
            CommenterName = commenterName;
            CommentText = commentText;
        }
    }
}
