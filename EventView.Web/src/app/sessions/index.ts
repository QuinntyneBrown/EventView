require("angular-rx-ui/src/components/core");

import { provide, provideAction, bootstrap } from "angular-rx-ui/src/components/core";
import { SessionsComponent } from "./sessions.component";
import { SessionCardComponent } from "./session-card.component";
import { SessionsActionCreator } from "./sessions.action-creator";
import * as reducers from "./sessions.reducers";
import * as actions from "./sessions.actions";

import { SessionsRoutes } from "./sessions.routes";

var app = (<any>angular.module("eventViewApp.sessions", []));

bootstrap(app, {
    routes: SessionsRoutes,
    reducers: reducers,
    actions: actions,
    components: [SessionsComponent, SessionCardComponent],
    providers: [SessionsActionCreator]
});

export * from "./sessions.component";