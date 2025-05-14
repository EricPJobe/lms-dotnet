using lms_server.mapper;
using lms_server.dto.ParsedWord;
using lms_server.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ParsedWordsController : ControllerBase
{
    private readonly IParsedWordRepository _repository;

    public ParsedWordsController(IParsedWordRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var words = await _repository.GetAllAsync();
        return Ok(words.Select(ParsedWordMapper.ToParsedWordDto));
    }

    [HttpGet("unit/{unitNumber}")]
    public async Task<IActionResult> GetByUnit(int unitNumber)
    {
        var words = await _repository.GetByUnitAsync(unitNumber);
        return Ok(words.Select(ParsedWordMapper.ToParsedWordDto));
    }

    [HttpGet("unit/{unitNumber}/sentence/{sentenceNumber}")]
    public async Task<IActionResult> GetBySentence(int unitNumber, int sentenceNumber)
    {
        var words = await _repository.GetBySentenceAsync(unitNumber, sentenceNumber);
        return Ok(words.Select(ParsedWordMapper.ToParsedWordDto));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ParsedWordDto dto)
    {
        var word = ParsedWordMapper.ToParsedWordFromDto(dto);
        await _repository.CreateParsedWordAsync(word);
        return CreatedAtAction(nameof(GetBySentence), new { unitNumber = dto.UnitNumber, sentenceNumber = dto.SentenceNumber }, ParsedWordMapper.ToParsedWordDto(word));
    }
}
