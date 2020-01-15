using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WatchdogApi.Models;

namespace WatchdogApi.Models
{
  public class Requestor
  {

    public int Id { get; set; }

    [Required]
    public string RequestRole { get; set; }


  }
}