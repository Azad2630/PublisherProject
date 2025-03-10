﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using publisherproject.Data;
using publisherproject.DTOs.Author;
using publisherproject.Interfaces;
using publisherproject.Mappers;
using publisherproject.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace publisherproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly PublisherContext _context;
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(PublisherContext context, IAuthorRepository authorRepository)
        {
            this._context = context;
            this._authorRepository = authorRepository;
        }

        // https://localhost:7135/api/authors
        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var authors = await _authorRepository.GetAllAsync();
            var authorDtos = authors.Select(s => s.ToAuthorDto());
            return Ok(authorDtos);

            // var authors = _context.Authors.ToList();
            // return authors;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var author = await _authorRepository.GetByIdAsync(id, false);
            if (author == null)
            {
                return NotFound();
            }

            return Ok(author.ToAuthorDto());

            //var author = _context.Authors.FirstOrDefault(a => a.AuthorId == id);
            //if (author == null) {
            //    return null;
            //}
            //return author;
        }

        [HttpDelete("{id}")]
        //public string DeleteAuthor(int id)
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var authorModel = await _authorRepository.DeleteAsync(id);

            if (authorModel == null)
            {
                return NotFound();
            }

            return NoContent();



            //var authorToDelete = _context.Authors.Find(id);
            //if (authorToDelete == null)
            //{
            //    return "Bad request";
            //}
            //_context.Authors.Remove(authorToDelete);
            //_context.SaveChanges();
            //return $"{authorToDelete.FirstName} er slettet";
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateAuthorRequestDto authorToUpdate)
        {
            if (id != authorToUpdate.AuthorId)
            {
                return BadRequest("AuthorId mismatch");
            }

            var authorUpdated = await _authorRepository.UpdateAsync(id, authorToUpdate);
            if (authorUpdated == null)
            {
                return BadRequest("Author not updated");
            }

            return NoContent();

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RequestCreateAuthorDto createAuthorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var authorModel = createAuthorDto.ToAuthorFromRequestCreateDto();

            await _authorRepository.CreateAsync(authorModel);

            return CreatedAtAction(nameof(GetAuthorById), new { id = authorModel.AuthorId }, authorModel);
        }
    }
}
