using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DynamicLoopGoogleMaps.Common.Helpers;
using DynamicLoopGoogleMaps.Domain.Entities;
using DynamicLoopGoogleMaps.Domain.Repositories;
using DynamicLoopGoogleMaps.Models.Models;
using StructureMap;

namespace DynamicLoopGoogleMaps.Models.Mapping.Profiles
{
    public class BookStoreMap : Profile
    {
        public BookStoreMap()
        {
        }

        protected override void Configure()
        {
            Mapper.CreateMap<BookStore, BookStoreModel>()
                .ForMember(model => model.Books, expression => expression.ResolveUsing(bookStore => GetBooksList()))
                .ForMember(model => model.IsEditMode, expression => expression.Ignore());
            Mapper.CreateMap<BookStore, BookStoreListItemModel>()
                .ForMember(model => model.Books, expression => expression.ResolveUsing(bookStore => bookStore.Books.Count));
            Mapper.CreateMap<IEnumerable<BookStore>, BookStoresListModel>()
                .ForMember(model => model.BookStores, expression => expression.ResolveUsing(bookStores => bookStores))
                .ForMember(model => model.SuccessMessage, expression => expression.Ignore());
            Mapper.CreateMap<IEnumerable<BookStore>, MapModel>()
                .ForMember(model => model.BookStores, expression => expression.ResolveUsing(bookStores => bookStores));
            Mapper.CreateMap<BookStore, BookStoreListItemMapModel>();
            Mapper.CreateMap<BookStoreModel, BookStore>();
        }

        private List<BookListItemModel> GetBooksList()
        {
            return
                ((BookRepository)ObjectFactory.GetInstance(typeof(BookRepository)))
                .GetAll()
                .Select(book => new BookListItemModel { Id = book.Id, Title = book.Title, ISBN = book.ISBN, AuthorFullName = book.Author.FirstName + " " + book.Author.LastName})
                .ToList();
        }
    }
}