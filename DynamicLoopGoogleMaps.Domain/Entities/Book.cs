﻿using DynamicLoopGoogleMaps.Domain.Repositories;

namespace DynamicLoopGoogleMaps.Domain.Entities
{
    public class Book : Entity
    {
        private readonly IAuthorRepository _authorRepository;

        public Book(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        private int _authorId = -1;
        private Author _author = null;

        public string Title { get; set; }
        public string ISBN { get; set; }

        public int AuthorId
        {
            get { return _authorId; }
            set
            {
                _authorId = value;
                _author = null;
            }
        }

        public Author Author
        {
            get
            {
                if (AuthorId > 0)
                {
                    _author = _authorRepository.GetById(AuthorId);
                    if (_author == null)
                        _authorId = -1;
                }
                return _author;
            }
        }

    }
}