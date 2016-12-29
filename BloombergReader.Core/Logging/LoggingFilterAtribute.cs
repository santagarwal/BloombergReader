using System.Web.Mvc;

namespace BloombergReader.Core.Logging
{
    public class LoggingFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Logger.Instance.InfoFormat("Action Executing: {0} {1}",
                filterContext.ActionDescriptor.ControllerDescriptor,
                filterContext.ActionDescriptor.ActionName);

            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                Logger.Instance.ErrorFormat("Exception thrown: ",
                    filterContext.Exception);
            }

            base.OnActionExecuted(filterContext);
        }
    }
}
