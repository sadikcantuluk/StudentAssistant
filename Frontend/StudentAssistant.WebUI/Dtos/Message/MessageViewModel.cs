namespace StudentAssistant.WebUI.Dtos.Message
{
    public class MessageViewModel
    {

        public Choice[] choices { get; set; }
        public string Question { get; set; }



        public class Choice
        {
            public int index { get; set; }
            public Message message { get; set; }
            public string finish_reason { get; set; }
        }

        public class Message
        {
            public string role { get; set; }
            public string content { get; set; }
        }

    }
}
