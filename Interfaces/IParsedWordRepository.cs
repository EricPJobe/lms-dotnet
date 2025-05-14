using lms_server.dto.ParsedWord;
using lms_server.Helpers;
using lms_server.Models;

namespace lms_server.Interfaces;

public interface IParsedWordRepository
{
    Task<IEnumerable<ParsedWord>> GetAllAsync();
    Task<IEnumerable<ParsedWord>> GetByUnitAsync(int unitNumber);
    Task<IEnumerable<ParsedWord>> GetBySentenceAsync(int unitNumber, int sentenceNumber);
    Task<ParsedWord?> CreateParsedWordAsync(ParsedWord word);
    Task<ParsedWord?> UpdateParsedWordAsync(int id, UpdateParsedWordRequest parsedWord);
}