﻿using publisherproject.DTOs.Author;
using publisherproject.Models;

namespace publisherproject.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(int id, bool withoutBooks); // FirstOrDefault can be NULL
        Task<Author> CreateAsync(Author authorModel);
        Task<Author?> UpdateAsync(int id, UpdateAuthorRequestDto authorModel);
        Task<Author?> DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
