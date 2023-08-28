namespace ApiHelper;

[Serializable]
public class CustomException : Exception
{
    public CustomException() { }

    public CustomException(string message,string code)
        : base(message) { 
    Data.Add("message", message);
    Data.Add("code", code);

    }


}
