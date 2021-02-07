using FMS.BlazorServerApp.Extensions;
using FMS.ServiceLayer.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System;

namespace FMS.BlazorServerApp.Components
{
    public abstract class PagedListComponentBase<TListItem, TOptions> : ComponentBase, IDisposable 
        where TListItem : class
        where TOptions : PagedArgsBase
    {
        protected PagedList<TListItem> PagedList { get; private set; }
        protected TOptions Options { get; set; }
        protected Func<TOptions, PagedList<TListItem>> GetPagedList { get; set; }

        [Inject]
        protected NavigationManager NavManager { get; set; }

        [Inject]
        protected IServiceProvider ServiceProvider { get; set; }

        protected override void OnInitialized()
        {
            UpdateList();
            NavManager.LocationChanged += HandleLocationChanged;
        }

        #region helpers
        private void UpdateList()
        {
            NavManager.SetParametersFromQueryString(Options);
            PagedList = GetPagedList?.Invoke(Options);
        }
        #endregion

        #region event handlers
        protected void HandleOptionsChanged(int currentPage = 1)
        {
            Options.CurrentPage = currentPage;

            string relativeUri = NavManager.GetPathAndQueryStringFromParameters(Options);
            NavManager.NavigateTo(relativeUri);
        }

        private void HandleLocationChanged(object sender, LocationChangedEventArgs e)
        {
            UpdateList();
            StateHasChanged();
        }

        protected void HandleItemSelected(string itemUrl)
        {
            NavManager.NavigateTo($"{itemUrl}?returnUrl={NavManager.ToBaseRelativePath(NavManager.Uri)}");
        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
            NavManager.LocationChanged -= HandleLocationChanged;
        }
        #endregion
    }
}
