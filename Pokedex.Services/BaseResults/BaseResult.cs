namespace Pokedex.Services.BaseResults
{
    public class BaseResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public BaseResult()
        {
        }
        public BaseResult(string error)
        {
            IsSuccess = false;
            ErrorMessage = error;
        }
    }
}
