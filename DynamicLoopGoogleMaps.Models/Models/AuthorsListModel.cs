﻿using System.Collections.Generic;

namespace DynamicLoopGoogleMaps.Models.Models
{
    public class AuthorsListModel
    {
        public List<AuthorListItemModel> Authors { get; set; }
        public string SuccessMessage { get; set; }
    }
}
