<%@Application Language='C#' Inherits="Sitecore.ContentSearch.SolrProvider.CastleWindsorIntegration.WindsorApplication" %>

<script runat="server">
  public void Application_Start() {

  }

  public void Application_End() {
  }

  public void Session_End()
  {
      Session.Abandon();
  }
  public void Application_Error(object sender, EventArgs args) 
  {
      Exception ex = Server.GetLastError();
      Exception b = ex.GetBaseException();
      if (b != null)
      {
          ex = b;
      }

      if (ex is System.Threading.ThreadAbortException)
      {
          return;
      }
      Sitecore.Diagnostics.Log.Error("Unhandled application error", ex, this);
  }

  public void FormsAuthentication_OnAuthenticate(object sender, FormsAuthenticationEventArgs args)
  {
    string frameworkVersion = this.GetFrameworkVersion();
    if (!string.IsNullOrEmpty(frameworkVersion) && frameworkVersion.StartsWith("v4.", StringComparison.InvariantCultureIgnoreCase))
    {
      args.User = Sitecore.Context.User;
    }
  }

  string GetFrameworkVersion()
  {
    try
    {
      return System.Runtime.InteropServices.RuntimeEnvironment.GetSystemVersion();
    }
    catch(Exception ex)
    {
      Sitecore.Diagnostics.Log.Error("Cannot get framework version", ex, this);
      return string.Empty;
    }
  }

</script>
