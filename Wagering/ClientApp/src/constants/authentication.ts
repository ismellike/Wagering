﻿﻿export const ApplicationName = "Wagering";

export const QueryParameterNames = {
    ReturnUrl: "returnUrl",
    Message: "message",
};

export const LogoutActions = {
    LogoutCallback: "logout-callback",
    Logout: "logout",
    LoggedOut: "logged-out",
};

export const LoginActions = {
    Login: "login",
    LoginCallback: "login-callback",
    LoginFailed: "login-failed",
    Register: "register",
};

const prefix = "/authentication";

export const ApplicationPaths = {
    DefaultLoginRedirectPath: "/",
    ApiAuthorizationClientConfigurationUrl: `/_configuration/${ApplicationName}`,
    ApiAuthorizationPrefix: prefix,
    Login: `${prefix}/${LoginActions.Login}`,
    LoginFailed: `${prefix}/${LoginActions.LoginFailed}`,
    LoginCallback: `${prefix}/${LoginActions.LoginCallback}`,
    Register: `${prefix}/${LoginActions.Register}`,
    LogOut: `${prefix}/${LogoutActions.Logout}`,
    LoggedOut: `${prefix}/${LogoutActions.LoggedOut}`,
    LogOutCallback: `${prefix}/${LogoutActions.LogoutCallback}`,
    IdentityRegisterPath: "/Identity/Account/Register",
    IdentityManagePath: "/Identity/Account/Manage",
};
