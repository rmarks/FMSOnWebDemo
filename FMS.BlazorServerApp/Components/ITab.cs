using Microsoft.AspNetCore.Components;

namespace FMS.BlazorServerApp.Components
{
    public interface ITab
    {
        RenderFragment ChildContent { get; }
    }
}
