﻿using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Country;
using Business.DTOs.Response.Country;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.Profiles;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class CountryManager : ICountryService
    {
        ICountryDal _countryDal;
        IMapper _mapper;
        CountryBusinessRules _businessRules;

        public CountryManager(CountryBusinessRules businessRules, ICountryDal CountryDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _countryDal = CountryDal;
            _mapper = mapper;
        }

        public async Task<CreatedCountryResponse> Add(CreateCountryRequest createCountryRequest)
        {
            Country country = _mapper.Map<Country>(createCountryRequest);
            Country createdCountry = await _countryDal.AddAsync(country);
            CreatedCountryResponse createdCountryResponse = _mapper.Map<CreatedCountryResponse>(createdCountry);
            return createdCountryResponse;
        }

        public async Task<DeletedCountryResponse> Delete(DeleteCountryRequest deleteCountryRequest)
        {
            var data = await _countryDal.GetAsync(i => i.Id == deleteCountryRequest.Id);
            _mapper.Map(deleteCountryRequest, data);
            var result = await _countryDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedCountryResponse>(result);
            return result2;
        }

        public async Task<CreatedCountryResponse> GetById(int id)
        {
            var result = await _countryDal.GetAsync(c => c.Id == id);
            Country mappedCountry = _mapper.Map<Country>(result);
            CreatedCountryResponse createdCountryResponse = _mapper.Map<CreatedCountryResponse>(mappedCountry);
            return createdCountryResponse;
        }


        public async Task<IPaginate<GetListCountryResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _countryDal.GetListAsync(
                include: u => u
                    .Include(c => c.Cities),
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListCountryResponse>>(data);
            return result;
        }


        public async Task<UpdatedCountryResponse> Update(UpdateCountryRequest updateCountryRequest)
        {
            var data = await _countryDal.GetAsync(i => i.Id == updateCountryRequest.Id);
            _mapper.Map(updateCountryRequest, data);
            await _countryDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedCountryResponse>(data);
            return result;
        }
    }
}
