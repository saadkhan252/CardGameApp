using Microsoft.AspNetCore.Components;

namespace CardGameApp.Components.Pages
{
    public partial class ShowScore
    {
        [Parameter]
        public int? Score { get; set; } = null;

        [Parameter]
        public bool HasError { get; set; }

        [Parameter]
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
