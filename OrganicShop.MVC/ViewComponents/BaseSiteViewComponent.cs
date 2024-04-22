using Microsoft.AspNetCore.Mvc;


namespace OrganicShop.Mvc.ViewComponents
{
    

    //#region site top menu

    //public class SiteTopMenuViewComponent : ViewComponent
    //{
    //    #region constructor


    //    #endregion

    //    public async Task<IViewComponentResult> InvokeAsync()
    //    => View("SiteTopMenu");
    //}

    //#endregion

    //#region site second menu

    //public class SiteSecondMenuViewComponent : ViewComponent
    //{
    //    #region constructor

    //    private readonly ISiteSettingService _siteSettingService;
    //    public SiteSecondMenuViewComponent(ISiteSettingService siteSettingService)
    //    {
    //        this._siteSettingService = siteSettingService;
    //    }

    //    #endregion

    //    public async Task<IViewComponentResult> InvokeAsync()
    //    => View("SiteSecondMenu", await _siteSettingService.GetSiteSettingInformation());
    //}

    //#endregion

    //#region site middle block

    //public class SiteMiddleBlockSectionViewComponent : ViewComponent
    //{
    //    #region constructor

    //    private readonly ICategoryService _Categorieservice;
    //    private readonly ISiteSettingService _siteSettingService;
    //    public SiteMiddleBlockSectionViewComponent(ICategoryService Categorieservice, ISiteSettingService siteSettingService)
    //    {
    //        this._Categorieservice = Categorieservice;
    //        _siteSettingService = siteSettingService;
    //    }

    //    #endregion

    //    public async Task<IViewComponentResult> InvokeAsync()
    //    {
    //        ViewData["Categories"] = (await _Categorieservice.GetCategoriesAsCombo()).ToSelectListItem();
    //        return View("SiteMiddleBlockSection", await _siteSettingService.GetSiteSettingInformation());
    //    }
    //}

    //#endregion

    //#region site bottom block

    //public class SiteBottomBlockSectionViewComponent : ViewComponent
    //{
    //    #region constructor

    //    private readonly ICategoryService _Categorieservice;
    //    public SiteBottomBlockSectionViewComponent(ICategoryService Categorieservice)
    //    {
    //        this._Categorieservice = Categorieservice;
    //    }

    //    #endregion

    //    public async Task<IViewComponentResult> InvokeAsync()
    //    => View("SiteBottomBlockSection");
    //}

    //#endregion

    //#region Site language

    //public class SiteLanguageSectionViewComponent : ViewComponent
    //{
    //    #region constructor



    //    #endregion

    //    public async Task<IViewComponentResult> InvokeAsync()
    //    => View("SiteLanguageSection");
    //}

    //#endregion

    //#region site short messages

    //public class SiteShortMessagesViewComponent : ViewComponent
    //{
    //    #region constructor

    //    private readonly IMessageService _MessageService;
    //    public SiteShortMessagesViewComponent(IMessageService messageService)
    //    {
    //        this._MessageService = messageService;
    //    }

    //    #endregion

    //    public async Task<IViewComponentResult> InvokeAsync()
    //    => View("SiteShortMessages", await _MessageService.GetSiteMessagesAsCombo());
    //}

    //#endregion

    //#region site mobile Header

    //public class SiteMobileHeaderViewComponent : ViewComponent
    //{
    //    #region constructor

    //    private readonly IMessageService _MessageService;
    //    public SiteMobileHeaderViewComponent(IMessageService messageService)
    //    {
    //        this._MessageService = messageService;
    //    }

    //    #endregion

    //    public async Task<IViewComponentResult> InvokeAsync()
    //    => View("SiteMobileHeader", await _MessageService.GetSiteMessagesAsCombo());
    //}

    //#endregion

    //#region Site Footer

    //public class SiteFooterViewComponent : ViewComponent
    //{
    //    #region constructor

    //    private readonly ISiteSettingService _siteSettingSerivce;
    //    public SiteFooterViewComponent(ISiteSettingService siteSettingService)
    //    {
    //        this._siteSettingSerivce = siteSettingService;
    //    }

    //    #endregion

    //    public async Task<IViewComponentResult> InvokeAsync()
    //    => View("SiteFooter", await _siteSettingSerivce.GetSiteSettingInformation());
    //}

    //#endregion
}
