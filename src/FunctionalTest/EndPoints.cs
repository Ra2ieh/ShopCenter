
namespace FunctionalTest;

public static class Endpoints
{
    public static string ApiUrlBase = "https://localhost:7201";
    public static string GetAllDelayReport = $"{ApiUrlBase}/api/v1/DelayReport/GetAllDelayReport";
    public static string GetRequest = $"{ApiUrlBase}/api/v1/DelayReport/GetRequest?"+ "agentId={0}";
    public static string Registeration = $"{ApiUrlBase}/api/v1/DelayReport/Registeration?"+"orderId={0}"; 

}
