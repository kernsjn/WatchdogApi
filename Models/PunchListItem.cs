using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WatchdogApi.Models;

namespace WatchdogApi.Models
{
  public class PunchListItem
  {

    public int Id { get; set; }


    public string Issue { get; set; }

    public string IssueLocation { get; set; }

    public Status Status { get; set; } = Status.Pending;

    public int FacilityId { get; set; }

    public Facility Facility { get; set; }

    public int BuildingId { get; set; }

    public Building Building { get; set; }

    public int ScopeId { get; set; }

    public Scope Scope { get; set; }

    public int AssignId { get; set; }

    public AssignPerson AssignPerson { get; set; }

    public int RequestId { get; set; }

    public Requestor Requestor { get; set; }


  }
}