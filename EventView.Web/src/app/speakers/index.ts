require("angular-rx-ui/src/components/core");

import { provide, provideAction } from "angular-rx-ui/src/components/core";
import { SpeakersComponent } from "./speakers.component";
import { SpeakersActionCreator } from "./speakers.action-creator";
import *  as reducers from "./speakers.reducers";
import *  as actions from "./speakers.actions";

var app = (<any>angular.module("app.speakers", [
    "app.core"    
]));

provide(app,SpeakersActionCreator);

app.component(SpeakersComponent);

app.config(["reducersProvider", reducersProvider => {	
    for (var reducer in reducers) { reducersProvider.configure(reducers[reducer]); }
}]);

for (var action in actions) { provideAction(app, actions[action]); }
