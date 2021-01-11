using FMS.ServiceLayer.Dtos;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace FMS.BlazorServerApp.Components
{
    public partial class TableControl<TItem> where TItem: class, IItemDto
    {
        private TItem selectedItem;

        [Parameter]
        public RenderFragment TableHeader { get; set; }

        [Parameter]
        public RenderFragment<TItem> RowTemplate { get; set; }

        [Parameter]
        public IList<TItem> Items { get; set; }

        [Parameter]
        public EventCallback<int> ItemSelected { get; set; }
    }
}
