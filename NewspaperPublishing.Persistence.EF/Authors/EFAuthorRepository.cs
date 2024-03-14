﻿using Microsoft.EntityFrameworkCore;
using NewspaperPublishing.Entities.Authors;
using NewspaperPublishing.Persistence.EF;
using NewspaperPublishing.Services.Authors.Contarcts.Dtos;

namespace NewspaperPublishing.Spec.Tests.Authors
{
    public class EFAuthorRepository :AuthorRepository
    {
        readonly DbSet<Author> _authors;
        public EFAuthorRepository(EFDataContext context)
        {
            _authors = context.Authors;
        }

        public void Add(Author author)
        {
           _authors.Add(author);
        }

        public void Delete(Author author)
        {
            _authors.Remove(author);
        }

        public Author? FindAuthorById(int id)
        {
            return _authors.FirstOrDefault(_ => _.Id == id);
        }

        public List<GetAuthorsDto> GetAll()
        {
            var author = _authors.Select
                 (_ => new GetAuthorsDto
                 {
                     Id = _.Id,
                     FirstName = _.FirstName,
                     LastName = _.LastName,
                     
                 }).ToList();
            
            return author;

        }
    }
}