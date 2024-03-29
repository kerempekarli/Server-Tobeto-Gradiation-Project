﻿using Business.DTOs.Response.User;
using Core.DataAccess.Paging;

namespace Business.DTOs.Response.Manager;

public class GetListManagerResponse : BasePageableModel
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    public List<GetListUserResponse> Users { get; set; }
    public int ManagerCode { get; set; }
    public bool IsActive { get; set; }
}