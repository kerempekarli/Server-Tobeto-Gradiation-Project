﻿using AutoMapper;
using Azure;
using Business.Abstracts;
using Business.DTOs.Request.UserExperience;
using Business.DTOs.Response.UserExperience;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class UserExperienceManager : IUserExperienceService
    {
        private readonly IUserExperienceDal _repository;
        private readonly IMapper _mapper;

        public UserExperienceManager(IUserExperienceDal repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IPaginate<GetListUserExperienceResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _repository.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);
            var result = _mapper.Map<Paginate<GetListUserExperienceResponse>>(data);
            return result;
        }

        public async Task<CreatedUserExperienceResponse> Add(CreateUserExperienceRequest createUserExperienceRequest)
        {
            var userExperience = _mapper.Map<UserExperience>(createUserExperienceRequest);
            var createdUserExperience = await _repository.AddAsync(userExperience);
            var result = _mapper.Map<CreatedUserExperienceResponse>(createdUserExperience);
            return result;
        }

        public async Task<UpdatedUserExperienceResponse> Update(UpdateUserExperienceRequest updateUserExperienceRequest)
        {
            var userExperience = await _repository.GetAsync(ue => ue.Id == updateUserExperienceRequest.Id);
            _mapper.Map(updateUserExperienceRequest, userExperience);
            await _repository.UpdateAsync(userExperience);
            var result = _mapper.Map<UpdatedUserExperienceResponse>(userExperience);
            return result;
        }

        public async Task<DeletedUserExperienceResponse> Delete(DeleteUserExperienceRequest deleteUserExperienceRequest)
        {
            var userExperience = await _repository.GetAsync(ue => ue.Id == deleteUserExperienceRequest.Id);
            var deletedUserExperience = await _repository.DeleteAsync(userExperience);
            var result = _mapper.Map<DeletedUserExperienceResponse>(deletedUserExperience);
            return result;
        }

        public async Task<GetListUserExperienceResponse> GetById(int id)
        {
            var userExperience = await _repository.GetAsync(ue => ue.Id == id);
            var result = _mapper.Map<GetListUserExperienceResponse>(userExperience);
            return result;
        }

        public async Task<IPaginate<GetListUserExperienceResponse>> GetUserExperiencesByUserId(Guid userId)
        {
            var userExperiences = await _repository.GetListAsync(ue => ue.UserId == userId);
            var result = _mapper.Map<IPaginate<GetListUserExperienceResponse>>(userExperiences);
            return result;
        }
    }
}
