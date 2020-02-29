using System.Collections.Generic;
using System.Threading.Tasks;
using ApiClient.Models;
using Core.Enums;
using Core.Extensions;
using Core.Models;

namespace ApiClient.Gateways
{
    public class TranslateGateway : BaseGateway
    {
        public async Task<ApiResponse<WordModel>> GetTranslate(string text)
            => await _internalApiClient.ExecuteGet<WordModel>(
                "translate",
                new Dictionary<string, string>
                {
                    {"text", text},
                    {"from", LanguageEnum.En.ToNumberString()},
                    {"to", LanguageEnum.Ru.ToNumberString()}
                });
        
        public async Task<ApiResponse<string>> Save(string original, string translate)
            => await _internalApiClient.ExecutePost<string>(
                "translate",
                new WordModel(original, translate));
    }
}