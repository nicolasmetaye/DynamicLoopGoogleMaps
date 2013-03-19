using System.ComponentModel;

namespace DynamicLoopGoogleMaps.Models.Models
{
    public enum BookStoresListSuccessMessage
    {
        [Description("None")]
        None = 0,
        [Description("Book store added succesfully")]
        BookStoreAddedSuccesfully = 1,
        [Description("Book store edited succesfully")]
        BookStoreEditedSuccesfully = 2,
        [Description("Book store deleted succesfully")]
        BookStoreDeletedSuccesfully = 3
    }
}