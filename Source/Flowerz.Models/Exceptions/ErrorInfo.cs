namespace FlowerzAPI.Flowerz.Models.Exceptions
{
    public class ErrorInfo
    {
        #region Constructors

        public ErrorInfo()
        {
        }

        public ErrorInfo(Exception ex) : this(ex.Message)
        {
        }

        public ErrorInfo(string message)
        {
            this.Message = message?.Trim() ?? string.Empty;
        }

        #endregion

        #region Properties

        /// <summary> Defines a error identifier </summary>
        public string ID { get; set; } = Guid.NewGuid().ToString();

        /// <summary> Defines a message to be returned </summary>
        public string Message { get; set; } = string.Empty;

        #endregion
    }

    public class ErrorInfo<T> : ErrorInfo
    {
        #region Constructors

        public ErrorInfo(T value) : base()
        {
            this.Value = value;
        }

        public ErrorInfo(Exception ex, T value) : base(ex)
        {
            this.Value = value;
        }

        public ErrorInfo(string message, T value) : base(message)
        {
            this.Value = value;
        }

        #endregion

        #region Properties

        /// <summary> Defines the value </summary>
        public T Value { get; set; }

        #endregion
    }
}
