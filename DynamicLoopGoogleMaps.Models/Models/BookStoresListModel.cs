using System.Collections.Generic;

namespace DynamicLoopGoogleMaps.Models.Models
{
    public class BookStoresListModel
    {
        public List<BookStoreListItemModel> BookStores { get; set; }
        public string SuccessMessage { get; set; }
    }
}
