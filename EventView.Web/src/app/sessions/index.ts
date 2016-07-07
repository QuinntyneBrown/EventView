require("angular-rx-ui/src/components/core");

import { provide, provideAction } from "angular-rx-ui/src/components/core";
import { SessionsComponent } from "./sessions.component";
import { SessionsActionCreator } from "./sessions.action-creator";
import *  as reducers from "./sessions.reducers";
import *  as actions from "./sessions.actions";

var app = (<any>angular.module("eventViewApp.sessions", []));

provide(app,SessionsActionCreator);

app.component(SessionsComponent);

app.config(["reducersProvider", reducersProvider => {	
    for (var reducer in reducers) { reducersProvider.configure(reducers[reducer]); }
}]);

for (var action in actions) { provideAction(app, actions[action]); }
