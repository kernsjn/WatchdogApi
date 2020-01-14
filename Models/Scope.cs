using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WatchdogApi.Models;

namespace WatchdogApi.Models
{
  public class Scope
  {

    public int Id { get; set; }

    [Required]
    public string Description { get; set; }


  }
}