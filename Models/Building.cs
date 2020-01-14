using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WatchdogApi.Models;

namespace WatchdogApi.Models
{
  public class Building
  {

    public int Id { get; set; }


    public string BuildingName { get; set; }

    public DateTime DateBuildingAdded { get; set; } = DateTime.UtcNow;

    public int? FacilityId { get; set; }

    public Facility Facilities { get; set; }

  }
}