using FMS.ServiceLayer.Dtos;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

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
        public EventCallback<TItem> ItemDblclicked { get; set; }

        [Parameter]
        public EventCallback<TItem> ItemClicked { get; set; }

        [Parameter] 
        public EventCallback<int> PageChanged { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object> AdditionalAttributes { get; set; }
    }
}
