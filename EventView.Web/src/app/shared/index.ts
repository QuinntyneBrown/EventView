require("../core");

import { provide, provideAction } from "angular-rx-ui/src/components/core";
import { AppHeaderComponent } from "./app-header";
import { AppFooterComponent } from "./app-footer";

var app = (<any>angular.module("eventViewApp.shared", []));

app.component(AppHeaderComponent);
app.component(AppFooterComponent);
