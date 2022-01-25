namespace NikolayITDemo.Web.Areas.Administration.Controllers
{
    using NikolayITDemo.Common;
    using NikolayITDemo.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
