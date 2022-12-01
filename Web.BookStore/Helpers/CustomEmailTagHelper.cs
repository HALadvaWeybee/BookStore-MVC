using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Web.BookStore.Helpers
{
    public class CustomEmailTagHelper: TagHelper
    {
        public string myEmail { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", $"mailto:{myEmail}");
            output.Attributes.Add("id", "emailID");
            output.Content.SetHtmlContent("My Email");
        }
    }
}
