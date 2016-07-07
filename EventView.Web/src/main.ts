import { authorizationGuard } from "angular-rx-ui/src/components/routing/authorization-guard";
import { bootstrap, IBootstrapOptions, provideRoutePromise } from "angular-rx-ui/src/components/core";
import { AppComponent } from "./app/app.component";

require("./app/dashboard");
require("./app/sessions");
require("./app/speakers");
require("./app/talks");

const eventViewAppModule = angular.module("eventViewApp", [
    "components",
    "eventViewApp.dashboard",
    "eventViewApp.sessions",
    "eventViewApp.speakers",
    "eventViewApp.talks"
]) as any;

eventViewAppModule.component(AppComponent);

provideRoutePromise(eventViewAppModule, authorizationGuard);

bootstrap(eventViewAppModule, {
    loginRedirectUrl: "/",
    api: "api",
    html5Mode:true
});
