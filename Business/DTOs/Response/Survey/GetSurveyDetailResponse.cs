﻿namespace Business.DTOs.Response.Survey
{
    // GetSurveyDetailResponse
    public class GetSurveyDetailResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CreatorUserID { get; set; }
        // Diğer detay bilgiler
    }



}
