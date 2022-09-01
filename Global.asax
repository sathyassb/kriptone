<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="System.ServiceModel.Activation" %>
<%@ Import Namespace="System.ServiceModel.Web " %>
<%@ Import Namespace="System.Web.Management" %> 
<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RegisterRoutes(RouteTable.Routes);

    }
    public static void RegisterRoutes(RouteCollection routes)
    {

        routes.MapPageRoute("email-sent-report", "email-sent-report", "~/email-sent-report.aspx");
        routes.MapPageRoute("print-report", "print-report", "~/print-report.aspx");
        routes.MapPageRoute("user-idle-time-report", "user-idle-time-report", "~/user-idle-time-report.aspx");
        routes.MapPageRoute("user-timesheet-report", "user-timesheet-report", "~/user-timesheet-report.aspx");
        routes.MapPageRoute("user-activities-report", "user-activities-report", "~/user-activities-report.aspx");
        routes.MapPageRoute("dashbord", "dashboard", "~/dashboard.aspx");
        routes.MapPageRoute("file-shadows", "file-shadows", "~/file-shadows.aspx");
        routes.MapPageRoute("application-report", "application-report", "~/application-report.aspx");
        routes.MapPageRoute("authenticate-report", "authenticate-report", "~/authenticate-report.aspx");
        routes.MapPageRoute("usbs-report", "usbs-report", "~/usbs-report.aspx");
        routes.MapPageRoute("clipboard-report", "clipboard-report", "~/clipboard-report.aspx");
        //Logout
        routes.MapPageRoute("logout", "logout", "~/logout.aspx");

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
    
    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    private void Application_AuthenticateRequest(object sender, EventArgs eventArgs)
    {
        try
        {
            var app = (HttpApplication)sender;
            var principal = app.Context.User;
            if (principal == null || !principal.Identity.IsAuthenticated) return;
            var cookie = app.Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null) return;
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            if (ticket == null) return;
            var roles = ticket.UserData.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            var identity = principal.Identity;
            app.Context.User = new System.Security.Principal.GenericPrincipal(identity, roles);
        }
        catch (Exception)
        {
            return;
        }
    }

</script>
