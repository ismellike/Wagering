﻿namespace Wagering.Models
{
  public abstract class Approvable
  {
    public byte Status { get; set; }

    public abstract bool IsApproved();
  }
}
