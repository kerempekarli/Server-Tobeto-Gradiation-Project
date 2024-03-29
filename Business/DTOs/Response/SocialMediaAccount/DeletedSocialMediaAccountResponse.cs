﻿using Core.DataAccess.Paging;

namespace Business.DTOs.Response.SocialMediaAccount;

public class DeletedSocialMediaAccountResponse 
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string SocialMedia { get; set; }
    public string SocialMediaUrl { get; set; }
}