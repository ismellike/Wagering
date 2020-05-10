﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Wagering.Models
{
    public class Tournament : Group
    {
        [Column(TypeName = "decimal(18,7)")]
        public decimal Entry { get; set; }

        public override bool IsApproved()
        {
            throw new System.NotImplementedException();
        }
        public override string GroupName
        {
            get
            {
                return GetGroupName.Tournament(Id);
            }
        }
        public override IEnumerable<string> HostUsers()
        {
            return null;
        }
        public override IEnumerable<string> ClientUsers()
        {
            return null;
        }
        public override IEnumerable<string> AllUsers()
        {
            return null;
        }
    }
}