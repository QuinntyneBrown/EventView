require("angular-rx-ui/src/components/core");

import { provide, provideAction } from "angular-rx-ui/src/components/core";
import { DashboardComponent } from "./dashboard.component";
import { DashboardActionCreator } from "./dashboard.action-creator";
import *  as reducers from "./dashboard.reducers";
import *  as actions from "./dashboard.actions";

var app = (<any>angular.module("eventViewApp.dashboard", [
]));

provide(app,DashboardActionCreator);

app.component(DashboardComponent);

app.config(["reducersProvider", reducersProvider => {	
    for (var reducer in reducers) { reducersProvider.configure(reducers[reducer]); }
}]);

for (var action in actions) { provideAction(app, actions[action]); }
