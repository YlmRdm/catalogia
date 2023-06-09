﻿using System;
using CAT.Catalog.Dtos;
using CAT.Catalog.Models;
using Shared.Dtos;

namespace CAT.Catalog.Services
{
	public interface ICategoryService
	{
        Task<Response<List<CategoryDto>>> GetAllAsync();

        Task<Response<CategoryDto>> GetByIdAsync(string id);

        Task<Response<CategoryDto>> CreateAsync(CategoryCreateDto categoryCreateDto);

        Task<Response<NoContent>> UpdateAsync(CategoryUpdateDto categoryUpdateDto);

        Task<Response<NoContent>> DeleteAsync(string id);
    }
}

