import { CanActivate, ChangeDetectionStrategy, Component } from "angular-rx-ui/src/components/core";

@Component({
    template: require("./dashboard.component.html"),
    styles: [require("./dashboard.component.scss")],
    selector: "dashboard",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class DashboardComponent {
    constructor() { }
}
