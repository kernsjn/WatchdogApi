using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WatchdogApi.Models;

namespace WatchdogApi.Models
{
  public class PunchListItem
  {

    public int Id { get; set; }

    public int FacilityId { get; set; }

    public string Issue { get; set; }

    public string IssueLocation { get; set; }

    public enum Status
{
    Pending,
    Open,
    InReview,
    Closed
}

    public Facility Facilities { get; set; }

    public int BuildingId { get; set; }

    public Building Buildings { get; set; }

    public int ScopeId { get; set; }

    public Scope Scopes { get; set; }

    public int AssignId { get; set; }

    public AssignPerson AssignPersons { get; set; }

    public int RequestId { get; set; }

    public Requestor Requestors { get; set; }


  }
}