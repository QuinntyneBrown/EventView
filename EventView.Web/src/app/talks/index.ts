require("angular-rx-ui/src/components/core");

import { provide, provideAction } from "angular-rx-ui/src/components/core";
import { TalksComponent } from "./talks.component";
import { TalksActionCreator } from "./talks.action-creator";
import *  as reducers from "./talks.reducers";
import *  as actions from "./talks.actions";

var app = (<any>angular.module("app.talks", [
    "app.core"    
]));

provide(app,TalksActionCreator);

app.component(TalksComponent);

app.config(["reducersProvider", reducersProvider => {	
    for (var reducer in reducers) { reducersProvider.configure(reducers[reducer]); }
}]);

for (var action in actions) { provideAction(app, actions[action]); }
