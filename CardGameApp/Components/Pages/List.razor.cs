using Microsoft.AspNetCore.Components;

namespace CardGameApp.Components.Pages
{
    public partial class List
    {
        [Parameter]
        public string Header { get; set; }

        [Parameter]
        public List<string> Cards { get; set; } = [];
    }
}
