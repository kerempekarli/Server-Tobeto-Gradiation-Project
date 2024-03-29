﻿using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Assignments;
using Business.DTOs.Response.Assignments;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.CoursesFolder;

namespace Business.Concretes
{
    public class AssignmentManager : IAssignmentService
    {
        IAssignmentDal _assignmentDal;
        IMapper _mapper;
        AssignmentBusinessRules _assignmentBusinessRules;
        public AssignmentManager(IAssignmentDal assignmentDal, IMapper mapper, AssignmentBusinessRules assignmentBusinessRules)
        {
            _assignmentDal = assignmentDal;
            _mapper = mapper;
            _assignmentBusinessRules = assignmentBusinessRules;
        }

        public async Task<CreatedAssignmentResponse> Add(CreateAssignmentRequest createAssignmentRequest)
        {
            //await _assignmentBusinessRules.DoNotSendItAfterTheAssignmentPeriodIsOver(createAssignmentRequest.DeadLine);
            Assignment assignment = _mapper.Map<Assignment>(createAssignmentRequest);
            Assignment createdAssignment = await _assignmentDal.AddAsync(assignment);
            CreatedAssignmentResponse createdAssignmentResponse = _mapper.Map<CreatedAssignmentResponse>(createdAssignment);
            return createdAssignmentResponse;
        }

        public async Task<DeletedAssignmentResponse> Delete(DeleteAssignmentRequest deleteAssignmentRequest)
        {
            var data = await _assignmentDal.GetAsync(i => i.Id == deleteAssignmentRequest.Id);
            _mapper.Map(deleteAssignmentRequest, data);
            var result = await _assignmentDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedAssignmentResponse>(result);
            return result2;
        }

        public async Task<CreatedAssignmentResponse> GetById(int id)
        {
            var result = await _assignmentDal.GetAsync(c => c.Id == id);
            Assignment mappedAssignment = _mapper.Map<Assignment>(result);
            CreatedAssignmentResponse createdAssignmentResponse = _mapper.Map<CreatedAssignmentResponse>(mappedAssignment);
            return createdAssignmentResponse;
        }


        public async Task<IPaginate<GetListAssignmentResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _assignmentDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListAssignmentResponse>>(data);
            return result;
        }


        public async Task<UpdatedAssignmentResponse> Update(UpdateAssignmentRequest updateAssignmentRequest)
        {

            var data = await _assignmentDal.GetAsync(i => i.Id == updateAssignmentRequest.Id);
            _mapper.Map(updateAssignmentRequest, data);
            await _assignmentDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedAssignmentResponse>(data);
            return result;
        }
    }
}
