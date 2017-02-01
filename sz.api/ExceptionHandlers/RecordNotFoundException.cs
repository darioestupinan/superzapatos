namespace sz.api.ExceptionHandlers
{
    public class RecordNotFoundException : System.Exception
    {
        public RecordNotFoundException() { }
        public RecordNotFoundException(string message) : base(message) { }
        public RecordNotFoundException(string message, System.Exception inner) : base(message, inner) { }        
    }
}
