﻿using ErrorHandling.API.Converters;
using ErrorHandling.API.Filters;
using ErrorHandling.API.Dto;
using ErrorHandling.Service.Model;
using ErrorHandling.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ErrorHandling.API.Controllers;

[ApiController]
[Route("company")]
[ValidationFilter]
[TypeFilter(typeof(GlobalExceptionFilter))]
public class CompanyController : Controller
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult<List<CompanyDto>>> GetAll()
    {
        var companies = await _companyService.GetAllAsync();
        return companies.ToDto().ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CompanyDto>> GetById(int id)
    {
        CompanyModel company = await _companyService.GetByIdAsync(id);
        return company.ToDto();
    }

    [HttpPost]
    public async Task<ActionResult<CompanyDto>> Post(CompanyAddDto company)
    {
        CompanyModel model = await _companyService.AddAsync(company.ToModel());
        return model.ToDto();
    }
}