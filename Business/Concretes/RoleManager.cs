﻿using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Role;
using Business.DTOs.Response.Role;
using Business.Rules.BusinessRules;
using Business.Rules.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class RoleManager : IRoleService
    {
        IRoleDal _roleDal;
        IMapper _mapper;
        RoleBusinessRules _businessRules;

        public RoleManager(RoleBusinessRules businessRules, IRoleDal roleDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _roleDal = roleDal;
            _mapper = mapper;
        }


        [ValidationAspect(typeof(CreateRoleRequestValidator))]
        public async Task<CreatedRoleResponse> Add(CreateRoleRequest createRoleRequest)
        {
            Role role = _mapper.Map<Role>(createRoleRequest);
            Role createdRole = await _roleDal.AddAsync(role);
            CreatedRoleResponse createdRoleResponse = _mapper.Map<CreatedRoleResponse>(createdRole);
            return createdRoleResponse;
        }

        public async Task<DeletedRoleResponse> Delete(DeleteRoleRequest deleteRoleRequest)
        {
            var data = await _roleDal.GetAsync(i => i.Id == deleteRoleRequest.Id);
            _mapper.Map(deleteRoleRequest, data);
            var result = await _roleDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedRoleResponse>(result);
            return result2;
        }

        public async Task<CreatedRoleResponse> GetById(int id)
        {
            var result = await _roleDal.GetAsync(c => c.Id == id);
            Role mappedRole = _mapper.Map<Role>(result);
            CreatedRoleResponse createdRoleResponse = _mapper.Map<CreatedRoleResponse>(mappedRole);
            return createdRoleResponse;
        }


        public async Task<IPaginate<GetListRoleResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _roleDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListRoleResponse>>(data);
            return result;
        }


        public async Task<UpdatedRoleResponse> Update(UpdateRoleRequest updateRoleRequest)
        {
            var data = await _roleDal.GetAsync(i => i.Id == updateRoleRequest.Id);
            _mapper.Map(updateRoleRequest, data);
            await _roleDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedRoleResponse>(data);
            return result;
        }
    }
}
