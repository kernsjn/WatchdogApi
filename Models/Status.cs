


namespace WatchdogApi.Models
{

  [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
  public enum Status
  {
    Pending,
    Open,
    InReview,
    Closed
  }
}