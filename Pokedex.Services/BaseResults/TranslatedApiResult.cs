using Pokedex.Services.Models;

namespace Pokedex.Services.BaseResults
{
    public class TranslatedApiResult : BaseResult
    {
        public TranslatedText TranslatedText { get; set; }

        public TranslatedApiResult(string error)
            : base(error)
        {

        }
        public TranslatedApiResult(TranslatedText translated)
        {
            this.TranslatedText = translated;
            IsSuccess = true;
        }
    }
}
