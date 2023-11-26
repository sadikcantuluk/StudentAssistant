namespace StudentAssistant.WebUI.Dtos.Notes
{
    public class UpdateNotesDto
    {
        public int NotesID { get; set; }
        public string Subject { get; set; }
        public string NotesText { get; set; }
        public DateTime Date { get; set; }= DateTime.Now;
    }
}
