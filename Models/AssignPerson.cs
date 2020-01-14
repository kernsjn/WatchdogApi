using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WatchdogApi.Models;

namespace WatchdogApi.Models
{
  public class AssignPerson
  {

    public int Id { get; set; }

    [Required]
    public string Role { get; set; }


  }
}