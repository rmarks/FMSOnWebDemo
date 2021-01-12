using FMS.ServiceLayer.Dtos;
using Microsoft.AspNetCore.Components;

namespace FMS.BlazorServerApp.Components
{
    public partial class PagedTableControl<TItem> where TItem: class
    {
        private TItem selectedItem;

        [Parameter]
        public RenderFragment TableHeader { get; set; }

        [Parameter]
        public RenderFragment<TItem> RowTemplate { get; set; }

        [Parameter]
        public PagedList<TItem> PagedItems { get; set; }

        [Parameter]
        public EventCallback<TItem> ItemSelected { get; set; }

        [Parameter] 
        public EventCallback<int> PageChanged { get; set; }
    }
}
