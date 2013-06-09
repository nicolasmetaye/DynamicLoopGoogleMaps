using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DynamicLoopGoogleMaps.Common.Helpers;
using DynamicLoopGoogleMaps.Domain;
using DynamicLoopGoogleMaps.Domain.Repositories;
using DynamicLoopGoogleMaps.Models.Models;
using StructureMap;

namespace DynamicLoopGoogleMaps.Models.Mapping.Profiles
{
    public class BookMap : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Book, BookModel>()
                .ForMember(model => model.AuthorId, expression => expression.ResolveUsing(book => book.Author.Id))
                .ForMember(model => model.Authors, expression => expression.Ignore())
                .ForMember(model => model.IsEditMode, expression => expression.Ignore());
            Mapper.CreateMap<IEnumerable<Author>, BookModel>()
                .ForMember(model => model.Authors, expression => expression.ResolveUsing(authors => authors))
                .ForMember(model => model.AuthorId, expression => expression.Ignore())
                .ForMember(model => model.ISBN, expression => expression.Ignore())
                .ForMember(model => model.Id, expression => expression.Ignore())
                .ForMember(model => model.IsEditMode, expression => expression.Ignore())
                .ForMember(model => model.Title, expression => expression.Ignore());
            Mapper.CreateMap<Book, BookListItemModel>()
                .ForMember(model => model.AuthorFullName, expression => expression.ResolveUsing(book => book.Author.FirstName + " " + book.Author.LastName));
            Mapper.CreateMap<IEnumerable<Book>, BooksListModel>()
                .ForMember(model => model.Books, expression => expression.ResolveUsing(books => books))
                .ForMember(model => model.SuccessMessage, expression => expression.Ignore());
            Mapper.CreateMap<BookModel, Book>()
                .ForMember(book => book.ISBN, expression => expression.ResolveUsing(model => ISBNFilter.Filter(model.ISBN)));
        }
    }
}