using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Mappers;
using Core.Models;
using DataLayer.Logic.OriginalWords;
using DataLayer.Logic.TranslateWords;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public interface IWordService
    {
        IEnumerable<WordModel> GetAllWordModels();
        WordModel SaveWord(WordModel wordModel, bool needSave = true);
    }

    public class WordService : IWordService
    {
        private readonly IOriginalWordReader _originalWordReader;
        private readonly IOriginalWordWriter _originalWordWriter;
        private readonly ITranslateWordReader _translateWordReader;
        private readonly ITranslateWordWriter _translateWordWriter;

        public WordService(ITranslateWordReader translateWordReader,
                           ITranslateWordWriter translateWordWriter,
                           IOriginalWordReader originalWordReader,
                           IOriginalWordWriter originalWordWriter)
        {
            _translateWordReader = translateWordReader;
            _originalWordReader = originalWordReader;
            _originalWordWriter = originalWordWriter;
            _translateWordWriter = translateWordWriter;
        }

        public IEnumerable<WordModel> GetAllWordModels()
        {
            var originalWords = _originalWordReader.All()
                .Include(o => o.TranslateWords)
                .ToWordModels();

            return originalWords;
        }

        public WordModel SaveWord(WordModel wordModel, bool needSave = true)
        {
            return _originalWordWriter
                .InsertOrUpdate(wordModel.ToOriginalWord())
                .ToWordModel();
        }
    }
}