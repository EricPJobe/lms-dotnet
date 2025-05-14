using lms_server.database;
using lms_server.dto.ParsedWord;
using lms_server.Helpers;
using lms_server.Interfaces;
using lms_server.Models;
using Microsoft.EntityFrameworkCore;

namespace lms_server.Repositories;
public class ParsedWordRepository : IParsedWordRepository
{
    private readonly ApplicationDBContext _context;

    public ParsedWordRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ParsedWord>> GetAllAsync()
    {
        return await _context.ParsedWord.ToListAsync();
    }

    public async Task<IEnumerable<ParsedWord>> GetByUnitAsync(int unitNumber)
    {
        return await _context.ParsedWord
            .Where(p => p.UnitNumber == unitNumber)
            .ToListAsync();
    }

    public async Task<IEnumerable<ParsedWord>> GetBySentenceAsync(int unitNumber, int sentenceNumber)
    {
        return await _context.ParsedWord
            .Where(p => p.UnitNumber == unitNumber && p.SentenceNumber == sentenceNumber)
            .ToListAsync();
    }

    public async Task<ParsedWord?> CreateParsedWordAsync(ParsedWord parsedWord)
    {
        await _context.ParsedWord.AddAsync(parsedWord);
        await _context.SaveChangesAsync();
        return parsedWord;
    }

    public async Task<ParsedWord?> UpdateParsedWordAsync(int id, UpdateParsedWordRequest parsedWord)
    {
        var parsedWordModel = await _context.ParsedWord.FirstOrDefaultAsync(x => x.Id == id);

        if (parsedWordModel == null)
        {
            return null;
        }

        parsedWordModel.UnitNumber = parsedWord.UnitNumber;
        parsedWordModel.SentenceNumber = parsedWord.SentenceNumber;
        parsedWordModel.Parsing = parsedWord.Parsing;
        parsedWordModel.Lemma = parsedWord.Lemma;
        parsedWordModel.DictionaryForm = parsedWord.DictionaryForm;
        parsedWordModel.Gloss = parsedWord.Gloss;

        _context.ParsedWord.Update(parsedWordModel);
        await _context.SaveChangesAsync();
        return parsedWordModel;
    }
}

