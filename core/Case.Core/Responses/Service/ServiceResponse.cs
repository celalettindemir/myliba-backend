namespace Case.Core.Responses.Service;

public class ServiceResponse<T>
{
    public bool status { get; set; } = false;
    public string message { get; set; } = "Bir hata oluştu!";
    public T data { get; set; }
}