﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Request.User;

namespace Business.DTOs.Request.Manager
{
    public class CreateManagerRequest
    {
        public Guid UserId { get; set; }
        public int ManagerCode { get; set; }
        public bool IsActive { get; set; }
    }
}
