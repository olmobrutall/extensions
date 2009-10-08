﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Signum.Entities.Authorization" %>
<%@ Import Namespace="Signum.Web" %>
<%@ Import Namespace="Signum.Utilities" %>

<%
    using (var user = Html.TypeContext<UserDN>(false))
    {
        if (user.Value !=null && user.Value.IdOrNull != null)
        {
            %>
            <div id="<%=user.Name + "DivOld"%>">
                <%
                    Html.ValueLine(user, u => u.UserName, vl => vl.ReadOnly = true);
                    Html.ValueLine("", Html.GlobalName(TypeContext.Compose(user.Name, "OldPassword")), new ValueLine() { LabelText = "Contraseña actual", ShowTicks = false });
                %>
            </div>
            <%
        }
            %>
            <div id="<%=user.Name + "DivNew"%>" style="display:none">
            <%
                if (user.Value != null && user.Value.IdOrNull == null)
                {
                    Response.Write("<script type=\"text/javascript\">\n" +
                        "$(document).ready(function() {\n" +
                        "$('#" + user.Name + "DivNew').show();\n" +
                        "});\n" +
                        "</script>\n");
                    //Response.Write("<input type=\"hidden\" id=\"{0}\" name=\"{0}\" value=\"\" />\n".Formato(user.Name + EntityBaseKeys.IsNew));

                    Html.ValueLine(user, u => u.UserName);
                    Html.ValueLine("", Html.GlobalName(TypeContext.Compose(user.Name, "NewPassword")), new ValueLine() { LabelText = "Contraseña", ShowTicks = false });
                    Html.ValueLine("", Html.GlobalName(TypeContext.Compose(user.Name, "NewPasswordBis")), new ValueLine() { LabelText = "Repita la contraseña", ShowTicks = false });
                }
        %>
        </div>
     <%
    }
 %>
