const eventViewAppModule = angular.module("eventViewApp", ["components"]) as any;

import { authorizationGuard } from "angular-rx-ui/src/components/routing/authorization-guard";

import { bootstrap, IBootstrapOptions, provideRoutePromise } from "angular-rx-ui/src/components/core";

import {  AppComponent } from "./app/app.component";

eventViewAppModule.component(AppComponent);

provideRoutePromise(eventViewAppModule, authorizationGuard);

bootstrap(eventViewAppModule, {
    loginRedirectUrl: "/",
    api: "api",
    html5Mode:true
});
