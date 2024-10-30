using System.Text.Json.Serialization;

namespace LibraryApp.API.HttpClients
{



    public class Questions
    {
        [JsonPropertyName("items")]
        public List<Question> Items { get; set; }
    }

    public class Question
    {
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonPropertyName("owner")]
        public QuestionOwner Owner { get; set; }

        [JsonPropertyName("is_answered")]
        public bool IsAnswered { get; set; }

        [JsonPropertyName("view_count")]
        public int ViewCount { get; set; }

        [JsonPropertyName("answer_count")]
        public int AnswerCount { get; set; }

        [JsonPropertyName("score")]
        public int Score { get; set; }

        [JsonPropertyName("last_activity_date")]
        public long LastActivityDate { get; set; } // Use Unix timestamp type

        [JsonPropertyName("creation_date")]
        public long CreationDate { get; set; } // Use Unix timestamp type

        [JsonPropertyName("question_id")]
        public int QuestionId { get; set; }

        [JsonPropertyName("content_license")]
        public string ContentLicense { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }

    public class QuestionOwner
    {
        [JsonPropertyName("account_id")]
        public int AccountId { get; set; }

        [JsonPropertyName("reputation")]
        public int Reputation { get; set; }

        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        [JsonPropertyName("user_type")]
        public string UserType { get; set; }

        [JsonPropertyName("profile_image")]
        public string ProfileImage { get; set; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }
    }

}
