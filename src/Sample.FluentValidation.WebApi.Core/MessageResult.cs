namespace Sample.FluentValidation.WebApi.Core;

public class MessageResult
{
    public MessageResult(string code, string description)
    {
        Code = code;
        Description = description;
    }

    public string Code { get; set; }
    public string Description { get; set; }
}