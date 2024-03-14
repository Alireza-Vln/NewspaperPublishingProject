﻿using NewspaperPublishing.Entities.Authors;

namespace NewspaperPublishing.Spec.Tests.Authors
{
    public class AuthorBuilder 
    {
        readonly Author _author;
        public AuthorBuilder()
        {
            _author = new Author
            {
                FirstName = "dummy-first-name",
                LastName = "dummy-last-name"
            };
        }
        public AuthorBuilder WithFirstName(string FirstName)
        {
            _author.FirstName = FirstName;
            return this;
        }
        public AuthorBuilder WithLastName(string LastName)
        {
            _author.LastName = LastName;
            return this;
        }
        public  Author Build()
        {
            return _author;
        }
    }
}
