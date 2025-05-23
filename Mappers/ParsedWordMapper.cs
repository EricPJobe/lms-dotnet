using lms_server.Models;
using lms_server.dto.ParsedWord;

namespace lms_server.mapper;
public static class ParsedWordMapper
{
    public static ParsedWordDto ToParsedWordDto(ParsedWord word)
    {
        return new ParsedWordDto
        {
            Id = word.Id,
            UnitNumber = word.UnitNumber,
            SentenceNumber = word.SentenceNumber,
            Parsing = word.Parsing,
            Lemma = word.Lemma,
            DictionaryForm = word.DictionaryForm,
            Gloss = word.Gloss
        };
    }

    public static ParsedWord ToParsedWordFromDto(ParsedWordDto dto)
    {
        return new ParsedWord
        {
            UnitNumber = dto.UnitNumber,
            SentenceNumber = dto.SentenceNumber,
            Parsing = dto.Parsing,
            Lemma = dto.Lemma,
            DictionaryForm = dto.DictionaryForm,
            Gloss = dto.Gloss
        };
    }
}
