using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FontAwesomeGenerator
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
    public class Category
    {
        public string Label { get; set; }
        public List<string> Icons { get; set; }
    }
}