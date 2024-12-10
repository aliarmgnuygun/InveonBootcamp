﻿using AutoMapper;
using LibraryManagementApi.Repositories;
using LibraryManagementApi.Repositories.Authors;
using LibraryManagementApi.Services.Authors.Create;
using LibraryManagementApi.Services.Authors.Update;
using LibraryManagementApi.Services.Books;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LibraryManagementApi.Services.Authors
{
    public class AuthorService(IAuthorRepository authorRepository, RedisCacheService cacheService, IUnitOfWork unitOfWork, IMapper mapper) : IAuthorService
    {
        public async Task<ServiceResult<AuthorDto>> GetByIdAsync(int id)
        {
            var author = await authorRepository.Get(id);

            if (author == null)
            {
                return ServiceResult<AuthorDto>.Fail("Author not found.", HttpStatusCode.NotFound);
            }

            var response = mapper.Map<AuthorDto>(author);

            return ServiceResult<AuthorDto>.Success(response);
        }

        public async Task<ServiceResult<List<AuthorDto>>> GetAllListAsync()
        {
            var cacheKey = "authors-all-list";
            var cacheResult = await cacheService.GetFromCacheAsync<List<AuthorDto>>(cacheKey);

            if (cacheResult.IsSuccess && cacheResult.Data != null)
            {
                return ServiceResult<List<AuthorDto>>.Success(cacheResult.Data);
            }

            var authors = await authorRepository.GetAll().ToListAsync();

            if (authors == null || !authors.Any())
            {
                return ServiceResult<List<AuthorDto>>.Fail("No authors found.", HttpStatusCode.NotFound);
            }

            var response = mapper.Map<List<AuthorDto>>(authors);

            await cacheService.SetToCacheAsync(cacheKey, response);

            return ServiceResult<List<AuthorDto>>.Success(response);
        }

        public async Task<ServiceResult<List<AuthorDto>>> GetPagedAllListAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return ServiceResult<List<AuthorDto>>.Fail("Invalid page number or page size.", HttpStatusCode.BadRequest);
            }

            var authors = await authorRepository.GetAll()
                                          .Skip((pageNumber - 1) * pageSize)
                                          .Take(pageSize)
                                          .ToListAsync();

            if (authors == null || !authors.Any())
            {
                return ServiceResult<List<AuthorDto>>.Fail("No authors found.", HttpStatusCode.NotFound);
            }

            var authorAsDto = mapper.Map<List<AuthorDto>>(authors);

            return ServiceResult<List<AuthorDto>>.Success(authorAsDto);
        }

        public async Task<ServiceResult<AuthorWithBooksDto>> GetBooksWithAuthorIdAsync(int id)
        {
            var cacheKey = $"author-books-{id}";
            var cacheResult = await cacheService.GetFromCacheAsync<AuthorWithBooksDto>(cacheKey);

            if (cacheResult.IsSuccess && cacheResult.Data != null)
            {
                return ServiceResult<AuthorWithBooksDto>.Success(cacheResult.Data);
            }

            var author = await authorRepository.GetAuthorWithBooksAsync(id);

            if (author == null)
            {
                return ServiceResult<AuthorWithBooksDto>.Fail("Author not found.", HttpStatusCode.NotFound);
            }

            var response = mapper.Map<AuthorWithBooksDto>(author);

            await cacheService.SetToCacheAsync(cacheKey, response);

            return ServiceResult<AuthorWithBooksDto>.Success(response);
        }

        public async Task<ServiceResult<List<AuthorWithBooksDto>>> GetBooksWithAuthorsAsync()
        {
            var cacheKey = "authors-books";
            var cacheResult = await cacheService.GetFromCacheAsync<List<AuthorWithBooksDto>>(cacheKey);

            if (cacheResult.IsSuccess && cacheResult.Data != null)
            {
                return ServiceResult<List<AuthorWithBooksDto>>.Success(cacheResult.Data);
            }

            var authors = await authorRepository.GetAuthorWithBooks().ToListAsync();

            if (authors == null || !authors.Any())
            {
                return ServiceResult<List<AuthorWithBooksDto>>.Fail("No authors with books found.", HttpStatusCode.NotFound);
            }

            var response = mapper.Map<List<AuthorWithBooksDto>>(authors);

            await cacheService.SetToCacheAsync(cacheKey, response);

            return ServiceResult<List<AuthorWithBooksDto>>.Success(response);
        }

        public async Task<ServiceResult<int>> CreateAsync(CreateAuthorRequest request)
        {

            var author = mapper.Map<Author>(request);
            await authorRepository.AddAsync(author);
            await unitOfWork.Save();

            return ServiceResult<int>.Success(author.Id);
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateAuthorRequest request)
        {
            var author = await authorRepository.Get(id);
            if (author == null)
            {
                return ServiceResult.Fail($"Author with ID {id} was not found.");
            }

            mapper.Map(request, author);
            authorRepository.Update(author);
            await unitOfWork.Save();

            return ServiceResult.Success();
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var author = await authorRepository.Get(id);
            if (author == null)
            {
                return ServiceResult.Fail($"Author with ID {id} was not found.");
            }

            authorRepository.Delete(author.Id);
            await unitOfWork.Save();

            return ServiceResult.Success();
        }
    }
}
