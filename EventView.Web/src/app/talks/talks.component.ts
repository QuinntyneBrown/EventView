import { CanActivate, ChangeDetectionStrategy, Component } from "angular-rx-ui/src/components/core";

@Component({
    template: require("./talks.component.html"),
    styles: [require("./talks.component.scss")],
    selector: "talks",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class TalksComponent {
    constructor() { }
}
