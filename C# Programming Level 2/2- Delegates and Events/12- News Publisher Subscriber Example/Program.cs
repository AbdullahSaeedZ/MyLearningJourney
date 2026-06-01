namespace _12__News_Publisher_Subscriber_Example
{

    public class ArticlesArgs : EventArgs
    {
        public int ArticleNumber { get; private set; }
        public string ArticleTopic { get; private set; }
        public string ArticleBody { get; private set; }
        public string PublisherName { get; private set; }
        public DateTime ArticleDate { get; private set; }

        public ArticlesArgs(int ArticleNumber, string ArticleTopic, string ArticleBody, string PublisherName, DateTime ArticleDate)
        {
            this.ArticleNumber = ArticleNumber;
            this.ArticleTopic = ArticleTopic;
            this.ArticleBody = ArticleBody;
            this.PublisherName = PublisherName;
            this.ArticleDate = ArticleDate;
        }
    }

    public class NewsPublisher
    {
        public event Action<ArticlesArgs> OnArticlePublished;
        public string PublisherName { get; set; }

        public NewsPublisher(string PublisherName)
        {
            this.PublisherName = PublisherName;
        }

        public void PublishArticle(int ArticleNumber, string ArticleTopic, string ArticleBody, DateTime ArticleDate)
        {
            OnArticlePublished?.Invoke(new ArticlesArgs(ArticleNumber, ArticleTopic, ArticleBody, this.PublisherName, ArticleDate));
        }
    }

    public class NewsSubscriber
    {
        public string SubscriberName { get; set; }

        public NewsSubscriber(string SubscriberName)
        {
            this.SubscriberName = SubscriberName;
        }

        public void Subscribe(NewsPublisher publisher)
        {
            publisher.OnArticlePublished += PrintArticleRecievedAndRead;
        }
        public void UnSubscribe(NewsPublisher publisher)
        {
            publisher.OnArticlePublished -= PrintArticleRecievedAndRead;
        }

        private void PrintArticleRecievedAndRead(ArticlesArgs e)
        {
            Console.WriteLine($"\nSubscriber ({this.SubscriberName}) has recieved the newly publiched article from {e.PublisherName}:");
            Console.WriteLine($"Article Number: {e.ArticleNumber} | Article Topic: {e.ArticleTopic} | Article Date: {e.ArticleDate.ToString()}");
            Console.WriteLine($"Article Body: {e.ArticleBody}\n");
        }
    }




    internal class Program
    {
        static void Main(string[] args)
        {
            NewsPublisher Obeikan = new NewsPublisher("Obeikan");
            NewsPublisher Madarek = new NewsPublisher("Madarek");

            NewsSubscriber Ahmad = new NewsSubscriber("Ahmad");
            NewsSubscriber Abdullah = new NewsSubscriber("Abdullah");
            NewsSubscriber Nasser = new NewsSubscriber("Nasser");


            Ahmad.Subscribe(Obeikan);
            Abdullah.Subscribe(Obeikan);
            Nasser.Subscribe(Madarek);

            Obeikan.PublishArticle(1, "Science", "Science today is ....", DateTime.Now);
            Madarek.PublishArticle(1, "Universities", "Universities today are ....", DateTime.Now);

            Abdullah.UnSubscribe(Obeikan);
            Obeikan.PublishArticle(3, "Football", "Football today is ....", DateTime.Now);
        }
    }
}
