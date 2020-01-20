using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WatchdogApi.Models;

namespace WatchdogApi.Models
{
  public class Facility
  {

    public int Id { get; set; }

    [Required]
    public string FacilityName { get; set; }

    public DateTime DateFacilityAdded { get; set; } = DateTime.UtcNow;

    [JsonIgnore]
    public List<Building> Buildings { get; set; } = new List<Building>();

  }
}