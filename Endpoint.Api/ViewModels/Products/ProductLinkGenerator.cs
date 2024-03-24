using Amazon.Runtime.Internal.Endpoints.StandardLibrary;

namespace Endpoint.Api.ViewModels.Products
{
    public static class ProductLinkGenerator
    {
        private static string productUrl = "https://localhost:7128/";
        public static ProductViewModel AddLinks(this ProductViewModel model)
        {
            var links = new List<LinkDto>()
            {
                new LinkDto(productUrl,"product_update",HttpMethod.Put.Method),
                new LinkDto($"{productUrl}/{model?.Id}","product_delete",HttpMethod.Delete.Method)
            };
            model.Links = links;
            return model;
        }
        public static List<ProductViewModel> AddLinks(this List<ProductViewModel> models)
        {
            foreach (var item in models)
            {
                var links = new List<LinkDto>()
                {
                    new LinkDto(productUrl,"product_update", HttpMethod.Put.Method),
                    new LinkDto($"{productUrl}/{item.Id}","product_delete",HttpMethod.Delete.Method),
                    new LinkDto($"{productUrl}/{item.Id}","self",HttpMethod.Get.Method)
                };
                item.Links = links;
            }
            return models;
        }
    }
}
