namespace EShop.Core.ServiceResult
{
    public class ServiceResult<T> : ServiceResults
    {
        public T Item { get; private set; }

        public static ServiceResult<T> Ok(T item)
        {
            return new ServiceResult<T>()
            {
                IsSuccess = true,
                Item = item
            };
        }

        public static ServiceResult<T> Error(string error)
        {
            return new ServiceResult<T>()
            {
                ErrorMessage = error
            };
        }
    }

    public class ServiceResults
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }

        private static readonly ServiceResults OK_RESULT =
            new ServiceResults() { IsSuccess = true };

        public static ServiceResults Ok()
        {
            return OK_RESULT;
        }

        public static ServiceResults Error(string error)
        {
            return new ServiceResults()
            {
                ErrorMessage = error
            };
        }
    }
}
