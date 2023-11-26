namespace StudentAssistant.WebUI.Dtos.Daily
{
    public class AddDailyDto
    {
        public string DailyText { get; set; }
        public DateTime Date { get; set; }= DateTime.Now;
    }
}
