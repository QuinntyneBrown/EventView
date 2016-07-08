import { authorizationGuard } from "angular-rx-ui/src/components/routing/authorization-guard";
import { bootstrap, IBootstrapOptions, provideRoutePromise } from "angular-rx-ui/src/components/core";
import { AppComponent, DashboardComponent, SessionsComponent, SpeakersComponent, TalksComponent } from "./app";

const eventViewAppModule = angular.module("eventViewApp", [
    "components",
    "eventViewApp.dashboard",
    "eventViewApp.sessions",
    "eventViewApp.shared",
    "eventViewApp.speakers",
    "eventViewApp.talks"
]) as any;

eventViewAppModule.component(AppComponent);

provideRoutePromise(eventViewAppModule, authorizationGuard);

bootstrap(eventViewAppModule, {
    api: "api",
    html5Mode: true,
    loginRedirectUrl: "/",
    routes: [
        { path: "/", component: DashboardComponent },
        { path: "/sessions", component: SessionsComponent },
        { path: "/speakers", component: SpeakersComponent },
        { path: "/talks", component: TalksComponent }
    ]
})


