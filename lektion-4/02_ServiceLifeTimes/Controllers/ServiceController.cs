using _02_ServiceLifeTimes.Services;
using Microsoft.AspNetCore.Mvc;

namespace _02_ServiceLifeTimes.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ISingletonService _singletonService;
        private readonly IScopedService _scopedService;
        private readonly ITransientService _transientService;

        public ServiceController(ISingletonService singletonService, IScopedService scopedService, ITransientService transientService)
        {
            _singletonService = singletonService;
            _scopedService = scopedService;
            _transientService = transientService;
        }

        public IActionResult Singleton()
        {
            return View("Singleton", _singletonService.GetGuid());
        }

        public IActionResult Scoped()
        {
            return View("Scoped", _scopedService.GetGuid());
        }

        public IActionResult Transient()
        {
            return View("Transient", _transientService.GetGuid());
        }
    }
}
