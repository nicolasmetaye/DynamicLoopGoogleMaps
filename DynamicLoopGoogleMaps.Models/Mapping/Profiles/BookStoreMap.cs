using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DynamicLoopGoogleMaps.Domain;
using DynamicLoopGoogleMaps.Models.Models;

namespace DynamicLoopGoogleMaps.Models.Mapping.Profiles
{
    public class BookStoreMap : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<BookStore, BookStoreModel>()
                .ForMember(model => model.BooksIds, expression => expression.ResolveUsing(bookStore => bookStore.Books.Select(book => book.Id)))
                .ForMember(model => model.Books, expression => expression.Ignore())
                .ForMember(model => model.IsEditMode, expression => expression.Ignore());
            Mapper.CreateMap<IEnumerable<Book>, BookStoreModel>()
                .ForMember(model => model.Books, expression => expression.ResolveUsing(books => books))
                .ForMember(model => model.BooksIds, expression => expression.Ignore())
                .ForMember(model => model.City, expression => expression.Ignore())
                .ForMember(model => model.Id, expression => expression.Ignore())
                .ForMember(model => model.IsEditMode, expression => expression.Ignore())
                .ForMember(model => model.Latitude, expression => expression.Ignore())
                .ForMember(model => model.Longitude, expression => expression.Ignore())
                .ForMember(model => model.Name, expression => expression.Ignore())
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
    }
}