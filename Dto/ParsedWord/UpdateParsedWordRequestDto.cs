namespace lms_server.Models;
public class UpdateParsedWordRequest
{
    public int Id { get; set; }
    public int UnitNumber { get; set; }
    public int SentenceNumber { get; set; }
    public string Parsing { get; set; } = string.Empty;
    public string Lemma { get; set; } = string.Empty;
    public string DictionaryForm { get; set; } = string.Empty;
    public string Gloss { get; set; } = string.Empty;
}